using API_GroupDetail.DB.Entities;
using API_GroupDetail.DB.Entities.Dto;
using API_GroupDetail.DB.Repository;
using API_GroupDetail.Factories.CompleteSessionFactory;
using API_GroupDetail.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_GroupDetail.Services
{
    public class MasterService : IMasterService
    {
        private readonly ISchoolsRepository<Group> _groups;
        private readonly ISchoolsRepository<Teacher> _teachers;
        private readonly ISchoolsRepository<StudentGroup> _students;
        private readonly ISchoolsRepository<StudentAnswer> _answers;
        private readonly IContentRepository<Activity> _activities;
        private readonly IContentRepository<Subject> _subjects;
        private readonly IContentRepository<Language> _languages;
        private readonly IContentRepository<Course> _courses;



        public MasterService(ISchoolsRepository<Group> groups, 
                             ISchoolsRepository<Teacher> teachers,
                             ISchoolsRepository<StudentGroup> students,
                             ISchoolsRepository<StudentAnswer> answers,
                             IContentRepository<Activity> activities,
                             IContentRepository<Subject> subjects,
                             IContentRepository<Language> languages,
                             IContentRepository<Course> courses)
        {
            _groups = groups;
            _teachers = teachers;
            _students = students;
            _answers = answers;
            _activities = activities;
            _subjects = subjects;
            _languages = languages;
            _courses = courses;
        }

        public async Task<MasterResponse> GetMasterResponse(Guid groupId, string username, int session)
        {  
           var groupNameSubjectCourse = (await _groups.Find(b => b.Id == groupId))
                                      .Select(nameSubjectCourse => new
                                      {
                                          name = nameSubjectCourse.Name,
                                          subject = nameSubjectCourse.SubjectKey,
                                          course = nameSubjectCourse.Course,
                                          language = nameSubjectCourse.LanguageKey
                                      }).First();

            var name = (await _teachers.Find(b => b.Email == username)).Select(b => b.Name+" "+b.Surnames).FirstOrDefault();
            var students = (await _students.Find(b => b.GroupId == groupId));
            var quantity = await GetQuantityStudentsCompleteSession(students, session, groupNameSubjectCourse.course, groupNameSubjectCourse.subject, groupNameSubjectCourse.language);
            var activities = await GetActivities(session, groupNameSubjectCourse.course, groupNameSubjectCourse.subject, groupNameSubjectCourse.language);

            return new MasterResponse
            {
                GroupName = groupNameSubjectCourse.name.ToUpper(),
                SubjectName = groupNameSubjectCourse.subject.ToUpper(),
                UserName = name.ToUpper(),
                StudentsCount = students.Count,
                Session = session,
                Course = groupNameSubjectCourse.course,
                QuantityStudentAdvance = quantity,
                Activities = activities
            };
        }

        private async Task<List<string>> GetActivities(int session, int course, string subjectKey, string languageKey)
        {
            var subjectId = (await _subjects.Find(b => b.Key == subjectKey)).Select(b=>b.Id).First();
            var languageId = (await _languages.Find(b => b.Code == languageKey)).Select(b => b.Id).First();
            var courseId = (await _courses.Find(b => b.Number == course)).Select(b => b.Id).First();

            var activities = (await _activities.Find(b => b.SubjectId == subjectId
                                            && b.LanguageId == languageId
                                            && b.CourseId == courseId
                                            && b.Session == session))
                                            .OrderByDescending(b => b.Difficulty)
                                            .GroupBy(b=>b.Stage);
            
            var listActivites = new List<string>();
            foreach (var activity in activities)
            {
                listActivites.Add(activity.Select(b => b.ShortDescription).First());               
            }

            return listActivites;
        }

        private async Task<int> GetQuantityStudentsCompleteSession(List<StudentGroup> students, int session, int course, string subjectKey, string languageKey)
        {
            var studentsUsers = students.Select(b => b.UserName).ToList();
            var answers = await _answers.Find((b) => studentsUsers.Contains(b.UserName)
                                                  && b.SubjectKey == subjectKey
                                                  && b.LanguageKey == languageKey
                                                  && b.Course == course
                                                  && b.Session == session);            

            if (!answers.Any()) return 0;

            else
            {
                var quantity = 0;
                foreach (var student in studentsUsers)
                {
                    var studentAnswers = answers.Where(b => b.UserName == student).OrderByDescending(b=>b.CreatedAt);

                    var studentAnwserNotRepeatStage = new List<StudentAnswer>();
                    foreach (var stdAnswer in studentAnswers)
                    {
                        if (studentAnwserNotRepeatStage.Where(b => b.Stage == stdAnswer.Stage).Count() == 0)
                            studentAnwserNotRepeatStage.Add(stdAnswer);
                    }

                    var sessionFactory = new CompleteSessionCalculatorFactory();
                    var sesssionCalculator = sessionFactory.Create(subjectKey);
                    var passesAllStagesSession = sesssionCalculator.CompletedSession(studentAnwserNotRepeatStage);

                    quantity += (passesAllStagesSession) ? 1 : 0;
                }
                return quantity;
            }            
        }
    }
}

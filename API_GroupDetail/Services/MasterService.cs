using API_GroupDetail.DB.Entities;
using API_GroupDetail.DB.Entities.Dto;
using API_GroupDetail.DB.Repository;
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


        public MasterService(ISchoolsRepository<Group> groups, 
                             ISchoolsRepository<Teacher> teachers,
                             ISchoolsRepository<StudentGroup> students)
        {
            _groups = groups;
            _teachers = teachers;
            _students = students;
        }

        public async Task<MasterResponse> GetMasterResponse(Guid groupId, string username)
        {  
           var groupNameAndSubject = (await _groups.Find(b => b.Id == groupId))
                                      .Select(nameAndSubject => new
                                      {
                                          name = nameAndSubject.Name,
                                          subject = nameAndSubject.SubjectKey
                                      }).First();

            var name = (await _teachers.Find(b => b.Email == username)).Select(b => b.Name+" "+b.Surnames).FirstOrDefault();
            var students = (await _students.Find(b => b.GroupId == groupId));

            return new MasterResponse
            {
                    GroupName = groupNameAndSubject.name.ToUpper(),
                  SubjectName = groupNameAndSubject.subject.ToUpper(),
                     UserName = name.ToUpper(),
                StudentsCount = students.Count
            };
        }
    }
}

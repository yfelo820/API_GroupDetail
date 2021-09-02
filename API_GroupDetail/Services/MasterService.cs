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

        public MasterService(ISchoolsRepository<Group> groups, ISchoolsRepository<Teacher> teachers)
        {
            _groups = groups;
            _teachers = teachers;
        }

        public async Task<MasterResponse> GetMasterResponse(Guid groupId, string username)
        {    
            return (MasterResponse)(await _groups.Find(b => b.Id == groupId)).Select(async teacher =>
            {
                var teacherName = (await _teachers.Find(b => b.Email == username)).Select(b => b.Name + " " + b.Surnames).First();
                return new MasterResponse
                {
                    UserName = teacherName,
                   GroupName = teacher.Name,
                 SubjectName = teacher.SubjectKey                    
                };
            });  /*

            var groupNameAndSubject = (await _groups.Find(b => b.Id == groupId))
                                      .Select(nameAndSubject => new
                                      {
                                          name = nameAndSubject.Name,
                                          subject = nameAndSubject.SubjectKey
                                      }).First();

            return new MasterResponse
            {
                GroupName = groupNameAndSubject.name,
                SubjectName = groupNameAndSubject.subject.ToUpper(),
                UserName = "Yosmani R. Claro Merino"
            };*/
        }
    }
}

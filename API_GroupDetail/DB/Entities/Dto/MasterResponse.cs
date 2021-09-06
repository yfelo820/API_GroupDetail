using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_GroupDetail.DB.Entities.Dto
{
    public class MasterResponse
    {
        public string GroupName { get; set; }
        public string UserName { get; set; }
        public string SubjectName { get; set; }
        public int StudentsCount { get; set; }
        public int Session { get; set; }
        public int Course { get; set; }
        public int QuantityStudentAdvance { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_GroupDetail.DB.Entities
{
    public class Teacher : BaseEntity
    {
        public string Name { get; set; }
        public string Surnames { get; set; }
        public string Email { get; set; }
        public string SchoolId { get; set; }
        public DateTime? LastLoggedIn { get; set; }
    }
}

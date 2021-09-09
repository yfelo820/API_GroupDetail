using API_GroupDetail.DB.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_GroupDetail.DB.Context
{
    public class SchoolsDbContext : DbContext
    {
        public SchoolsDbContext(DbContextOptions<SchoolsDbContext> options): base(options) { }

        public DbSet<Teacher> Teacher { get; set; }        
        public DbSet<Group> Group { get; set; }
        public DbSet<StudentGroup> StudentGroup { get; set; }
        public DbSet<StudentProgress> StudentProgress { get; set; }
        public DbSet<StudentAnswer> StudentAnswer { get; set; }  
    }
}

using API_GroupDetail.DB.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_GroupDetail.DB.Context
{
    public class ContentDbContext : DbContext
    {
        public ContentDbContext(DbContextOptions<ContentDbContext> options): base(options)  {  }

        public DbSet<Activity> Activity { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<Language> Language { get; set; }
        public DbSet<Course> Course { get; set; }
    }
}

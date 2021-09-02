using API_GroupDetail.DB.Entities;
using API_GroupDetail.DB.Repository;
using API_GroupDetail.Interfaces;
using API_GroupDetail.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_GroupDetail.Middleware
{
    public static class IoC
    {

        public static IServiceCollection AddDependency(this IServiceCollection services)
        {
            services.AddTransient<ISchoolsRepository<Teacher>, SchoolsRepository<Teacher>>();
            services.AddTransient<ISchoolsRepository<Group>, SchoolsRepository<Group>>();
            services.AddTransient<ISchoolsRepository<StudentAnswer>, SchoolsRepository<StudentAnswer>>();
            services.AddTransient<ISchoolsRepository<StudentGroup>, SchoolsRepository<StudentGroup>>();
            services.AddTransient<ISchoolsRepository<StudentProgress>, SchoolsRepository<StudentProgress>>();
            services.AddTransient<IMasterService, MasterService>();            
            return services;

        }

    }
}

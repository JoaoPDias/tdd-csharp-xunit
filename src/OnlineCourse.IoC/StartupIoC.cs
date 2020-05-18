using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineCourse.Data.Contexts;
using OnlineCourse.Data.Repositories;
using OnlineCourse.Domain.Base;
using OnlineCourse.Domain.Courses;
using System;

namespace OnlineCourse.IoC
{
    public class StartupIoC
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration) {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration["ConnectionString"]));
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(ICourseRepository), typeof(CourseRepository));
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            services.AddScoped<CourseService>();
        }
    }
}

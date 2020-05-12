using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineCourse.Data.Contexts;
using System;

namespace OnlineCourse.IoC
{
    public class StartupIoC
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration) {
            services.AddDbContext<ApplicationDbContext>();
        }
    }
}

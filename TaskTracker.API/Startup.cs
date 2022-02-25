using Microsoft.EntityFrameworkCore;
using TaskTracker.API.Filters;
using TaskTracker.DataAccess;
using TaskTracker.Logic.Interfaces;
using TaskTracker.Logic.Services;

namespace TaskTracker.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<DatabaseContext>(options =>
               options.UseLazyLoadingProxies()
                      .UseNpgsql(Configuration.GetConnectionString("Main")));

            services.AddControllers(options =>
                options.Filters.Add<HttpResponseExceptionFilter>());

            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen();
            services.AddTransient<IProjectManager, ProjectManager>();
            services.AddTransient<IAssignmentManager, AssignmentManager>();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
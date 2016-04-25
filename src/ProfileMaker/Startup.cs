using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProfileMaker.Services;
using Microsoft.Extensions.PlatformAbstractions;
using ProfileMaker.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using AutoMapper;
using ProfileMaker.ViewModels;
using ProfileMaker.Models.Seeds;
using ProfileMaker.Controllers.Api;

namespace ProfileMaker
{
    public class Startup
    {
        public static IConfigurationRoot Configuration;
        public Startup(IApplicationEnvironment appEnv)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(appEnv.ApplicationBasePath)
                .AddJsonFile("config.json")
                .AddEnvironmentVariables();
            
            Configuration = builder.Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .AddJsonOptions(opt =>
                {
                    //Set lower case in Json Api for better include javascript in Api
                    opt.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                });

            services.AddLogging();

            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<WorldContext>()
                .AddDbContext<ProfileMakerContext>();

            services.AddScoped<CoordService>();
            //Add data to Database
            services.AddTransient<WorldContextSeedData>();
            services.AddTransient<ProfileMakerContextSeedData>();

            services.AddScoped<IWorldRepository, WorldRepository>();
            services.AddScoped<IProfileMakerRepository, ProfileMakerRepository>();

#if DEBUG
            services.AddScoped<IMailService, DebugMailService>();
#else
            services.AddScoped<IMailService, RealMailService>();
#endif
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, WorldContextSeedData seederWorld, ProfileMakerContextSeedData seederProfileMaker , ILoggerFactory loggerFactory)
        {
            loggerFactory.AddDebug(LogLevel.Warning);

            app.UseStaticFiles();

            Mapper.Initialize(config =>
            {
                //world
                config.CreateMap<Trip, TripViewModel>().ReverseMap();
                config.CreateMap<Stop, StopViewModel>().ReverseMap();

                //ProfileMaker
                config.CreateMap<ProfileUser, ProfileUserViewModel>().ReverseMap();
                config.CreateMap<OtherCourse, OtherCourseViewModel>().ReverseMap();

            });

            app.UseMvc(config =>
            {
                config.MapRoute(
                    name: "Default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "App", action = "Index" }
                    );
            });

            seederWorld.EnsureSeedData();
            seederProfileMaker.EnsureSeedData();
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}

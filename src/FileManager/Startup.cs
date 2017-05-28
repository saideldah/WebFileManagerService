using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FileManager
{
    public class Startup
    {
        #region snippet1
        public void ConfigureServices(IServiceCollection services)
        {
            // Angular's default header name for sending the XSRF token.
            services.AddAntiforgery(options => options.HeaderName = "X-XSRF-TOKEN");

            services.AddMvc();
        }
        #endregion

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
            IHostingEnvironment env,
            ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(LogLevel.Debug);
            loggerFactory.AddDebug();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }
    }
}


//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Logging;

//namespace FileManager
//{
//    public class Startup
//    {
//        public Startup(IHostingEnvironment env)
//        {
//            var builder = new ConfigurationBuilder()
//                .SetBasePath(env.ContentRootPath)
//                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
//                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

//            if (env.IsEnvironment("Development"))
//            {
//                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
//                builder.AddApplicationInsightsSettings(developerMode: true);
//            }

//            builder.AddEnvironmentVariables();
//            Configuration = builder.Build();
//        }

//        public IConfigurationRoot Configuration { get; }

//        // This method gets called by the runtime. Use this method to add services to the container
//        public void ConfigureServices(IServiceCollection services)
//        {
//            // Add framework services.
//            services.AddApplicationInsightsTelemetry(Configuration);

//            services.AddMvc();
//        }

//        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
//        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
//        {
//            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
//            loggerFactory.AddDebug();

//            app.UseApplicationInsightsRequestTelemetry();

//            app.UseApplicationInsightsExceptionTelemetry();

//            app.UseMvc();
//        }
//    }
//}

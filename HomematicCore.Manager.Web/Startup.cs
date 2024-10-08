using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using HomematicCore.Homematic.Client.Factories;
using HomematicCore.Homematic.Daemon;
using HomematicCore.Homematic.Daemon.Constants;
using AutoMapper;
using HomematicCore.Homematic.Daemon.Profiles;
using System.Linq;

namespace HomematicCore.Manager.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddMemoryCache();

            services.AddSingleton(new DaemonConfiguration("black-pearl", CommonPorts.HomematicIp));
            services.AddSingleton<IHomematicClientFactory>(_ => HomematicClientFactory.Default);
            services.AddTransient<IHomematicDaemon, HomematicDaemon>();

            services.AddAutoMapper(typeof(EntityDomainProfile));

            // Register view models 
            var assembly = GetType().Assembly;
            var viewModels = assembly.GetTypes()
                                     .Where(t => t.Namespace.Contains("ViewModels") && !t.IsAbstract);
            
            foreach (var vm in viewModels)
            {
                services.AddTransient(vm);
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}

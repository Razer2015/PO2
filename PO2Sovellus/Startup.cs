using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using PO2Sovellus.Services;
using PO2Sovellus.Models;

namespace PO2Sovellus
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        private void ConfigureRoutes(IRouteBuilder routeBuilder) {
            routeBuilder.MapRoute(
                "Oletus",
                "{controller=Etusivu}/{action=Index}/{id?}" // URL pattern
                //new { controller = "Etusivu", action = "Index" },
                //new { id = "7" }
            );
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSingleton(Configuration);
            services.AddSingleton<ITervehtija, Tervehtija>();
            services.AddScoped<IData<Henkilo>, InMemoryHenkiloData>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, ITervehtija tervehtija)
        {
            loggerFactory.AddConsole();

            //app.UseDefaultFiles(); // Käyttää index.html tiedostoa defaulttina
            //app.UseStaticFiles(); // Käyttää wwwroot kansion tiedostoja
            app.UseFileServer(); // Korvaa edelliset

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else {
                app.UseExceptionHandler(new ExceptionHandlerOptions {
                    ExceptionHandlingPath = "/virhe"
                    //ExceptionHandler = context => context.Response.WriteAsync("Hupsista!")
                });
            }

            app.UseMvc(ConfigureRoutes);

            app.Run(context =>
            {
                context.Response.ContentType = "text/html; charset=utf-8";
                return context.Response.WriteAsync("Sivua ei löytynyt.");
            });

            //app.UseWelcomePage(new WelcomePageOptions { Path = "/welcome" });

            //app.Run(async (context) =>
            //{
            //    var message = tervehtija.GetTervehdys();
            //    //var message = Configuration["Tervehdys"];
            //    await context.Response.WriteAsync(message);
            //    //await context.Response.WriteAsync("Hello World!!!");
            //});
        }

        public Startup(IHostingEnvironment env) {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(env.ContentRootPath);
            builder.AddJsonFile("appsettings.json");
            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }
    }
}

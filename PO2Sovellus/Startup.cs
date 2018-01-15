using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace PO2Sovellus
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSingleton(Configuration);
            services.AddSingleton<ITervehtija, Tervehtija>();
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

            //app.UseWelcomePage(new WelcomePageOptions { Path = "/welcome" });

            //app.Run(async (context) =>
            //{
            //    var message = tervehtija.GetTervehdys();
            //    //var message = Configuration["Tervehdys"];
            //    await context.Response.WriteAsync(message);
            //    //await context.Response.WriteAsync("Hello World!!!");
            //});

            app.UseMvcWithDefaultRoute();
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

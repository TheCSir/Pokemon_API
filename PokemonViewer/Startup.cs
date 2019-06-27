using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PokemonViewer.Services.ModelBuilders.PokemonBuilder;
using PokemonViewer.Services.ModelBuilders.PokemonBuilder.ConcreteBuilders;
using PokemonViewer.Services.ModelBuilders.SimplifiedPokemonBuilder;
using PokemonViewer.Services.ModelBuilders.SimplifiedPokemonBuilder.ConcreteBuilders;

namespace PokemonViewer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddResponseCompression();

            // Specify witch implementation to inject to current scope
            services.AddScoped<IPokemonBuilder, PokemonFromApi>();
            services.AddScoped<ISimplifiedPokemonBuilder, SimplifiedPokemonFromApi>();
        }

        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // unhandled exception middleware
                app.UseExceptionHandler("/Error");
                // error with status code middleware
                app.UseStatusCodePagesWithReExecute("/Error/{0}");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    "default",
                    "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
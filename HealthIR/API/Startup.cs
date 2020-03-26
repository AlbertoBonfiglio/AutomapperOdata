using AutoMapper;
using AutoMapper.EquivalencyExpression;
using HealthIR.Core.Data;
using HealthIR.Core.OData;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;

namespace HealthIR {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {
            this.ConfigureOptions (services);

            this.ConfigurePersistentStorageServices (services);

            this.ConfigureCORSServices (services);


            this.ConfigureAutomapper(services);

            services.AddResponseCompression(options => { options.Providers.Add<GzipCompressionProvider>(); });

            this.ConfigureMVCandRouting(services); 

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, HealthEdmModelBuilder modelBuilder, IWebHostEnvironment env) {
            app.UsePathBase ("/");

            // Enables CORS
            app.UseCors ("CorsPolicy");

            // Dev vs runtime settings
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage ();
            } else {
                app.UseExceptionHandler ("/Error");
                app.UseHsts (); // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            }

            app.UseHttpsRedirection ();
            app.UseResponseCompression();

            // this section is To serve the manifest data to work as a PWA
            FileExtensionContentTypeProvider provider = new FileExtensionContentTypeProvider ();
            provider.Mappings[".webmanifest"] = "application/manifest+json";
            app.UseStaticFiles (new StaticFileOptions () { ContentTypeProvider = provider });
            if (!env.IsDevelopment ()) {
                app.UseSpaStaticFiles (new StaticFileOptions () { ContentTypeProvider = provider });
            }

            app.UseRouting ();
            app.UseMvc(routeBuilder => {
                //routeBuilder.EnableDependencyInjection();
                routeBuilder.Select().Expand().Filter().OrderBy().MaxTop(100).Count().SkipToken();
                routeBuilder.MapODataServiceRoute(
                    routeName:"api", routePrefix: "api", 
                    model: modelBuilder.GetEdmModel(app.ApplicationServices));
                routeBuilder.EnableDependencyInjection();
            });

        }

        #region Configurations
       
       private void ConfigureAutomapper(IServiceCollection services) {
            services.AddAutoMapper((serviceProvider, automapper) => {
                automapper.AddCollectionMappers();
                automapper.UseEntityFrameworkCoreModel<HealthDbContext>(serviceProvider);
            }, typeof(HealthDbContext).Assembly);

       }

        private void ConfigureOptions (IServiceCollection services) {
            services.AddOptions (); // needed to set up the framework
        }

        private void ConfigureCORSServices (IServiceCollection services) {
            // Cors
            services.AddCors (options => {
                options.AddPolicy ("CorsPolicy",
                    builder => {
                        builder.AllowAnyOrigin () //TODO Eventually limit the origins to prevent cross site attacks
                            .AllowAnyHeader ()
                            .AllowAnyMethod ()
                            .SetPreflightMaxAge (TimeSpan.FromSeconds (2520));
                    });
            });
        }
  
  
        private void ConfigurePersistentStorageServices (IServiceCollection services) {
            // Db Context
            services.AddDbContext<HealthDbContext> ( 
                options => {
                    options.UseLazyLoadingProxies()
                        //.UseMySql (dbConnString);  
                        .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=health;Integrated Security=True");
                }
            );
        }

        private void ConfigureMVCandRouting(IServiceCollection services){
            services.AddOData();
            services.AddTransient<HealthEdmModelBuilder>();
            // Configures MVC
            services.AddMvc(opt => { opt.EnableEndpointRouting = false;  })
                .SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_3_0)
                .AddNewtonsoftJson();
            }

        #endregion


    }

}
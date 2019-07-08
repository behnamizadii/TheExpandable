using System;
using System.IO;
using System.Reflection;
using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TheExpandable.DataAccess;
using TheExpandable.StoreApi.GraphQL;

namespace TheExpandable.StoreApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration{ get; set; }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(c => c.AddPolicy("CorsPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }));
            services.AddSwaggerGen(setupAction =>
            {
                setupAction.SwaggerDoc("LibraryOpenAPISpecification", 
                    new Microsoft.OpenApi.Models.OpenApiInfo()
                    {
                        Title = "Library API",
                        Version = "1"
                    });
                
                var xmlCommentsFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentsFile);
                
                setupAction.IncludeXmlComments(xmlCommentsFullPath);
            });
            services.AddTransient<IItemRepository, ItemRepository>();
            services.AddTransient<StoreDataContext>();
            services.AddMvc();
            services.AddScoped<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));
            services.AddScoped<ItemQuery>();
            services.AddScoped<StoreSchema>();
            
            services.AddGraphQL(o => { o.ExposeExceptions = true; })
                .AddGraphTypes(ServiceLifetime.Scoped);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        { 
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseStaticFiles();
            app.UseSwagger();
            app.UseSwaggerUI(setupAction =>
            {
                setupAction.SwaggerEndpoint("/swagger/LibraryOpenAPISpecification/swagger.json", "Library API");
                setupAction.RoutePrefix = ""; // this makes the swagger to be accessible from root/index.html
            });
            app.UseGraphQL<StoreSchema>();
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());
            app.UseMvc();
        }
    }
}

using System;
using Api.App_Start;
using EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace Api
{
	public partial class Startup
	{
        private readonly bool showSwagger;

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
            this.showSwagger = this.Configuration.GetValue<bool>("WebAPI:ShowSwagger");
        }


        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();

            services.AddHealthChecks();
            services.AddResponseCompression();

            services.AddAntiforgery();


            //this.BuildAppConfiguration(services);
            /*
            if (this.showSwagger)
            {
                // Register the Swagger services
                services.AddSwaggerDocument(config =>
                {
                 
                    config.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("JWT"));

                    config.PostProcess = document =>
                    {
                        document.Info.Version = "1.0.0";
                        document.Info.Title = "My Salesman - API";
                        document.Schemes = new List<OpenApiSchema>
                        {
                            OpenApiSchema.Https
                        };
                    };
                });
            }*/

            services.AddAutoMapper(typeof(MapperProfile));

            services.AddDbContext<TodoContext>(opt => opt.UseInMemoryDatabase("todo"));

            services.AddMvc();

            this.ConfigureDependencyInjection(services);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Ingenum.Case.Api", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, TodoContext context)
        {
         if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ingenum.Case.Api v1"));
            }

            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod()
            );

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health");
            });

            app.UseResponseCompression();

            /*if (this.showSwagger)
            {
                app.UseOpenApi();
                app.UseSwaggerUi3();
            }
            */

            //var context = app.ApplicationServices.GetService<TodoContext>();
            AddTestData(context);

           // app.UseMvc();
        }

        private static void AddTestData(TodoContext context)
        {
            var testJob1 = new Model.Database.Job
            {
                Title = "blabla",
                Description = "aaaa"
            };

            context.Jobs.Add(testJob1);

            var testBoard1 = new Model.Database.Board
            {
                Label = "Todo"
            };

            context.Boards.Add(testBoard1);

            context.SaveChanges();
        }

    }
}


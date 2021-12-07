using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Musical_Quiz.Data;
using Musical_Quiz.Services;
using System;
using System.IO;
using System.Reflection;

namespace Musical_Quiz
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddControllers();

            #region Swagger Documentation
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Musical Quiz API",
                        Description = "An API created to store the funniest musical quiz ever!",
                        Contact = new OpenApiContact
                        {
                            Name = "Thales Ribeiro",
                            Email = "codethales@gmail.com",
                            Url = new Uri("https://codethales.github.io/")
                        },
                        License = new OpenApiLicense
                        {
                            Name = "MIT License",
                            Url = new Uri("https://opensource.org/licenses/MIT")
                        },
                        Version = "v1" 
                    });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = $"{Path.Combine(AppContext.BaseDirectory, xmlFile)}";
                c.IncludeXmlComments(xmlPath);
            });            
            #endregion

            services.AddDbContext<Context>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("MusicalQuiz"))
            );

            #region Services Dependency Injection
            services.AddTransient<IOptionService, OptionService>();
            services.AddTransient<IPlayerAnswersService, PlayerAnswersService>();
            services.AddTransient<IPlayerService, PlayerService>();
            services.AddTransient<IQuestionService, QuestionService>();
            services.AddTransient<IQuizService, QuizService>();
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Musical_Quiz v1"));
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

using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Context;
using WebApplication3.Models.Quiz;
using WebApplication3.Repository.Answer;
using WebApplication3.Repository.Question;
using WebApplication3.Repository.Quiz;
using WebApplication3.Repository.Score;
using WebApplication3.Services.Answer;
using WebApplication3.Services.Question;
using WebApplication3.Services.Quiz;
using WebApplication3.Services.Score;

namespace WebApplication3
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
            services.AddDbContext<AppDbContext>(
                options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApplication3", Version = "v1" });
            });
            services.AddTransient<IQuizRepository, QuizRepository>();
            services.AddTransient<IQuizService, QuizService>();

            services.AddTransient<IQuestionRepository, QuestionRepository>();
            services.AddTransient<IQuestionService, QuestionService>();

            services.AddTransient<IAnswerRepository, AnswerRepository>();
            services.AddTransient<IAnswerService, AnswerService>();

            services.AddTransient<IScoreRepository, ScoreRepository>();
            services.AddTransient<IScoreService, ScoreService>();

            services.AddAutoMapper(cfg => cfg.AddProfile<QuizMapperProfile>());

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApplication3 v1"));
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

using BLL;
using BLL.Mapper;
using AutoMapper;
using DAL.Repositorys;
using Core.Interfaces.IBLL;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Core.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.SwaggerUI;
using Microsoft.Extensions.DependencyInjection;

namespace ArtHoseWeb
{
    public static class AplicationServiceExtensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IGroupRepository, GroupRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IStudentGroupRepository, StudentGroupRepository>();
            services.AddScoped<ITeacherRepository, TeacherRepository>();
            services.AddScoped<IExpenseRepository, ExpenseRepository>();

        }

        public static void AddBLServices(this IServiceCollection services)
        {
            services.AddScoped<IStudentBL, StudentBL>();
            services.AddScoped<IGroupBL, GroupBL>();
            services.AddScoped<ITeacherBL, TeacherBL>();
            services.AddScoped<IPaymentBL, PaymentBL>();
            services.AddScoped<IExpenseBL, ExpenseBL>();

        }

        public static void AddMapper(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        public static void AddSwaggerDoc(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1.0", new OpenApiInfo() { Title = "BetConstruct.Stat.Commerce.API", Version = "0.0.1" });
            });
        }

        public static void UseSwaggerDoc(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1.0/swagger.json", $"{env.EnvironmentName}");
                c.DocExpansion(DocExpansion.None);
            });
        }

        public static void UpdateDatabase(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            using var context = serviceScope.ServiceProvider.GetService<DbContext>();
            context.Database.Migrate();
        }
    }
}

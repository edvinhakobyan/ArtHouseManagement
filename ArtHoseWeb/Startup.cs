using DB;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using GenericRepository.Abstarction;
using Microsoft.EntityFrameworkCore;
using GenericRepository.Implementation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ArtHoseWeb
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
            services.AddControllers().AddJsonOptions(opt =>
            {
                //opt.JsonSerializerOptions.IgnoreNullValues = true;
                //opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });
            services.AddSwaggerDoc();
            services.AddMapper();
            services.AddScoped<DbContext>(a => new ApplicationDbContext(Configuration["ConnectionString"]));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddRepositories();
            services.AddBLServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseSwaggerDoc(env);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UpdateDatabase();
        }
    }
}

using BLL;
using Core.Interfaces.IBLL;
using Core.Interfaces.IRepositories;
using DAL.Repositorys;
using DbLayer;
using GenericRepository.Abstarction;
using GenericRepository.Implementation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;

namespace NASTRAN.Pad
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var services = new ServiceCollection();

            ConfigureServices(services);

            MainForm form = null;
            using var serviceProvider = services.BuildServiceProvider();
            {
                form = serviceProvider.GetRequiredService<MainForm>();
            }
            Application.Run(form);
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<MainForm>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<DbContext, ApplicationDbContext>();
            services.AddDb(@"G:\W_C#_works\-00000-\Nas.Pad_Sql\DB\Database\NasPadDB.mdf");
            services.MigrateDb();



            services.AddScoped<IGridRepository, GridRepository>();
  
            services.AddScoped<IElementRepository, ElementRepository>();
            services.AddScoped<ICbarRepository, CbarRepository>();
            services.AddScoped<ICquad4Repository, Cqud4Repository>();
            services.AddScoped<ICtria3Repository, Ctria3Repository>();







        }

        public static void AddDb(this IServiceCollection services, string connectinString)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer($@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={connectinString};Integrated Security=true");
            });
        }

        private static void MigrateDb(this IServiceCollection services)
        {
            using var serviceScope = services.BuildServiceProvider().CreateScope();
            serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>().Database.Migrate();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BloodBank.Ui
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //var host = CreateHostBuilder().Build();
            //ServiceProvider = host.Services;
            //AppContext SqlServerContext = new AppContext();

            //try
            //{

            //    SqlServerContext = ServiceProvider.GetRequiredService<AppContext>();
            //    SqlServerContext.Database.Migrate();

            //    Seeds.SeedAsync(SqlServerContext);
            //}
            //catch (Exception ex)
            //{

            //    var logger = ServiceProvider.GetRequiredService<ILogger<Program>>();
            //    logger.LogError(ex, "An error occured during migration");
            //}

            ////Application.Run(new View.Bank.IndexView(SqlServerContext));
            //Application.Run(new View.Account.LoginView(SqlServerContext));

            //Application.Run(new MainView());

            Application.Run(new MainForm());
        }

        public static IServiceProvider ServiceProvider { get; private set; }
        //static IHostBuilder CreateHostBuilder()
        //{
        //    var con = ConfigurationManager.AppSettings["SqlServerConnectionString"];
        //    return Host.CreateDefaultBuilder()
        //        .ConfigureServices((context, services) =>
        //        {
        //            services.AddScoped<AppContext>();
        //            //services.AddScoped<GoogleDriveSevieces>();

        //            services.AddDbContext<AppContext>(options =>
        //            {
        //                options.UseSqlServer(DefaultConnection);
        //            });

        //            services.AddTransient<MainView>();
        //        });
        //}

        //const string DefaultConnection = "Server=DESKTOP-I3551M3\\SQLEXPRESS; Database=Rada.Hr.Winform; User=sa; trustServerCertificate=true; Trusted_Connection=true; ConnectRetryCount=0;MultipleActiveResultSets=true ;Password=!QA2ws3ed; Integrated security=False;Encrypt=False;";

        const string DefaultConnection = "Server=.; Database=Rada.Hr.Winform; User=sa; trustServerCertificate=true; Trusted_Connection=true; ConnectRetryCount=0;MultipleActiveResultSets=true ;Password=!QA2ws3ed; Integrated security=False;Encrypt=False;";

    }
}


using Microsoft.Extensions.Configuration;
using Microsoft.UI.Xaml;
using System;

namespace AegisPass
{
    public partial class App : Application
    {
        public static IConfiguration Configuration { get; private set; } = null!;

        public App()
        {
            this.InitializeComponent();

            var builder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            Configuration = builder.Build();

            var tenant = Configuration["AzureAdB2C:TenantId"];
            System.Diagnostics.Debug.WriteLine($"Loaded TenantId: {tenant}");

            using var db = new AppDbContext();
            db.Database.EnsureCreated();
        }

        protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            m_window = new MainWindow();
            m_window.Activate();
        }

        private Window? m_window;
    }
}

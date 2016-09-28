namespace SalesInventory.BootStrapper
{

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            GlobalConfiguration.Configuration.UseSqlServerStorage("Hangfire");
            app.UseHangfireDashboard();
            app.UseHangfireServer();
            HangfireQueue.EnqueueJobs();
        }
    }
}

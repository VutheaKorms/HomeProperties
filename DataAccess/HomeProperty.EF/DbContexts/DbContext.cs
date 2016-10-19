using HomeProperty.App;
using HomeProperty.Contacts;
using HomeProperty.EF.App;
using HomeProperty.Error;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace HomeProperty.DbContexts {
    public class MainDbContext : IdentityDbContext<ApplicationUser> {
        public MainDbContext()
            : base("Name=HomePropertyDev", throwIfV1Schema: false) {
            Database.SetInitializer(new CreateDatabaseIfNotExists<MainDbContext>());
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Application> Applications { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<ErrorLog> ErrorLogs { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<MenuChildItem> MenuChildItems { get; set; }
        public DbSet<EmailType> EmailTypes { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<Package> Packages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new ApplicationConfig());
            modelBuilder.Configurations.Add(new LanguageConfig());
            modelBuilder.Configurations.Add(new ErrorLogConfig());
            modelBuilder.Configurations.Add(new ResourceConfig());
            modelBuilder.Configurations.Add(new MenuConfig());
            modelBuilder.Configurations.Add(new MenuItemConfig());
            modelBuilder.Configurations.Add(new MenuChildItemConfig());
            modelBuilder.Configurations.Add(new EmailTypeConfig());
            modelBuilder.Configurations.Add(new EmailConfig());
            modelBuilder.Configurations.Add(new PackageConfig());
        }

        public static MainDbContext Create() {
            return new MainDbContext();
        }
    }
}

using HomeProperty.App;
using HomeProperty.Contacts;
using HomeProperty.EF.App;
using HomeProperty.Error;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace HomeProperty.DbContexts
{
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
        public DbSet<Type> Types { get; set; }
        public DbSet<PropertyType> PropertyTypes { get; set; }
        public DbSet<PhoneType> PhoneTypes { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<AgentType> AgentTypes { get; set; }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Community> Communities { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Image> Images { get; set; }

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
            modelBuilder.Configurations.Add(new TypeConfig());
            modelBuilder.Configurations.Add(new PropertyTypeConfig());
            modelBuilder.Configurations.Add(new PhoneTypeConfig());
            modelBuilder.Configurations.Add(new PhoneConfig());
            modelBuilder.Configurations.Add(new LocationConfig());
            modelBuilder.Configurations.Add(new AgentTypeConfig());
            modelBuilder.Configurations.Add(new AgentConfig());
            modelBuilder.Configurations.Add(new CityConfig());
            modelBuilder.Configurations.Add(new StateConfig());
            modelBuilder.Configurations.Add(new CommunityConfig());
            modelBuilder.Configurations.Add(new PersonConfig());
            modelBuilder.Configurations.Add(new CompanyConfig());
            modelBuilder.Configurations.Add(new ImageConfig());
        }

        public static MainDbContext Create() {
            return new MainDbContext();
        }
    }
}

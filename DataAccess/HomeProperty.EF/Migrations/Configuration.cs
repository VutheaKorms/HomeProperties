namespace HomeProperty.Migrations {
    using HomeProperty.DbContexts;
    using System.Data.Entity.Migrations;

    /// <summary>
    /// Configuration 
    /// </summary>
    internal sealed class Configuration : DbMigrationsConfiguration<MainDbContext> {

        /// <summary>
        /// Primary constructor
        /// </summary>
        public Configuration() {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        /// <summary>
        /// Seeds application data 
        /// </summary>
        /// <param name="context"></param>
        protected override void Seed(MainDbContext context) {
            // Application
            Applications.SeedApplications(context);
            // Users
            Users.SeedUsers(context);
            // Languages
            Languages.SeedLanguages(context);
            // Menus
            Menus.SeedAllMenuItems(context);
        }
    }
}

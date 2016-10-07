using HomeProperty.DbContexts;
using HomeProperty.EF.App;
using System.Data.Entity.Migrations;
using System.Linq;

namespace HomeProperty.Migrations {
    public class Applications {
        public static void SeedApplications(MainDbContext context) {
            if (!context.Applications.Any()) {
                context.Applications.AddOrUpdate(
                    new Application { Name = "Web Application" },
                    new Application { Name = "Mobile Application" }
                    );
                context.SaveChanges();
            }
        }
    }
}

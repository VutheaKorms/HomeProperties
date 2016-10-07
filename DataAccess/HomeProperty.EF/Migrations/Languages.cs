using HomeProperty.App;
using HomeProperty.DbContexts;
using System.Data.Entity.Migrations;
using System.Linq;

namespace HomeProperty.Migrations {
    public class Languages {
        private static void SeedLanguage(MainDbContext context, string name, string locale) {
            if (!context.Languages.Any(x => string.Compare(x.Name, name, true) == 0)) {
                context.Languages.AddOrUpdate(
                 new Language { Name = name, Locale = locale });
            }
        }

        public static void SeedLanguages(MainDbContext context) {
            SeedLanguage(context, "English (US)", "en-US");
            SeedLanguage(context, "Khmer", "km-KH");
            context.SaveChanges();
        }
    }
}

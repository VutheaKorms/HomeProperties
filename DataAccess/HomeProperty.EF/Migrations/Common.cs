using HomeProperty.App;
using HomeProperty.DbContexts;
using HomeProperty.EF.App;
using System.Linq;

namespace HomeProperty.Migrations {
    public class Common {
        /// <summary>
        /// The DB context data member
        /// </summary>
        private static MainDbContext _context = new MainDbContext();

        // <summary>
        // The English language data member
        // </summary>
        public static Language EnglishLanguage {
            get {
                return _context.Languages
                     .FirstOrDefault(x => x.Locale == "en-US" && x.IsActive);
            }
        }

        // <summary>
        // The Khmer language property
        // </summary>
        public static Language KhmerLanguage {
            get {
                return _context.Languages
                    .FirstOrDefault(x => x.Locale == "km-KH" && x.IsActive);
            }
        }

        // <summary>
        // The web application property
        // </summary>
        public static Application WebApplication {
            get {
                return _context.Applications
                    .FirstOrDefault(x => x.Name == "Web Application" && x.IsActive);
            }
        }
    }
}

using HomeProperty.App;
using HomeProperty.Contacts;
using HomeProperty.DbContexts;
using System;
using System.Linq;

namespace HomeProperty.Fixtures {
    public static class TestData {
        private static MainDbContext context;

        public static Guid DefaultGuid = new Guid("00000000-0000-0000-0000-000000000000");

        public static MainDbContext Context {
            get { return context ?? new MainDbContext(); }
            set { context = value; }
        }

        static TestData() {
            context = new MainDbContext();
        }

        public static string ServiceUserName { get { return "sk172online@gmail.com"; } }
        public static string ServicePassword { get { return "aloha123"; } }
        public static string GrantType { get { return "password"; } }
        public static string ServiceEndPont { get { return "https://localhost:44300/"; } }
        public static string ServiceTokenEndPoint { get { return "https://localhost:44300/Token"; } }

        public static ApplicationUser User {
            get { return context.Users.FirstOrDefault(); }
        }

        public static Menu Menu {
            get {
                return Context.Menus.FirstOrDefault(x => x.IsActive);
            }
        }

        public static MenuItem MenuItem {
            get {
                return Context.MenuItems.FirstOrDefault(x => x.IsActive);
            }
        }

        public static Language Language {
            get {
                return Context.Languages.FirstOrDefault(x => x.IsActive);
            }
        }

        public static EmailType EmailType {
            get {
                return Context.EmailTypes.FirstOrDefault(x => x.IsActive);
            }
        }

    }
}

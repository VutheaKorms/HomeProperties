using HomeProperty.App;
using HomeProperty.DbContexts;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Linq;

namespace HomeProperty.Migrations {
    public class Users {

        public static void SeedUsers(MainDbContext context) {
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            if (!context.Users.Any(x => x.UserName == "admin@homeproperty.com")) {
                var adminUser = new ApplicationUser {
                    UserName = "admin@homeproperty.com",
                    PhoneNumber = "9808334732",
                    Email = "admin@homeproperty.com"
                };
                userManager.Create(adminUser, "Aloha123");
                context.SaveChanges();
            }

            if (!context.Users.Any(x => x.UserName == "user@homeproperty.com")) {
                var borrower = new ApplicationUser {
                    UserName = "user@homeproperty.com",
                    PhoneNumber = "9808334732",
                    Email = "user@homeproperty.com"
                };
                userManager.Create(borrower, "Aloha123");
                context.SaveChanges();
            }

            if (!context.Users.Any(x => x.UserName == "serviceaccount@gmail.com")) {
                var borrower = new ApplicationUser {
                    UserName = "serviceaccount@gmail.com",
                    PhoneNumber = "9808334732",
                    Email = "serviceaccount@gmail.com"
                };
                userManager.Create(borrower, "Aloha123");
                context.SaveChanges();
            }
        }
    }
}

using HomeProperty.App;
using HomeProperty.DbContexts;
using System.Data.Entity.Migrations;
using System.Linq;

namespace HomeProperty.Migrations {
    public class Menus {

        /// <summary>
        /// Seeds all menu items.
        /// <param name="context">The database context.</param>
        /// </summary>
        public static void SeedAllMenuItems(MainDbContext context) {
            SeedMenus(context);
            // User navigation menus
            //SeedKhmerUserNavigationMenuItems(context);
            //SeedEnglishUserNavigationMenuItems(context);
            // Main navigation menus
            SeedEnglishMainNavBarMenuItems(context);
            //SeedKhmerMainNavBarMenuItems(context);
            // Languages
            //SeedLanguageMenuChildItems(context);

            //Admin menu
            //SeedEnglishAdminMenu(context);

            //Admin MenuChild
            //SeedEnglishAdminMenuChild(context);
        }

        /// <summary>
        /// Seeds customer service menu child items.
        /// </summary>
        /// <param name="context">The current database context.</param>
        //private static void SeedEnglishCustomerServiceMenuChildItems(MainDbContext context) {
        //    var menuItem = context.MenuItems
        //      .FirstOrDefault(x => x.Name == "Customer Service" && x.IsActive);
        //    if (menuItem == null) return;
        //    // Call Us
        //    if (!context.MenuChildItems.Any(x => x.Name == "Call Us"
        //        && x.MenuItemId == menuItem.Id && x.LanguageId == Common.EnglishLanguage.Id)) {
        //        context.MenuChildItems.AddOrUpdate(
        //            new MenuChildItem {
        //                Name = "Call Us",
        //                Url = "/customerService/callUs",
        //                MenuItemId = menuItem.Id,
        //                LanguageId = Common.EnglishLanguage.Id
        //            });
        //    }
        //    // Live Chat
        //    if (!context.MenuChildItems.Any(x => x.Name == "Live Chat"
        //       && x.MenuItemId == menuItem.Id && x.LanguageId == Common.EnglishLanguage.Id)) {
        //        context.MenuChildItems.AddOrUpdate(
        //            new MenuChildItem {
        //                Name = "Live Chat",
        //                Url = "/customerService/liveChat",
        //                MenuItemId = menuItem.Id,
        //                LanguageId = Common.EnglishLanguage.Id
        //            });
        //    }
        //    // Send Email
        //    if (!context.MenuChildItems.Any(x => x.Name == "Send Email"
        //       && x.MenuItemId == menuItem.Id && x.LanguageId == Common.EnglishLanguage.Id)) {
        //        context.MenuChildItems.AddOrUpdate(
        //            new MenuChildItem {
        //                Name = "Send Email",
        //                Url = "/customerService/sendEmail",
        //                MenuItemId = menuItem.Id,
        //                LanguageId = Common.EnglishLanguage.Id
        //            });
        //    }

        //    if (context.ChangeTracker.HasChanges())
        //        context.SaveChanges();
        //}

        /// <summary>
        /// Seeds customer service menu child items in Khmer language.
        /// </summary>
        /// <param name="context">The current database context.</param>
        //private static void SeedKhmerCustomerServiceMenuChildItems(MainDbContext context) {
        //    var menuItem = context.MenuItems
        //      .FirstOrDefault(x => x.Name == "សេវាអតិថិជន" && x.IsActive);
        //    if (menuItem == null) return;
        //    // Call Us
        //    if (!context.MenuChildItems.Any(x => x.Name == "ទាក់ទងតាមទូរស័ព"
        //        && x.MenuItemId == menuItem.Id && x.LanguageId == Common.KhmerLanguage.Id)) {
        //        context.MenuChildItems.AddOrUpdate(
        //            new MenuChildItem {
        //                Name = "ទាក់ទងតាមទូរស័ព",
        //                Url = "/customerService/callUs",
        //                MenuItemId = menuItem.Id,
        //                LanguageId = Common.KhmerLanguage.Id
        //            });
        //    }
        //    // Live Chat
        //    if (!context.MenuChildItems.Any(x => x.Name == "ជជែកតាមអីុនធឺណិត"
        //       && x.MenuItemId == menuItem.Id && x.LanguageId == Common.KhmerLanguage.Id)) {
        //        context.MenuChildItems.AddOrUpdate(
        //            new MenuChildItem {
        //                Name = "ជជែកតាមអីុនធឺណិត",
        //                Url = "/customerService/liveChat",
        //                MenuItemId = menuItem.Id,
        //                LanguageId = Common.KhmerLanguage.Id
        //            });
        //    }
        //    // Send Email
        //    if (!context.MenuChildItems.Any(x => x.Name == "ផ្ញើសារតាមអឺុមិល"
        //       && x.MenuItemId == menuItem.Id && x.LanguageId == Common.KhmerLanguage.Id)) {
        //        context.MenuChildItems.AddOrUpdate(
        //            new MenuChildItem {
        //                Name = "ផ្ញើសារតាមអឺុមិល",
        //                Url = "/customerService/sendEmail",
        //                MenuItemId = menuItem.Id,
        //                LanguageId = Common.KhmerLanguage.Id
        //            });
        //    }

        //    if (context.ChangeTracker.HasChanges())
        //        context.SaveChanges();
        //}

        /// <summary>
        /// Seeds support menu child items in Khmer.
        /// </summary>
        /// <param name="context">The current database context.</param>
        //private static void SeedKhmerSupportMenuChildItems(MainDbContext context) {
        //    var menuItem = context.MenuItems
        //      .FirstOrDefault(x => x.Name == "ជំនួយ" && x.IsActive);
        //    if (menuItem == null) return;
        //    // FAQs
        //    if (!context.MenuChildItems.Any(x => x.Name == "សំណួរនិងចំលើយ"
        //        && x.MenuItemId == menuItem.Id && x.LanguageId == Common.KhmerLanguage.Id)) {
        //        context.MenuChildItems.AddOrUpdate(
        //            new MenuChildItem {
        //                Name = "សំណួរនិងចំលើយ",
        //                Url = "/support/faqs",
        //                MenuItemId = menuItem.Id,
        //                LanguageId = Common.KhmerLanguage.Id
        //            });
        //    }
        //    // Submit a Ticket
        //    if (!context.MenuChildItems.Any(x => x.Name == "បង្កើតសំបុត្រសំុជំនួយ"
        //       && x.MenuItemId == menuItem.Id && x.LanguageId == Common.KhmerLanguage.Id)) {
        //        context.MenuChildItems.AddOrUpdate(
        //            new MenuChildItem {
        //                Name = "បង្កើតសំបុត្រសំុជំនួយ",
        //                Url = "/support/tickets",
        //                MenuItemId = menuItem.Id,
        //                LanguageId = Common.KhmerLanguage.Id
        //            });
        //    }
        //    // Call Us
        //    if (!context.MenuChildItems.Any(x => x.Name == "ទាក់ទងតាមទូរស័ព"
        //        && x.MenuItemId == menuItem.Id && x.LanguageId == Common.KhmerLanguage.Id)) {
        //        context.MenuChildItems.AddOrUpdate(
        //            new MenuChildItem {
        //                Name = "ទាក់ទងតាមទូរស័ព",
        //                Url = "/support/callUs",
        //                MenuItemId = menuItem.Id,
        //                LanguageId = Common.KhmerLanguage.Id
        //            });
        //    }
        //    // Live Chat
        //    if (!context.MenuChildItems.Any(x => x.Name == "ជជែកតាមអីុនធឺណិត"
        //       && x.MenuItemId == menuItem.Id && x.LanguageId == Common.KhmerLanguage.Id)) {
        //        context.MenuChildItems.AddOrUpdate(
        //            new MenuChildItem {
        //                Name = "ជជែកតាមអីុនធឺណិត",
        //                Url = "/support/liveChat",
        //                MenuItemId = menuItem.Id,
        //                LanguageId = Common.KhmerLanguage.Id
        //            });
        //    }
        //    // Send Email
        //    if (!context.MenuChildItems.Any(x => x.Name == "ផ្ញើសារតាមអឺុមិល"
        //       && x.MenuItemId == menuItem.Id && x.LanguageId == Common.KhmerLanguage.Id)) {
        //        context.MenuChildItems.AddOrUpdate(
        //            new MenuChildItem {
        //                Name = "ផ្ញើសារតាមអឺុមិល",
        //                Url = "/support/sendEmail",
        //                MenuItemId = menuItem.Id,
        //                LanguageId = Common.KhmerLanguage.Id
        //            });
        //    }

        //    if (context.ChangeTracker.HasChanges())
        //        context.SaveChanges();
        //}

        /// <summary>
        /// Seeds support menu child items.
        /// </summary>
        /// <param name="context">The current database context.</param>
        //private static void SeedEnglishSupportMenuChildItems(MainDbContext context) {
        //    var menuItem = context.MenuItems
        //      .FirstOrDefault(x => x.Name == "Support" && x.IsActive);
        //    if (menuItem == null) return;
        //    // FAQs
        //    if (!context.MenuChildItems.Any(x => x.Name == "FAQs"
        //        && x.MenuItemId == menuItem.Id && x.LanguageId == Common.EnglishLanguage.Id)) {
        //        context.MenuChildItems.AddOrUpdate(
        //            new MenuChildItem {
        //                Name = "FAQs",
        //                Url = "/support/faqs",
        //                MenuItemId = menuItem.Id,
        //                LanguageId = Common.EnglishLanguage.Id
        //            });
        //    }
        //    // Submit a Ticket
        //    if (!context.MenuChildItems.Any(x => x.Name == "Tickets"
        //       && x.MenuItemId == menuItem.Id && x.LanguageId == Common.EnglishLanguage.Id)) {
        //        context.MenuChildItems.AddOrUpdate(
        //            new MenuChildItem {
        //                Name = "Tickets",
        //                Url = "/support/tickets",
        //                MenuItemId = menuItem.Id,
        //                LanguageId = Common.EnglishLanguage.Id
        //            });
        //    }
        //    // Call Us
        //    if (!context.MenuChildItems.Any(x => x.Name == "Call Us"
        //        && x.MenuItemId == menuItem.Id && x.LanguageId == Common.EnglishLanguage.Id)) {
        //        context.MenuChildItems.AddOrUpdate(
        //            new MenuChildItem {
        //                Name = "Call Us",
        //                Url = "/support/callUs",
        //                MenuItemId = menuItem.Id,
        //                LanguageId = Common.EnglishLanguage.Id
        //            });
        //    }
        //    // Live Chat
        //    if (!context.MenuChildItems.Any(x => x.Name == "Live Chat"
        //       && x.MenuItemId == menuItem.Id && x.LanguageId == Common.EnglishLanguage.Id)) {
        //        context.MenuChildItems.AddOrUpdate(
        //            new MenuChildItem {
        //                Name = "Live Chat",
        //                Url = "/support/liveChat",
        //                MenuItemId = menuItem.Id,
        //                LanguageId = Common.EnglishLanguage.Id
        //            });
        //    }
        //    // Send Email
        //    if (!context.MenuChildItems.Any(x => x.Name == "Send Email"
        //       && x.MenuItemId == menuItem.Id && x.LanguageId == Common.EnglishLanguage.Id)) {
        //        context.MenuChildItems.AddOrUpdate(
        //            new MenuChildItem {
        //                Name = "Send Email",
        //                Url = "/support/sendEmail",
        //                MenuItemId = menuItem.Id,
        //                LanguageId = Common.EnglishLanguage.Id
        //            });
        //    }

        //    if (context.ChangeTracker.HasChanges())
        //        context.SaveChanges();
        //}

        /// <summary>
        /// Seeds message menu child items.
        /// </summary>
        /// <param name="context">The current database context.</param>
        //private static void SeedEnlgishMessageMenuChildItems(MainDbContext context) {
        //    var menuItem = context.MenuItems
        //       .FirstOrDefault(x => x.Name == "Message" && x.IsActive);
        //    if (menuItem == null) return;
        //    // Inbox
        //    if (!context.MenuChildItems.Any(x => x.Name == "Inbox"
        //       && x.MenuItemId == menuItem.Id && x.LanguageId == Common.EnglishLanguage.Id)) {
        //        context.MenuChildItems.AddOrUpdate(
        //            new MenuChildItem {
        //                Name = "Inbox",
        //                Url = "/message/inbox",
        //                MenuItemId = menuItem.Id,
        //                LanguageId = Common.EnglishLanguage.Id
        //            });
        //    }
        //    // Draft
        //    if (!context.MenuChildItems.Any(x => x.Name == "Draft"
        //       && x.MenuItemId == menuItem.Id && x.LanguageId == Common.EnglishLanguage.Id)) {
        //        context.MenuChildItems.AddOrUpdate(
        //            new MenuChildItem {
        //                Name = "Draft",
        //                Url = "/message/draft",
        //                MenuItemId = menuItem.Id,
        //                LanguageId = Common.EnglishLanguage.Id
        //            });
        //    }
        //    // Sent
        //    if (!context.MenuChildItems.Any(x => x.Name == "Sent"
        //       && x.MenuItemId == menuItem.Id && x.LanguageId == Common.EnglishLanguage.Id)) {
        //        context.MenuChildItems.AddOrUpdate(
        //            new MenuChildItem {
        //                Name = "Sent",
        //                Url = "/message/sent",
        //                MenuItemId = menuItem.Id,
        //                LanguageId = Common.EnglishLanguage.Id
        //            });
        //    }
        //    // Trash
        //    if (!context.MenuChildItems.Any(x => x.Name == "Trash"
        //       && x.MenuItemId == menuItem.Id && x.LanguageId == Common.EnglishLanguage.Id)) {
        //        context.MenuChildItems.AddOrUpdate(
        //            new MenuChildItem {
        //                Name = "Trash",
        //                Url = "/message/trash",
        //                MenuItemId = menuItem.Id,
        //                LanguageId = Common.EnglishLanguage.Id
        //            });
        //    }

        //    if (context.ChangeTracker.HasChanges())
        //        context.SaveChanges();
        //}

        /// <summary>
        /// Seeds message menu child items.
        /// </summary>
        /// <param name="context">The current database context.</param>
        //private static void SeedKhmerMessageMenuChildItems(MainDbContext context) {
        //    var menuItem = context.MenuItems
        //       .FirstOrDefault(x => x.Name == "សារ" && x.IsActive);
        //    if (menuItem == null) return;
        //    // Inbox
        //    if (!context.MenuChildItems.Any(x => x.Name == "ប្រអប់ទទួលសារ"
        //       && x.MenuItemId == menuItem.Id && x.LanguageId == Common.KhmerLanguage.Id)) {
        //        context.MenuChildItems.AddOrUpdate(
        //            new MenuChildItem {
        //                Name = "ប្រអប់ទទួលសារ",
        //                Url = "/message/inbox",
        //                MenuItemId = menuItem.Id,
        //                LanguageId = Common.KhmerLanguage.Id
        //            });
        //    }
        //    // Draft
        //    if (!context.MenuChildItems.Any(x => x.Name == "ប្រអប់ព្រាងសារ"
        //       && x.MenuItemId == menuItem.Id && x.LanguageId == Common.KhmerLanguage.Id)) {
        //        context.MenuChildItems.AddOrUpdate(
        //            new MenuChildItem {
        //                Name = "ប្រអប់ព្រាងសារ",
        //                Url = "/message/draft",
        //                MenuItemId = menuItem.Id,
        //                LanguageId = Common.KhmerLanguage.Id
        //            });
        //    }
        //    // Sent
        //    if (!context.MenuChildItems.Any(x => x.Name == "សារដែលផ្ញើរួចហើយ"
        //       && x.MenuItemId == menuItem.Id && x.LanguageId == Common.KhmerLanguage.Id)) {
        //        context.MenuChildItems.AddOrUpdate(
        //            new MenuChildItem {
        //                Name = "សារដែលផ្ញើរួចហើយ",
        //                Url = "/message/sent",
        //                MenuItemId = menuItem.Id,
        //                LanguageId = Common.KhmerLanguage.Id
        //            });
        //    }
        //    // Trash
        //    if (!context.MenuChildItems.Any(x => x.Name == "ធុងសំរាម"
        //       && x.MenuItemId == menuItem.Id && x.LanguageId == Common.KhmerLanguage.Id)) {
        //        context.MenuChildItems.AddOrUpdate(
        //            new MenuChildItem {
        //                Name = "ធុងសំរាម",
        //                Url = "/message/trash",
        //                MenuItemId = menuItem.Id,
        //                LanguageId = Common.KhmerLanguage.Id
        //            });
        //    }

        //    if (context.ChangeTracker.HasChanges())
        //        context.SaveChanges();
        //}

        /// <summary>
        /// Seeds account menu child items
        /// </summary>
        /// <param name="context">The current database context.</param>
        //private static void SeedEnglishAccountMenuChildItems(MainDbContext context) {
        //    var menuItem = context.MenuItems
        //      .FirstOrDefault(x => x.Name == "Account" && x.IsActive);
        //    if (menuItem == null) return;
        //    // Dashboard 
        //    if (!context.MenuChildItems.Any(x => x.Name == "Dashboard"
        //      && x.MenuItemId == menuItem.Id && x.LanguageId == Common.EnglishLanguage.Id)) {
        //        context.MenuChildItems.AddOrUpdate(
        //            new MenuChildItem {
        //                Name = "Dashboard",
        //                Url = "/Account/Index",
        //                MenuItemId = menuItem.Id,
        //                LanguageId = Common.EnglishLanguage.Id
        //            });
        //    }
        //    // Profile
        //    if (!context.MenuChildItems.Any(x => x.Name == "Profile"
        //       && x.MenuItemId == menuItem.Id && x.LanguageId == Common.EnglishLanguage.Id)) {
        //        context.MenuChildItems.AddOrUpdate(
        //            new MenuChildItem {
        //                Name = "Profile",
        //                Url = "/Account/profile",
        //                MenuItemId = menuItem.Id,
        //                LanguageId = Common.EnglishLanguage.Id
        //            });
        //    }
        //    // Sign In 
        //    if (!context.MenuChildItems.Any(x => x.Name == "Sign In"
        //       && x.MenuItemId == menuItem.Id && x.LanguageId == Common.EnglishLanguage.Id)) {
        //        context.MenuChildItems.AddOrUpdate(
        //            new MenuChildItem {
        //                Name = "Sign In",
        //                Url = "/Account/Sigin",
        //                MenuItemId = menuItem.Id,
        //                LanguageId = Common.EnglishLanguage.Id
        //            });
        //    }
        //    // Sign Up
        //    if (!context.MenuChildItems.Any(x => x.Name == "Sign Up"
        //       && x.MenuItemId == menuItem.Id && x.LanguageId == Common.EnglishLanguage.Id)) {
        //        context.MenuChildItems.AddOrUpdate(
        //            new MenuChildItem {
        //                Name = "Sign Up",
        //                Url = "/Account/Register",
        //                MenuItemId = menuItem.Id,
        //                LanguageId = Common.EnglishLanguage.Id
        //            });
        //    }
        //    // Settings
        //    if (!context.MenuChildItems.Any(x => x.Name == "Settings"
        //      && x.MenuItemId == menuItem.Id && x.LanguageId == Common.EnglishLanguage.Id)) {
        //        context.MenuChildItems.AddOrUpdate(
        //            new MenuChildItem {
        //                Name = "Settings",
        //                Url = "/Account/Settings",
        //                MenuItemId = menuItem.Id,
        //                LanguageId = Common.EnglishLanguage.Id
        //            });
        //    }

        //    if (context.ChangeTracker.HasChanges())
        //        context.SaveChanges();
        //}

        /// <summary>
        /// Seeds favorite menu child items in English language.
        /// </summary>
        /// <param name="context">The current database context.</param>
        //private static void SeedEnglishFavoriteMenuChildItems(MainDbContext context) {
        //    var menuItem = context.MenuItems
        //      .FirstOrDefault(x => x.Name == "Favorite" && x.IsActive);
        //    if (menuItem == null) return;
        //    // Cars
        //    if (!context.MenuChildItems.Any(x => x.Name == "Cars"
        //     && x.MenuItemId == menuItem.Id && x.LanguageId == Common.EnglishLanguage.Id)) {
        //        context.MenuChildItems.AddOrUpdate(
        //            new MenuChildItem {
        //                Name = "Cars",
        //                Url = "/Favorite/Cars",
        //                MenuItemId = menuItem.Id,
        //                LanguageId = Common.EnglishLanguage.Id
        //            });
        //    }
        //    // Dealers
        //    if (!context.MenuChildItems.Any(x => x.Name == "Dealers"
        //     && x.MenuItemId == menuItem.Id && x.LanguageId == Common.EnglishLanguage.Id)) {
        //        context.MenuChildItems.AddOrUpdate(
        //            new MenuChildItem {
        //                Name = "Dealers",
        //                Url = "/Favorite/Dealers",
        //                MenuItemId = menuItem.Id,
        //                LanguageId = Common.EnglishLanguage.Id
        //            });
        //    }
        //    // Loans
        //    if (!context.MenuChildItems.Any(x => x.Name == "Loans"
        //     && x.MenuItemId == menuItem.Id && x.LanguageId == Common.EnglishLanguage.Id)) {
        //        context.MenuChildItems.AddOrUpdate(
        //            new MenuChildItem {
        //                Name = "Loans",
        //                Url = "/Favorite/Loans",
        //                MenuItemId = menuItem.Id,
        //                LanguageId = Common.EnglishLanguage.Id
        //            });
        //    }
        //    // Blue Book
        //    if (!context.MenuChildItems.Any(x => x.Name == "Blue Book"
        //     && x.MenuItemId == menuItem.Id && x.LanguageId == Common.EnglishLanguage.Id)) {
        //        context.MenuChildItems.AddOrUpdate(
        //            new MenuChildItem {
        //                Name = "Blue Book",
        //                Url = "/Favorite/Bluebook",
        //                MenuItemId = menuItem.Id,
        //                LanguageId = Common.EnglishLanguage.Id
        //            });
        //    }
        //    // History 
        //    if (!context.MenuChildItems.Any(x => x.Name == "History"
        //     && x.MenuItemId == menuItem.Id && x.LanguageId == Common.EnglishLanguage.Id)) {
        //        context.MenuChildItems.AddOrUpdate(
        //            new MenuChildItem {
        //                Name = "History",
        //                Url = "/Favorite/History",
        //                MenuItemId = menuItem.Id,
        //                LanguageId = Common.EnglishLanguage.Id
        //            });
        //    }
        //    // Insurance 
        //    if (!context.MenuChildItems.Any(x => x.Name == "Insurance"
        //     && x.MenuItemId == menuItem.Id && x.LanguageId == Common.EnglishLanguage.Id)) {
        //        context.MenuChildItems.AddOrUpdate(
        //            new MenuChildItem {
        //                Name = "Insurance",
        //                Url = "/Favorite/Insurance",
        //                MenuItemId = menuItem.Id,
        //                LanguageId = Common.EnglishLanguage.Id
        //            });
        //    }
        //    // Save changes
        //    if (context.ChangeTracker.HasChanges())
        //        context.SaveChanges();
        //}

        /// <summary>
        /// Seeds favorite menu child items in English language.
        /// </summary>
        /// <param name="context">The current database context.</param>
        //private static void SeedKhmerFavoriteMenuChildItems(MainDbContext context) {
        //    var menuItem = context.MenuItems
        //      .FirstOrDefault(x => x.Name == "អ្វីៗដែលខ្ញុំពេញចិត្ត" && x.IsActive);
        //    if (menuItem == null) return;
        //    // Cars
        //    if (!context.MenuChildItems.Any(x => x.Name == "រថយន្ត"
        //     && x.MenuItemId == menuItem.Id && x.LanguageId == Common.KhmerLanguage.Id)) {
        //        context.MenuChildItems.AddOrUpdate(
        //            new MenuChildItem {
        //                Name = "រថយន្ត",
        //                Url = "/Favorite/Cars",
        //                MenuItemId = menuItem.Id,
        //                LanguageId = Common.KhmerLanguage.Id
        //            });
        //    }
        //    // Dealers
        //    if (!context.MenuChildItems.Any(x => x.Name == "អ្នកលក់"
        //     && x.MenuItemId == menuItem.Id && x.LanguageId == Common.KhmerLanguage.Id)) {
        //        context.MenuChildItems.AddOrUpdate(
        //            new MenuChildItem {
        //                Name = "អ្នកលក់",
        //                Url = "/Favorite/Dealers",
        //                MenuItemId = menuItem.Id,
        //                LanguageId = Common.KhmerLanguage.Id
        //            });
        //    }
        //    // Loans
        //    if (!context.MenuChildItems.Any(x => x.Name == "ឥណទាន"
        //     && x.MenuItemId == menuItem.Id && x.LanguageId == Common.KhmerLanguage.Id)) {
        //        context.MenuChildItems.AddOrUpdate(
        //            new MenuChildItem {
        //                Name = "ឥណទាន",
        //                Url = "/Favorite/Loans",
        //                MenuItemId = menuItem.Id,
        //                LanguageId = Common.KhmerLanguage.Id
        //            });
        //    }
        //    // Blue Book
        //    if (!context.MenuChildItems.Any(x => x.Name == "វាយតំលៃរថយន្ត"
        //     && x.MenuItemId == menuItem.Id && x.LanguageId == Common.KhmerLanguage.Id)) {
        //        context.MenuChildItems.AddOrUpdate(
        //            new MenuChildItem {
        //                Name = "វាយតំលៃរថយន្ត",
        //                Url = "/Favorite/Bluebook",
        //                MenuItemId = menuItem.Id,
        //                LanguageId = Common.KhmerLanguage.Id
        //            });
        //    }
        //    // History 
        //    if (!context.MenuChildItems.Any(x => x.Name == "ប្រវតិ្តរថយន្ត"
        //     && x.MenuItemId == menuItem.Id && x.LanguageId == Common.KhmerLanguage.Id)) {
        //        context.MenuChildItems.AddOrUpdate(
        //            new MenuChildItem {
        //                Name = "ប្រវតិ្តរថយន្ត",
        //                Url = "/Favorite/History",
        //                MenuItemId = menuItem.Id,
        //                LanguageId = Common.KhmerLanguage.Id
        //            });
        //    }
        //    // Insurance 
        //    if (!context.MenuChildItems.Any(x => x.Name == "ធានារ៉ាប់រង"
        //     && x.MenuItemId == menuItem.Id && x.LanguageId == Common.KhmerLanguage.Id)) {
        //        context.MenuChildItems.AddOrUpdate(
        //            new MenuChildItem {
        //                Name = "ធានារ៉ាប់រង",
        //                Url = "/Favorite/Insurance",
        //                MenuItemId = menuItem.Id,
        //                LanguageId = Common.KhmerLanguage.Id
        //            });
        //    }
        //    // Save changes
        //    if (context.ChangeTracker.HasChanges())
        //        context.SaveChanges();
        //}

        /// <summary>
        /// Seeds language menu child items.
        /// </summary>
        /// <param name="context">The database context.</param>
        private static void SeedLanguageMenuChildItems(MainDbContext context) {

            var menuItem = context.MenuItems
                .FirstOrDefault(x => x.Name == "Language" && x.IsActive);
            if (menuItem == null) return;

            // English
            if (!context.MenuChildItems.Any(x => x.Name == "English" && x.MenuItemId == menuItem.Id)) {
                context.MenuChildItems.AddOrUpdate(
                    new MenuChildItem {
                        Name = "English",
                        Url = "#",
                        MenuItemId = menuItem.Id,
                        LanguageId = Common.EnglishLanguage.Id
                    });
            }
            // Khmer 
            if (!context.MenuChildItems.Any(x => x.Name == "Khmer" && x.MenuItemId == menuItem.Id)) {
                context.MenuChildItems.AddOrUpdate(
                    new MenuChildItem {
                        Name = "Khmer",
                        Url = "#",
                        MenuItemId = menuItem.Id,
                        LanguageId = Common.EnglishLanguage.Id
                    });
            }
            // Save changes
            if (context.ChangeTracker.HasChanges())
                context.SaveChanges();
        }

        /// <summary>
        /// Seeds footer menu items in English language.
        /// </summary>
        /// <param name="context">The current database context.</param>
        //private static void SeedEnglishFooterMenuItems(MainDbContext context) {
        //    // Footer navigation menu
        //    var menu = context.Menus.FirstOrDefault(x => x.Name == "Footer Navigation Menu");
        //    if (menu == null) return;
        //    // Company
        //    if (!context.MenuItems.Any(x => x.Name == "Company" && x.IsActive
        //        && x.LanguageId == Common.EnglishLanguage.Id)) {
        //        context.MenuItems.AddOrUpdate(new MenuItem {
        //            Name = "Company",
        //            Url = "#",
        //            MenuId = menu.Id,
        //            LanguageId = Common.EnglishLanguage.Id
        //        });
        //    }
        //    // Cars
        //    if (!context.MenuItems.Any(x => x.Name == "Cars" && x.IsActive
        //       && x.LanguageId == Common.EnglishLanguage.Id)) {
        //        context.MenuItems.AddOrUpdate(new MenuItem {
        //            Name = "Cars",
        //            Url = "#",
        //            MenuId = menu.Id,
        //            LanguageId = Common.EnglishLanguage.Id
        //        });
        //    }
        //    // Insurance
        //    if (!context.MenuItems.Any(x => x.Name == "Insurance" && x.IsActive
        //       && x.LanguageId == Common.EnglishLanguage.Id)) {
        //        context.MenuItems.AddOrUpdate(new MenuItem {
        //            Name = "Insurance",
        //            Url = "#",
        //            MenuId = menu.Id,
        //            LanguageId = Common.EnglishLanguage.Id
        //        });
        //    }
        //    // History
        //    if (!context.MenuItems.Any(x => x.Name == "History" && x.IsActive
        //       && x.LanguageId == Common.EnglishLanguage.Id)) {
        //        context.MenuItems.AddOrUpdate(new MenuItem {
        //            Name = "History",
        //            Url = "#",
        //            MenuId = menu.Id,
        //            LanguageId = Common.EnglishLanguage.Id
        //        });
        //    }
        //    // Career
        //    if (!context.MenuItems.Any(x => x.Name == "Career" && x.IsActive
        //       && x.LanguageId == Common.EnglishLanguage.Id)) {
        //        context.MenuItems.AddOrUpdate(new MenuItem {
        //            Name = "Career",
        //            Url = "#",
        //            MenuId = menu.Id,
        //            LanguageId = Common.EnglishLanguage.Id
        //        });
        //    }
        //    // Blue Blook
        //    if (!context.MenuItems.Any(x => x.Name == "Blue Book" && x.IsActive
        //       && x.LanguageId == Common.EnglishLanguage.Id)) {
        //        context.MenuItems.AddOrUpdate(new MenuItem {
        //            Name = "Blue Book",
        //            Url = "#",
        //            MenuId = menu.Id,
        //            LanguageId = Common.EnglishLanguage.Id
        //        });
        //    }
        //    // Affiliate Program
        //    if (!context.MenuItems.Any(x => x.Name == "Affiliate Program" && x.IsActive
        //       && x.LanguageId == Common.EnglishLanguage.Id)) {
        //        context.MenuItems.AddOrUpdate(new MenuItem {
        //            Name = "Affiliate Program",
        //            Url = "#",
        //            MenuId = menu.Id,
        //            LanguageId = Common.EnglishLanguage.Id
        //        });
        //    }
        //    // Deals
        //    if (!context.MenuItems.Any(x => x.Name == "Deals" && x.IsActive
        //       && x.LanguageId == Common.EnglishLanguage.Id)) {
        //        context.MenuItems.AddOrUpdate(new MenuItem {
        //            Name = "Deals",
        //            Url = "#",
        //            MenuId = menu.Id,
        //            LanguageId = Common.EnglishLanguage.Id
        //        });
        //    }
        //    // Dealers 
        //    if (!context.MenuItems.Any(x => x.Name == "Dealers" && x.IsActive
        //       && x.LanguageId == Common.EnglishLanguage.Id)) {
        //        context.MenuItems.AddOrUpdate(new MenuItem {
        //            Name = "Dealers",
        //            Url = "#",
        //            MenuId = menu.Id,
        //            LanguageId = Common.EnglishLanguage.Id
        //        });
        //    }
        //    // Dealerships
        //    if (!context.MenuItems.Any(x => x.Name == "Dealerships" && x.IsActive
        //       && x.LanguageId == Common.EnglishLanguage.Id)) {
        //        context.MenuItems.AddOrUpdate(new MenuItem {
        //            Name = "Dealerships",
        //            Url = "#",
        //            MenuId = menu.Id,
        //            LanguageId = Common.EnglishLanguage.Id
        //        });
        //    }
        //    // Save changes
        //    if (context.ChangeTracker.HasChanges())
        //        context.SaveChanges();
        //}

        /// <summary>
        /// Seeds footer menu items in Khmer language.
        /// </summary>
        /// <param name="context">The current database context.</param>
        //private static void SeedKhmerFooterMenuItems(MainDbContext context) {
        //    // Footer navigation menu
        //    var menu = context.Menus.FirstOrDefault(x => x.Name == "Footer Navigation Menu");
        //    if (menu == null) return;
        //    // Company
        //    if (!context.MenuItems.Any(x => x.Name == "ក្រុមហ៊ុន" && x.IsActive
        //        && x.LanguageId == Common.KhmerLanguage.Id)) {
        //        context.MenuItems.AddOrUpdate(new MenuItem {
        //            Name = "ក្រុមហ៊ុន",
        //            Url = "#",
        //            MenuId = menu.Id,
        //            LanguageId = Common.KhmerLanguage.Id
        //        });
        //    }
        //    // Cars
        //    if (!context.MenuItems.Any(x => x.Name == "រថយន្ត" && x.IsActive
        //       && x.LanguageId == Common.KhmerLanguage.Id)) {
        //        context.MenuItems.AddOrUpdate(new MenuItem {
        //            Name = "រថយន្ត",
        //            Url = "#",
        //            MenuId = menu.Id,
        //            LanguageId = Common.KhmerLanguage.Id
        //        });
        //    }
        //    // Insurance
        //    if (!context.MenuItems.Any(x => x.Name == "ធានារ៉ាប់រង" && x.IsActive
        //       && x.LanguageId == Common.KhmerLanguage.Id)) {
        //        context.MenuItems.AddOrUpdate(new MenuItem {
        //            Name = "ធានារ៉ាប់រង",
        //            Url = "#",
        //            MenuId = menu.Id,
        //            LanguageId = Common.KhmerLanguage.Id
        //        });
        //    }
        //    // History
        //    if (!context.MenuItems.Any(x => x.Name == "ប្រវតិ្តរថយន្ត" && x.IsActive
        //       && x.LanguageId == Common.KhmerLanguage.Id)) {
        //        context.MenuItems.AddOrUpdate(new MenuItem {
        //            Name = "ប្រវតិ្តរថយន្ត",
        //            Url = "#",
        //            MenuId = menu.Id,
        //            LanguageId = Common.KhmerLanguage.Id
        //        });
        //    }
        //    // Career
        //    if (!context.MenuItems.Any(x => x.Name == "អាជីព" && x.IsActive
        //       && x.LanguageId == Common.KhmerLanguage.Id)) {
        //        context.MenuItems.AddOrUpdate(new MenuItem {
        //            Name = "អាជីព",
        //            Url = "#",
        //            MenuId = menu.Id,
        //            LanguageId = Common.KhmerLanguage.Id
        //        });
        //    }
        //    // Blue Blook
        //    if (!context.MenuItems.Any(x => x.Name == "វាយតំលៃរថយន្ត" && x.IsActive
        //       && x.LanguageId == Common.KhmerLanguage.Id)) {
        //        context.MenuItems.AddOrUpdate(new MenuItem {
        //            Name = "វាយតំលៃរថយន្ត",
        //            Url = "#",
        //            MenuId = menu.Id,
        //            LanguageId = Common.KhmerLanguage.Id
        //        });
        //    }
        //    // Affiliate Program
        //    if (!context.MenuItems.Any(x => x.Name == "កម្មវិធីចូលរួមរកសុី" && x.IsActive
        //       && x.LanguageId == Common.KhmerLanguage.Id)) {
        //        context.MenuItems.AddOrUpdate(new MenuItem {
        //            Name = "កម្មវិធីចូលរួមរកសុី",
        //            Url = "#",
        //            MenuId = menu.Id,
        //            LanguageId = Common.KhmerLanguage.Id
        //        });
        //    }
        //    // Deals
        //    if (!context.MenuItems.Any(x => x.Name == "រថយន្តចញ្ចុះតំលៃ" && x.IsActive
        //       && x.LanguageId == Common.KhmerLanguage.Id)) {
        //        context.MenuItems.AddOrUpdate(new MenuItem {
        //            Name = "រថយន្តចញ្ចុះតំលៃ",
        //            Url = "#",
        //            MenuId = menu.Id,
        //            LanguageId = Common.KhmerLanguage.Id
        //        });
        //    }
        //    // Dealers 
        //    if (!context.MenuItems.Any(x => x.Name == "អ្នកលក់​​" && x.IsActive
        //       && x.LanguageId == Common.KhmerLanguage.Id)) {
        //        context.MenuItems.AddOrUpdate(new MenuItem {
        //            Name = "អ្នកលក់​​",
        //            Url = "#",
        //            MenuId = menu.Id,
        //            LanguageId = Common.KhmerLanguage.Id
        //        });
        //    }
        //    // Dealerships
        //    if (!context.MenuItems.Any(x => x.Name == "ក្រុមហ៊ុនលក់រថយន្ត" && x.IsActive
        //       && x.LanguageId == Common.KhmerLanguage.Id)) {
        //        context.MenuItems.AddOrUpdate(new MenuItem {
        //            Name = "ក្រុមហ៊ុនលក់រថយន្ត",
        //            Url = "#",
        //            MenuId = menu.Id,
        //            LanguageId = Common.KhmerLanguage.Id
        //        });
        //    }
        //    // Save changes
        //    if (context.ChangeTracker.HasChanges())
        //        context.SaveChanges();
        //}

        ///// <summary>
        ///// WIP: Seeds footer's company menu child items in Enlgish language. 
        ///// </summary>
        ///// <param name="context">The current database context.</param>
        //private static void SeedEnglishFooterCompanyMenuChildItems(MainDbContext context) {
        //    // Company
        //    var menuItem = context.MenuItems.FirstOrDefault(x => x.Name == "Company"
        //        && x.IsActive && x.LanguageId == Common.EnglishLanguage.Id);
        //    if (menuItem == null) return;

        //    // How It Works
        //    if (!context.MenuChildItems.Any(x => x.Name == "How It Works" && x.IsActive
        //        && x.LanguageId == Common.EnglishLanguage.Id)) {
        //        context.MenuChildItems.AddOrUpdate(new MenuChildItem {
        //            Name = "How It Works",
        //            Url = "/Company/HowItWorks",
        //            LanguageId = Common.EnglishLanguage.Id,
        //            MenuItemId = menuItem.Id
        //        });
        //    }
        //    // Blogs
        //    if (!context.MenuChildItems.Any(x => x.Name == "Blogs" && x.IsActive
        //       && x.LanguageId == Common.EnglishLanguage.Id)) {
        //        context.MenuChildItems.AddOrUpdate(new MenuChildItem {
        //            Name = "Blogs",
        //            Url = "/Company/Blogs",
        //            LanguageId = Common.EnglishLanguage.Id,
        //            MenuItemId = menuItem.Id
        //        });
        //    }
        //    // Privacy Policy
        //    if (!context.MenuChildItems.Any(x => x.Name == "Privacy Policy" && x.IsActive
        //       && x.LanguageId == Common.EnglishLanguage.Id)) {
        //        context.MenuChildItems.AddOrUpdate(new MenuChildItem {
        //            Name = "Privacy Policy",
        //            Url = "/Company/PrivacyPolicy",
        //            LanguageId = Common.EnglishLanguage.Id,
        //            MenuItemId = menuItem.Id
        //        });
        //    }
        //    // Terms & Conditions
        //    if (!context.MenuChildItems.Any(x => x.Name == "Terms & Conditions" && x.IsActive
        //       && x.LanguageId == Common.EnglishLanguage.Id)) {
        //        context.MenuChildItems.AddOrUpdate(new MenuChildItem {
        //            Name = "Terms & Conditions",
        //            Url = "/Company/TermsAndConditions",
        //            LanguageId = Common.EnglishLanguage.Id,
        //            MenuItemId = menuItem.Id
        //        });
        //    }
        //    // Save changes
        //    if (context.ChangeTracker.HasChanges())
        //        context.SaveChanges();
        //}

        /// <summary>
        /// Seeds navigation menus
        /// </summary>
        /// <param name="context">The database context.</param>
        public static void SeedMenus(MainDbContext context) {
            // Main navigation menu
            if (!context.Menus.Any(x => x.Name == "Main Navigation Bar Menu" && x.NameConstant == "MainNavigationBarMenu")) {
                context.Menus.AddOrUpdate(new Menu {
                    Name = "Main Navigation Bar Menu",
                    NameConstant = "MainNavigationBarMenu"
                });
            }
            // User navigation menu
            if (!context.Menus.Any(x => x.Name == "User Navigation Menu" && x.NameConstant == "UserNavigationMenu")) {
                context.Menus.AddOrUpdate(new Menu {
                    Name = "User Navigation Menu",
                    NameConstant = "UserNavigationMenu"
                });
            }
            if (!context.Menus.Any(x => x.Name == "Footer Navigation Menu" && x.NameConstant == "FooterNavigationMenu")) {
                context.Menus.AddOrUpdate(new Menu {
                    Name = "Footer Navigation Menu",
                    NameConstant = "FooterNavigationMenu"
                });
            }

            if (!context.Menus.Any(x => x.Name == "Admin Vertical Menu" && x.NameConstant == "AdminVerticalMenu")) {
                context.Menus.AddOrUpdate(new Menu {
                    Name = "Admin Vertical Menu",
                    NameConstant = "AdminVerticalMenu"
                });
            }
            // Save changes
            if (context.ChangeTracker.HasChanges())
                context.SaveChanges();
        }

        /// <summary>
        /// Seeds user navigation menu items in Khmer language.
        /// </summary>
        /// <param name="context">The main database context.</param>
        //private static void SeedKhmerUserNavigationMenuItems(MainDbContext context) {
        //    var menu = context.Menus.FirstOrDefault(x => x.Name == "User Navigation Menu" && x.IsActive);
        //    if (menu == null) return;
        //    // Account
        //    if (!context.MenuItems.Any(x => x.Name == "គណនី" && x.MenuId == menu.Id
        //        && x.LanguageId == Common.KhmerLanguage.Id)) {
        //        context.MenuItems.AddOrUpdate(new MenuItem {
        //            Name = "គណនី", Url = "#",
        //            MenuId = menu.Id,
        //            LanguageId = Common.KhmerLanguage.Id
        //        });
        //    }
        //    // Favorite
        //    if (!context.MenuItems.Any(x => x.Name == "អ្វីៗដែលខ្ញុំពេញចិត្ត" && x.MenuId == menu.Id
        //        && x.LanguageId == Common.KhmerLanguage.Id)) {
        //        context.MenuItems.AddOrUpdate(new MenuItem {
        //            Name = "អ្វីៗដែលខ្ញុំពេញចិត្ត", Url = "#",
        //            MenuId = menu.Id,
        //            LanguageId = Common.KhmerLanguage.Id
        //        });
        //    }
        //    // Message
        //    if (!context.MenuItems.Any(x => x.Name == "សារ" && x.MenuId == menu.Id
        //        && x.LanguageId == Common.KhmerLanguage.Id)) {
        //        context.MenuItems.AddOrUpdate(new MenuItem {
        //            Name = "សារ", Url = "#",
        //            MenuId = menu.Id,
        //            LanguageId = Common.KhmerLanguage.Id
        //        });
        //    }
        //    // Chat
        //    if (!context.MenuItems.Any(x => x.Name == "ជជែក" && x.MenuId == menu.Id
        //        && x.LanguageId == Common.KhmerLanguage.Id)) {
        //        context.MenuItems.AddOrUpdate(new MenuItem {
        //            Name = "ជជែក", Url = "#",
        //            MenuId = menu.Id,
        //            LanguageId = Common.KhmerLanguage.Id
        //        });
        //    }
        //    // Support 
        //    if (!context.MenuItems.Any(x => x.Name == "ជំនួយ" && x.MenuId == menu.Id
        //        && x.LanguageId == Common.KhmerLanguage.Id)) {
        //        context.MenuItems.AddOrUpdate(new MenuItem {
        //            Name = "ជំនួយ", Url = "#",
        //            MenuId = menu.Id,
        //            LanguageId = Common.KhmerLanguage.Id
        //        });
        //    }
        //    // Customer Service 
        //    if (!context.MenuItems.Any(x => x.Name == "សេវាអតិថិជន" && x.MenuId == menu.Id
        //        && x.LanguageId == Common.EnglishLanguage.Id)) {
        //        context.MenuItems.AddOrUpdate(new MenuItem {
        //            Name = "សេវាអតិថិជន", Url = "#",
        //            MenuId = menu.Id,
        //            LanguageId = Common.EnglishLanguage.Id
        //        });
        //    }
        //    // Language 
        //    if (!context.MenuItems.Any(x => x.Name == "ភាសា" && x.MenuId == menu.Id
        //        && x.LanguageId == Common.EnglishLanguage.Id)) {
        //        context.MenuItems.AddOrUpdate(new MenuItem {
        //            Name = "ភាសា", Url = "#",
        //            MenuId = menu.Id,
        //            LanguageId = Common.EnglishLanguage.Id
        //        });
        //    }

        //    if (context.ChangeTracker.HasChanges())
        //        context.SaveChanges();
        //}
        /// <summary>
        /// Seeds user navigation menu items in Enlgish language.
        /// </summary>
        /// <param name="context">The main database context.</param>
        //private static void SeedEnglishUserNavigationMenuItems(MainDbContext context) {
        //    var menu = context.Menus.FirstOrDefault(x => x.Name == "User Navigation Menu" && x.IsActive);
        //    if (menu == null) return;
        //    // Account
        //    if (!context.MenuItems.Any(x => x.Name == "Account" && x.MenuId == menu.Id
        //        && x.LanguageId == Common.EnglishLanguage.Id)) {
        //        context.MenuItems.AddOrUpdate(new MenuItem {
        //            Name = "Account", Url = "#",
        //            MenuId = menu.Id,
        //            LanguageId = Common.EnglishLanguage.Id
        //        });
        //    }
        //    // Favorite
        //    if (!context.MenuItems.Any(x => x.Name == "Favorite" && x.MenuId == menu.Id
        //        && x.LanguageId == Common.EnglishLanguage.Id)) {
        //        context.MenuItems.AddOrUpdate(new MenuItem {
        //            Name = "Favorite", Url = "#",
        //            MenuId = menu.Id,
        //            LanguageId = Common.EnglishLanguage.Id
        //        });
        //    }
        //    // Message
        //    if (!context.MenuItems.Any(x => x.Name == "Message" && x.MenuId == menu.Id
        //        && x.LanguageId == Common.EnglishLanguage.Id)) {
        //        context.MenuItems.AddOrUpdate(new MenuItem {
        //            Name = "Message", Url = "#",
        //            MenuId = menu.Id,
        //            LanguageId = Common.EnglishLanguage.Id
        //        });
        //    }
        //    // Chat
        //    if (!context.MenuItems.Any(x => x.Name == "Chat" && x.MenuId == menu.Id
        //        && x.LanguageId == Common.EnglishLanguage.Id)) {
        //        context.MenuItems.AddOrUpdate(new MenuItem {
        //            Name = "Chat", Url = "#",
        //            MenuId = menu.Id,
        //            LanguageId = Common.EnglishLanguage.Id
        //        });
        //    }
        //    // Support 
        //    if (!context.MenuItems.Any(x => x.Name == "Support" && x.MenuId == menu.Id
        //        && x.LanguageId == Common.EnglishLanguage.Id)) {
        //        context.MenuItems.AddOrUpdate(new MenuItem {
        //            Name = "Support", Url = "#",
        //            MenuId = menu.Id,
        //            LanguageId = Common.EnglishLanguage.Id
        //        });
        //    }
        //    // Customer Service 
        //    if (!context.MenuItems.Any(x => x.Name == "Customer Service" && x.MenuId == menu.Id
        //        && x.LanguageId == Common.EnglishLanguage.Id)) {
        //        context.MenuItems.AddOrUpdate(new MenuItem {
        //            Name = "Customer Service", Url = "#",
        //            MenuId = menu.Id,
        //            LanguageId = Common.EnglishLanguage.Id
        //        });
        //    }
        //    // Language 
        //    if (!context.MenuItems.Any(x => x.Name == "Language" && x.MenuId == menu.Id
        //        && x.LanguageId == Common.EnglishLanguage.Id)) {
        //        context.MenuItems.AddOrUpdate(new MenuItem {
        //            Name = "Language", Url = "#",
        //            MenuId = menu.Id,
        //            LanguageId = Common.EnglishLanguage.Id
        //        });
        //    }

        //    if (context.ChangeTracker.HasChanges())
        //        context.SaveChanges();
        //}
        /// <summary>
        /// Seed main navigation menu items in English language.
        /// </summary>
        /// <param name="context">The current database context.</param>
        private static void SeedEnglishMainNavBarMenuItems(MainDbContext context) {

            var menu = context.Menus.FirstOrDefault(x => x.Name == "Main Navigation Bar Menu" && x.IsActive);
            if (menu == null) return;
            // Buy
            if (!context.MenuItems.Any(x => x.Name == "Buy" && x.MenuId == menu.Id
                && x.LanguageId == Common.EnglishLanguage.Id)) {
                context.MenuItems.AddOrUpdate(new MenuItem {
                    Name = "Buy", Url = "Buy",
                    MenuId = menu.Id,
                    LanguageId = Common.EnglishLanguage.Id
                });
            }
            // Sell
            if (!context.MenuItems.Any(x => x.Name == "Sell" && x.MenuId == menu.Id
                && x.LanguageId == Common.EnglishLanguage.Id)) {
                context.MenuItems.AddOrUpdate(new MenuItem {
                    Name = "Sell", Url = "Sell",
                    MenuId = menu.Id, LanguageId = Common.EnglishLanguage.Id
                });
            }
            // Rent
            if (!context.MenuItems.Any(x => x.Name == "Rent" && x.MenuId == menu.Id
                && x.LanguageId == Common.EnglishLanguage.Id)) {
                context.MenuItems.AddOrUpdate(new MenuItem {
                    Name = "Rent", Url = "Rent",
                    MenuId = menu.Id, LanguageId = Common.EnglishLanguage.Id
                });
            }
            // Agent
            if (!context.MenuItems.Any(x => x.Name == "Agent" && x.MenuId == menu.Id
                && x.LanguageId == Common.EnglishLanguage.Id)) {
                context.MenuItems.AddOrUpdate(new MenuItem {
                    Name = "Agent", Url = "Agent",
                    MenuId = menu.Id, LanguageId = Common.EnglishLanguage.Id
                });
            }
            // About
            if (!context.MenuItems.Any(x => x.Name == "About" && x.MenuId == menu.Id
                && x.LanguageId == Common.EnglishLanguage.Id)) {
                context.MenuItems.AddOrUpdate(new MenuItem {
                    Name = "About", Url = "About",
                    MenuId = menu.Id, LanguageId = Common.EnglishLanguage.Id
                });
            }
            // Contact
            if (!context.MenuItems.Any(x => x.Name == "Contact" && x.MenuId == menu.Id
                && x.LanguageId == Common.EnglishLanguage.Id)) {
                context.MenuItems.AddOrUpdate(new MenuItem {
                    Name = "Contact", Url = "Contact",
                    MenuId = menu.Id, LanguageId = Common.EnglishLanguage.Id
                });
            }

            // Save changes
            if (context.ChangeTracker.HasChanges())
                context.SaveChanges();
        }

        /// <summary>
        /// Seed main navigation menu items in English language.
        /// </summary>
        /// <param name="context">The current database context.</param>
        //public static void SeedKhmerMainNavBarMenuItems(MainDbContext context) {

        //    var menu = context.Menus.FirstOrDefault(x => x.Name == "Main Navigation Bar Menu");
        //    if (menu == null) return;
        //    // Buy
        //    if (!context.MenuItems.Any(x => x.Name == "ទិញ" && x.MenuId == menu.Id
        //        && x.LanguageId == Common.KhmerLanguage.Id)) {
        //        context.MenuItems.AddOrUpdate(new MenuItem {
        //            Name = "ទិញ", Url = "Buy",
        //            MenuId = menu.Id,
        //            LanguageId = Common.KhmerLanguage.Id
        //        });
        //    }
        //    // Sell
        //    if (!context.MenuItems.Any(x => x.Name == "លក់" && x.MenuId == menu.Id
        //        && x.LanguageId == Common.KhmerLanguage.Id)) {
        //        context.MenuItems.AddOrUpdate(new MenuItem {
        //            Name = "លក់", Url = "Sell",
        //            MenuId = menu.Id, LanguageId = Common.KhmerLanguage.Id
        //        });
        //    }
        //    // Trade In
        //    if (!context.MenuItems.Any(x => x.Name == "ដូរ" && x.MenuId == menu.Id
        //        && x.LanguageId == Common.KhmerLanguage.Id)) {
        //        context.MenuItems.AddOrUpdate(new MenuItem {
        //            Name = "ដូរ", Url = "TradeIn",
        //            MenuId = menu.Id, LanguageId = Common.KhmerLanguage.Id
        //        });
        //    }
        //    // Research
        //    if (!context.MenuItems.Any(x => x.Name == "វិវេចនា" && x.MenuId == menu.Id
        //        && x.LanguageId == Common.KhmerLanguage.Id)) {
        //        context.MenuItems.AddOrUpdate(new MenuItem {
        //            Name = "វិវេចនា", Url = "Research",
        //            IsActive = false,
        //            MenuId = menu.Id, LanguageId = Common.KhmerLanguage.Id
        //        });
        //    }
        //    // Dealers
        //    if (!context.MenuItems.Any(x => x.Name == "អ្នកលក់" && x.MenuId == menu.Id
        //        && x.LanguageId == Common.KhmerLanguage.Id)) {
        //        context.MenuItems.AddOrUpdate(new MenuItem {
        //            Name = "អ្នកលក់", Url = "Dealers",
        //            MenuId = menu.Id, LanguageId = Common.KhmerLanguage.Id
        //        });
        //    }
        //    // Loans
        //    if (!context.MenuItems.Any(x => x.Name == "ឥណទាន" && x.MenuId == menu.Id
        //        && x.LanguageId == Common.KhmerLanguage.Id)) {
        //        context.MenuItems.AddOrUpdate(new MenuItem {
        //            Name = "ឥណទាន", Url = "Loans",
        //            MenuId = menu.Id, LanguageId = Common.KhmerLanguage.Id
        //        });
        //    }
        //    // Insurance
        //    if (!context.MenuItems.Any(x => x.Name == "ធានារ៉ាប់រង" && x.MenuId == menu.Id
        //        && x.LanguageId == Common.KhmerLanguage.Id)) {
        //        context.MenuItems.AddOrUpdate(new MenuItem {
        //            Name = "ធានារ៉ាប់រង", Url = "Insurance",
        //            MenuId = menu.Id, LanguageId = Common.KhmerLanguage.Id
        //        });
        //    }
        //    // Blue Book
        //    if (!context.MenuItems.Any(x => x.Name == "វាយតំលៃរថយន្ត" && x.MenuId == menu.Id
        //        && x.LanguageId == Common.EnglishLanguage.Id)) {
        //        context.MenuItems.AddOrUpdate(new MenuItem {
        //            Name = "វាយតំលៃរថយន្ត", Url = "BlueBook",
        //            IsActive = false,
        //            MenuId = menu.Id, LanguageId = Common.EnglishLanguage.Id
        //        });
        //    }
        //    // History
        //    if (!context.MenuItems.Any(x => x.Name == "ប្រវតិ្តរថយន្ត" && x.MenuId == menu.Id
        //        && x.LanguageId == Common.EnglishLanguage.Id)) {
        //        context.MenuItems.AddOrUpdate(new MenuItem {
        //            Name = "ប្រវតិ្តរថយន្ត", Url = "History",
        //            IsActive = false,
        //            MenuId = menu.Id, LanguageId = Common.EnglishLanguage.Id
        //        });
        //    }
        //    // Save changes
        //    if (context.ChangeTracker.HasChanges())
        //        context.SaveChanges();
        //}

        /// <summary>
        /// Seed admin menu in english language
        /// </summary>
        //public static void SeedEnglishAdminMenu(MainDbContext context) {

        //    // Admin Vertical Menu
        //    var menu = context.Menus.FirstOrDefault(x => x.Name == "Admin Vertical Menu");
        //    if (menu == null) return;

        //    // Vehicles
        //    if (!context.MenuItems.Any(x => x.Name == "Vehicles" && x.MenuId == menu.Id
        //        && x.LanguageId == Common.EnglishLanguage.Id)) {
        //        context.MenuItems.AddOrUpdate(new MenuItem {
        //            Name = "Vehicles", Url = "Vehicles",
        //            IsActive = false,
        //            MenuId = menu.Id, LanguageId = Common.EnglishLanguage.Id
        //        });
        //    }
        //    // Save changes
        //    if (context.ChangeTracker.HasChanges())
        //        context.SaveChanges();
        //}

        //public static void SeedEnglishAdminMenuChild(MainDbContext context) {
        //    // Admin Vertical Menu
        //    var menuItem = context.MenuItems.FirstOrDefault(x => x.Name == "Vehicles");
        //    if (menuItem == null) return;

        //    // Years
        //    if (!context.MenuChildItems.Any(x => x.Name == "Years" && x.MenuItemId == menuItem.Id
        //        && x.LanguageId == Common.EnglishLanguage.Id)) {
        //        context.MenuChildItems.AddOrUpdate(new MenuChildItem {
        //            Name = "Years", Url = "Years",
        //            IsActive = false,
        //            MenuItemId = menuItem.Id, LanguageId = Common.EnglishLanguage.Id
        //        });
        //    }

        //    // Makes
        //    if (!context.MenuChildItems.Any(x => x.Name == "Makes" && x.MenuItemId == menuItem.Id
        //        && x.LanguageId == Common.EnglishLanguage.Id)) {
        //        context.MenuChildItems.AddOrUpdate(new MenuChildItem {
        //            Name = "Makes", Url = "Makes",
        //            IsActive = false,
        //            MenuItemId = menuItem.Id, LanguageId = Common.EnglishLanguage.Id
        //        });
        //    }

        //    // Makes
        //    if (!context.MenuChildItems.Any(x => x.Name == "Models" && x.MenuItemId == menuItem.Id
        //        && x.LanguageId == Common.EnglishLanguage.Id)) {
        //        context.MenuChildItems.AddOrUpdate(new MenuChildItem {
        //            Name = "Models", Url = "Models",
        //            IsActive = false,
        //            MenuItemId = menuItem.Id, LanguageId = Common.EnglishLanguage.Id
        //        });
        //    }

        //    // Makes
        //    if (!context.MenuChildItems.Any(x => x.Name == "Trims" && x.MenuItemId == menuItem.Id
        //        && x.LanguageId == Common.EnglishLanguage.Id)) {
        //        context.MenuChildItems.AddOrUpdate(new MenuChildItem {
        //            Name = "Trims", Url = "Trims",
        //            IsActive = false,
        //            MenuItemId = menuItem.Id, LanguageId = Common.EnglishLanguage.Id
        //        });
        //    }

        //    // Makes
        //    if (!context.MenuChildItems.Any(x => x.Name == "Colors" && x.MenuItemId == menuItem.Id
        //        && x.LanguageId == Common.EnglishLanguage.Id)) {
        //        context.MenuChildItems.AddOrUpdate(new MenuChildItem {
        //            Name = "Colors", Url = "Colors",
        //            IsActive = false,
        //            MenuItemId = menuItem.Id, LanguageId = Common.EnglishLanguage.Id
        //        });
        //    }

        //    // Makes
        //    if (!context.MenuChildItems.Any(x => x.Name == "Body Style" && x.MenuItemId == menuItem.Id
        //        && x.LanguageId == Common.EnglishLanguage.Id)) {
        //        context.MenuChildItems.AddOrUpdate(new MenuChildItem {
        //            Name = "Body Style", Url = "Body Style",
        //            IsActive = false,
        //            MenuItemId = menuItem.Id, LanguageId = Common.EnglishLanguage.Id
        //        });
        //    }

        //    // Save changes
        //    if (context.ChangeTracker.HasChanges())
        //        context.SaveChanges();
        //}

        /// <summary>
        /// Seed admin menu in khmer language
        /// </summary>
        //public static void SeedKhmerAdminMenu(MainDbContext context) {
        //    // Admin Vertical Menu
        //    var menu = context.Menus.FirstOrDefault(x => x.Name == "Admin Vertical Menu");
        //    if (menu == null) return;

        //    // Vehicles
        //    if (!context.MenuItems.Any(x => x.Name == "Vehicles" && x.MenuId == menu.Id
        //        && x.LanguageId == Common.EnglishLanguage.Id)) {
        //        context.MenuItems.AddOrUpdate(new MenuItem {
        //            Name = "Vehicles", Url = "Vehicles",
        //            IsActive = false,
        //            MenuId = menu.Id, LanguageId = Common.EnglishLanguage.Id
        //        });
        //    }
        //    // Save changes
        //    if (context.ChangeTracker.HasChanges())
        //        context.SaveChanges();
        //}

    }
}

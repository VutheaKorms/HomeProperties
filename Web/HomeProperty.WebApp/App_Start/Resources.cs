using HomeProperty.i18n.Abstract;
using HomeProperty.i18n.Concrete;
using System.Globalization;

namespace HomeProperty.WebApp {
    public class Resources {
        private static IResourceProvider resourceProvider = new DbResourceProvider();


        /// <summary>HomeProperty</summary>
        public static string App_WebAppName {
            get {
                return (string)resourceProvider.GetResource("App_WebAppName", CultureInfo.CurrentUICulture.Name);
            }
        }

        /// <summary>Membership</summary>
        public static string Home_Membership {
            get {
                return (string)resourceProvider.GetResource("Home_Membership", CultureInfo.CurrentUICulture.Name);
            }
        }

        /// <summary>Finance</summary>
        public static string Home_Finance {
            get {
                return (string)resourceProvider.GetResource("Home_Finance", CultureInfo.CurrentUICulture.Name);
            }
        }

        /// <summary>Finance</summary>
        public static string Home_Sale {
            get {
                return (string)resourceProvider.GetResource("Home_Sale", CultureInfo.CurrentUICulture.Name);
            }
        }

        /// <summary>All Rights Reserved.</summary>
        public static string Layout_AllRightsReserved {
            get {
                return (string)resourceProvider.GetResource("Layout_AllRightsReserved", CultureInfo.CurrentUICulture.Name);
            }
        }

        /// <summary>Login</summary>
        public static string Account_Login {
            get {
                return (string)resourceProvider.GetResource("Account_Login", CultureInfo.CurrentUICulture.Name);
            }
        }

        /// <summary>Log off</summary>
        public static string Account_Logoff {
            get {
                return (string)resourceProvider.GetResource("Account_Logoff", CultureInfo.CurrentUICulture.Name);
            }
        }

        /// <summary>Email</summary>
        public static string Account_Email {
            get {
                return (string)resourceProvider.GetResource("Account_Email", CultureInfo.CurrentUICulture.Name);
            }
        }

        /// <summary>Password</summary>
        public static string Account_Password {
            get {
                return (string)resourceProvider.GetResource("Account_Password", CultureInfo.CurrentUICulture.Name);
            }
        }

        /// <summary>Remember Me</summary>
        public static string Account_RememberMe {
            get {
                return (string)resourceProvider.GetResource("Account_RememberMe", CultureInfo.CurrentUICulture.Name);
            }
        }

        /// <summary>Forgot your password?</summary>
        public static string Account_ForgotYourPassword {
            get {
                return (string)resourceProvider.GetResource("Account_ForgotYourPassword", CultureInfo.CurrentUICulture.Name);
            }
        }

        /// <summary>Hello</summary>
        public static string Account_Hello {
            get {
                return (string)resourceProvider.GetResource("Account_Hello", CultureInfo.CurrentUICulture.Name);
            }
        }

        /// <summary>Manage</summary>
        public static string Account_Manage {
            get {
                return (string)resourceProvider.GetResource("Account_Manage", CultureInfo.CurrentUICulture.Name);
            }
        }

        /// <summary>Search Members</summary>
        public static string Membership_SearchMembers {
            get {
                return (string)resourceProvider.GetResource("Membership_SearchMembers", CultureInfo.CurrentUICulture.Name);
            }
        }

        /// <summary>Add Member</summary>
        public static string Membership_AddMember {
            get {
                return (string)resourceProvider.GetResource("Membership_AddMember", CultureInfo.CurrentUICulture.Name);
            }
        }

        /// <summary>BrowseMembers</summary>
        public static string Membership_BrowseMembers {
            get {
                return (string)resourceProvider.GetResource("Membership_BrowseMembers", CultureInfo.CurrentUICulture.Name);
            }
        }

        /// <summary>Personal Information</summary>
        public static string Membership_PersonalInformation {
            get {
                return (string)resourceProvider.GetResource("Membership_PersonalInformation", CultureInfo.CurrentUICulture.Name);
            }
        }

        /// <summary>First Name</summary>
        public static string Membership_FirstName {
            get {
                return (string)resourceProvider.GetResource("Membership_FirstName", CultureInfo.CurrentUICulture.Name);
            }
        }

        /// <summary>First Name is a required field.</summary>
        public static string Membership_FirstName_Required {
            get {
                return (string)resourceProvider.GetResource("Membership_FirstName_Required", CultureInfo.CurrentUICulture.Name);
            }
        }

        /// <summary>Last Name</summary>
        public static string Membership_LastName {
            get {
                return (string)resourceProvider.GetResource("Membership_LastName", CultureInfo.CurrentUICulture.Name);
            }
        }

        /// <summary>Last Name is a required field.</summary>
        public static string Membership_LastName_Required {
            get {
                return (string)resourceProvider.GetResource("Membership_LastName_Required", CultureInfo.CurrentUICulture.Name);
            }
        }

        /// <summary>Preferred Name</summary>
        public static string Membership_PreferredName {
            get {
                return (string)resourceProvider.GetResource("Membership_PreferredName", CultureInfo.CurrentUICulture.Name);
            }
        }

        /// <summary>Street Address</summary>
        public static string Membership_StreetAddress {
            get {
                return (string)resourceProvider.GetResource("Membership_StreetAddress", CultureInfo.CurrentUICulture.Name);
            }
        }

        /// <summary>Street Address is a required field.</summary>
        public static string Membership_StreetAddress_Required {
            get {
                return (string)resourceProvider.GetResource("Membership_StreetAddress_Required", CultureInfo.CurrentUICulture.Name);
            }
        }

        /// <summary>City</summary>
        public static string Membership_City {
            get {
                return (string)resourceProvider.GetResource("Membership_City", CultureInfo.CurrentUICulture.Name);
            }
        }

        /// <summary>City is a required field.</summary>
        public static string Membership_City_Required {
            get {
                return (string)resourceProvider.GetResource("Membership_City_Required", CultureInfo.CurrentUICulture.Name);
            }
        }

        /// <summary>State</summary>
        public static string Membership_State {
            get {
                return (string)resourceProvider.GetResource("Membership_State", CultureInfo.CurrentUICulture.Name);
            }
        }

        /// <summary>State is a required field.</summary>
        public static string Membership_State_Required {
            get {
                return (string)resourceProvider.GetResource("Membership_State_Required", CultureInfo.CurrentUICulture.Name);
            }
        }

        /// <summary>Zip Code</summary>
        public static string Membership_ZipCode {
            get {
                return (string)resourceProvider.GetResource("Membership_ZipCode", CultureInfo.CurrentUICulture.Name);
            }
        }

        /// <summary>Zip Code is a required field.</summary>
        public static string Membership_ZipCode_Required {
            get {
                return (string)resourceProvider.GetResource("Membership_ZipCode_Required", CultureInfo.CurrentUICulture.Name);
            }
        }

        /// <summary>Save</summary>
        public static string Membership_Save {
            get {
                return (string)resourceProvider.GetResource("Membership_Save", CultureInfo.CurrentUICulture.Name);
            }
        }

        /// <summary>Messages</summary>
        public static string Message_Messages {
            get {
                return (string)resourceProvider.GetResource("Message_Messages", CultureInfo.CurrentUICulture.Name);
            }
        }

    }
}

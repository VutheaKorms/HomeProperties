using HomeProperty.i18n.Concrete;
using System;
using System.Configuration;

namespace HomeProperty.i18n.ResourceBuilder {
    class Program {
        static void Main(string[] args) {
            var builder = new Utility.ResourceBuilder();
            var connectionString = ConfigurationManager.ConnectionStrings["HomePropertyDev"].ConnectionString;
            var filePath = builder.Create(new DbResourceProvider(connectionString), summaryCulture: "en-US");
            Console.WriteLine("Created file {0}", filePath);
        }
    }
}

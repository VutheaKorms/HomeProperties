using HomeProperty.DbContexts;
using System;
using System.Threading.Tasks;

namespace HomeProperty.Seeder {
    class Program {

        static void Main(string[] args) {
            Console.WriteLine("Seeding Data...");
            SeedSync();
            SeedAsync();
            Console.WriteLine("Seeding Data Completed.");
            Console.ReadKey();
        }

        private static void SeedSync() {
            using (var context = new MainDbContext()) {

            }
        }

        private static void SeedAsync() {
            Task.WaitAll(

            );
        }
    }
}

using HomeProperty.EF.App;
using System.Data.Entity.ModelConfiguration;

namespace HomeProperty.App {
    public class ApplicationConfig : EntityTypeConfiguration<Application> {
        public ApplicationConfig() {
            HasKey(x => x.Id);
            Property(x => x.Name).IsRequired().HasMaxLength(50);
        }
    }
}

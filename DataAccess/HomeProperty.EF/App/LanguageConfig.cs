using System.Data.Entity.ModelConfiguration;

namespace HomeProperty.App {
    public class LanguageConfig : EntityTypeConfiguration<Language> {
        public LanguageConfig() {
            HasKey(x => x.Id);
            Property(x => x.Name).IsRequired().HasMaxLength(50);
            Property(x => x.Locale).IsRequired().HasMaxLength(15);
        }
    }
}

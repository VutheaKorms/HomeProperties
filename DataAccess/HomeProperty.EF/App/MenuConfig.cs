using System.Data.Entity.ModelConfiguration;

namespace HomeProperty.App {
    public class MenuConfig : EntityTypeConfiguration<Menu> {
        public MenuConfig() {
            HasKey(x => x.Id);
            Property(x => x.Name).IsRequired().HasMaxLength(50);
            Property(x => x.NameConstant).IsRequired().HasMaxLength(50);
        }
    }
}

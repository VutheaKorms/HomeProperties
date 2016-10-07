using System.Data.Entity.ModelConfiguration;

namespace HomeProperty.App {
    public class MenuItemConfig : EntityTypeConfiguration<MenuItem> {
        public MenuItemConfig() {
            HasKey(x => x.Id);
            Property(x => x.Name).IsRequired().HasMaxLength(50);
            Property(x => x.Url).IsRequired().HasMaxLength(400);
            HasRequired(x => x.Menu).WithMany(x => x.MenuItems)
                .HasForeignKey(x => x.MenuId)
                .WillCascadeOnDelete(false);
            Property(x => x.IconUrl).IsOptional().HasMaxLength(400);
            HasOptional(x => x.Language).WithMany(x => x.MenuItems)
                .HasForeignKey(x => x.LanguageId)
                .WillCascadeOnDelete(false);
        }
    }
}

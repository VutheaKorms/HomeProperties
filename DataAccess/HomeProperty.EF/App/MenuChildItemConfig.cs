using System.Data.Entity.ModelConfiguration;

namespace HomeProperty.App {
    public class MenuChildItemConfig : EntityTypeConfiguration<MenuChildItem> {
        public MenuChildItemConfig() {
            HasKey(x => x.Id);
            Property(x => x.Name).IsRequired().HasMaxLength(50);
            Property(x => x.Url).IsRequired().HasMaxLength(400);
            HasRequired(x => x.MenuItem).WithMany(x => x.MenuChildItems)
                .HasForeignKey(x => x.MenuItemId)
                .WillCascadeOnDelete(false);
            Property(x => x.IconUrl).IsOptional().HasMaxLength(400);
            HasOptional(x => x.Language).WithMany(x => x.MenuChildItems)
                .HasForeignKey(x => x.LanguageId)
                .WillCascadeOnDelete(false);
        }
    }
}

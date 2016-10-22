using System.Data.Entity.ModelConfiguration;

namespace HomeProperty.Contacts {
    public class PropertyTypeConfig : EntityTypeConfiguration<PropertyType> {
        public PropertyTypeConfig() {
            HasKey(x => x.Id);
            Property(x => x.Name).IsRequired().HasMaxLength(50);
            HasRequired(x => x.Types).WithMany(x => x.PropertyTypes)
                .HasForeignKey(x => x.TypeId)
                .WillCascadeOnDelete(false);
            HasOptional(x => x.Image).WithMany(x => x.PropertyTypes)
               .HasForeignKey(x => x.ImageId)
               .WillCascadeOnDelete(false);
        }
    }
}

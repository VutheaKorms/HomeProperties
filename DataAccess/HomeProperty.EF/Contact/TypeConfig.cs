using System.Data.Entity.ModelConfiguration;

namespace HomeProperty.Contacts {
    public class TypeConfig : EntityTypeConfiguration<Type> {
        public TypeConfig() {
            HasKey(x => x.Id);
            Property(x => x.Name).IsRequired().HasMaxLength(50);
            HasOptional(x => x.Language).WithMany(x => x.Types)
                .HasForeignKey(x => x.LanguageId)
                .WillCascadeOnDelete(false);
        }
    }
}

using System.Data.Entity.ModelConfiguration;

namespace HomeProperty.Contacts {
    public class EmailTypeConfig : EntityTypeConfiguration<EmailType> {
        public EmailTypeConfig() {
            HasKey(x => x.Id);
            Property(x => x.Name).IsRequired().HasMaxLength(50);
            HasOptional(x => x.Language).WithMany(x => x.EmailTypes)
                .HasForeignKey(x => x.LanguageId)
                .WillCascadeOnDelete(false);
        }
    }
}

using System.Data.Entity.ModelConfiguration;

namespace HomeProperty.Contacts {
    public class EmailConfig : EntityTypeConfiguration<Email> {
        public EmailConfig() {
            HasKey(x => x.Id);
            Property(x => x.Address).IsRequired().HasMaxLength(50);
            HasRequired(x => x.EmailType).WithMany(x => x.Emails)
                .HasForeignKey(x => x.EmailTypeId)
                .WillCascadeOnDelete(false);
        }
    }
}

using System.Data.Entity.ModelConfiguration;

namespace HomeProperty.Contacts
{
    public class PhoneTypeConfig : EntityTypeConfiguration<PhoneType>
    {
        public PhoneTypeConfig()
        {
            HasKey(x => x.Id);
            Property(x => x.Name).IsRequired().HasMaxLength(50);
            HasOptional(x => x.Language).WithMany(x => x.PhoneTypes)
                .HasForeignKey(x => x.LanguageId)
                .WillCascadeOnDelete(false);
        }
    }
}

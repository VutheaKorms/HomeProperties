using System.Data.Entity.ModelConfiguration;

namespace HomeProperty.Contacts
{
    public class PhoneConfig : EntityTypeConfiguration<Phone>
    {
        public PhoneConfig()
        {
            HasKey(x => x.Id);
            Property(x => x.Number).IsRequired().HasMaxLength(50);
            HasRequired(x => x.PhoneType).WithMany(x => x.Phones)
                .HasForeignKey(x => x.PhoneTypeId)
                .WillCascadeOnDelete(false);
        }
    }
}

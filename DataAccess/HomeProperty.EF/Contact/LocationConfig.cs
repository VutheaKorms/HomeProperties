using System.Data.Entity.ModelConfiguration;

namespace HomeProperty.Contacts
{
    public class LocationConfig : EntityTypeConfiguration<Location>
    {
        public LocationConfig()
        {
            HasKey(x => x.Id);
            Property(x => x.Address1).IsRequired().HasMaxLength(255);
            Property(x => x.Address2).IsRequired().HasMaxLength(255);
            HasRequired(x => x.Email).WithMany(x => x.Locations)
                .HasForeignKey(x => x.EmailId)
                .WillCascadeOnDelete(false);
            HasRequired(x => x.Phone).WithMany(x => x.Locations)
                .HasForeignKey(x => x.PhoneId)
                .WillCascadeOnDelete(false);
        }
    }
}

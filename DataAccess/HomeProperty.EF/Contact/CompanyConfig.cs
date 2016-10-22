using System.Data.Entity.ModelConfiguration;

namespace HomeProperty.Contacts
{
    public class CompanyConfig : EntityTypeConfiguration<Company>
    {
        public CompanyConfig()
        {
            HasKey(x => x.Id);
            Property(x => x.CompanyName).IsRequired().HasMaxLength(50);
            HasOptional(x => x.Image).WithMany(x => x.Companies)
              .HasForeignKey(x => x.ImageId)
              .WillCascadeOnDelete(false);
        }
    }
}

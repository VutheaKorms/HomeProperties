using System.Data.Entity.ModelConfiguration;

namespace HomeProperty.Contacts
{
    public class PersonConfig : EntityTypeConfiguration<Person>
    {
        public PersonConfig()
        {
            HasKey(x => x.Id);
            Property(x => x.FirstName).IsRequired().HasMaxLength(50);
            Property(x => x.LastName).IsRequired().HasMaxLength(50);
            HasOptional(x => x.Image).WithMany(x => x.People)
              .HasForeignKey(x => x.ImageId)
              .WillCascadeOnDelete(false);
        }
    }
}

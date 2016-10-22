using System.Data.Entity.ModelConfiguration;

namespace HomeProperty.Contacts
{
    public class CityConfig : EntityTypeConfiguration<City>
    {
        public CityConfig()
        {
            HasKey(x => x.Id);
            Property(x => x.Name).IsRequired().HasMaxLength(50);
            HasOptional(x => x.Language).WithMany(x => x.Cities)
                .HasForeignKey(x => x.LanguageId)
                .WillCascadeOnDelete(false);
        }
    }
}

using System.Data.Entity.ModelConfiguration;

namespace HomeProperty.Contacts
{
    public class StateConfig : EntityTypeConfiguration<State>
    {
        public StateConfig()
        {
            HasKey(x => x.Id);
            Property(x => x.Name).IsRequired().HasMaxLength(50);
            HasRequired(x => x.City).WithMany(x => x.States)
                .HasForeignKey(x => x.CityId)
                .WillCascadeOnDelete(false);
            HasRequired(x => x.Language).WithMany(x => x.States)
               .HasForeignKey(x => x.LanguageId)
               .WillCascadeOnDelete(false);
        }
    }
}

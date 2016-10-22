using System.Data.Entity.ModelConfiguration;

namespace HomeProperty.Contacts
{
    public class CommunityConfig : EntityTypeConfiguration<Community>
    {
        public CommunityConfig()
        {
            HasKey(x => x.Id);
            Property(x => x.Name).IsRequired().HasMaxLength(50);
            HasRequired(x => x.State).WithMany(x => x.Communities)
                .HasForeignKey(x => x.StatId)
                .WillCascadeOnDelete(false);
            HasRequired(x => x.Language).WithMany(x => x.Communities)
               .HasForeignKey(x => x.LanguageId)
               .WillCascadeOnDelete(false);
        }
    }
}

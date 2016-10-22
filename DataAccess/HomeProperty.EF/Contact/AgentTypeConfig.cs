using System.Data.Entity.ModelConfiguration;

namespace HomeProperty.Contacts
{
    public class AgentTypeConfig : EntityTypeConfiguration<AgentType>
    {
        public AgentTypeConfig()
        {
            HasKey(x => x.Id);
            Property(x => x.Name).IsRequired().HasMaxLength(50);
            HasOptional(x => x.Language).WithMany(x => x.AgentTypes)
                .HasForeignKey(x => x.LanguageId)
                .WillCascadeOnDelete(false);
        }
    }
}

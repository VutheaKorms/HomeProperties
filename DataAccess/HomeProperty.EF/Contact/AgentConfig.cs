using System.Data.Entity.ModelConfiguration;

namespace HomeProperty.Contacts
{
    public class AgentConfig : EntityTypeConfiguration<Agent>
    {
        public AgentConfig()
        {
            HasKey(x => x.Id);
            HasRequired(x => x.AgentType).WithMany(x => x.Agents)
                .HasForeignKey(x => x.AgentTypeId)
                .WillCascadeOnDelete(false);
            HasRequired(x => x.Location).WithMany(x => x.Agents)
             .HasForeignKey(x => x.LocationId)
             .WillCascadeOnDelete(false);
        }
    }
}

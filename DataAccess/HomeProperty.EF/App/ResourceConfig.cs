using System.Data.Entity.ModelConfiguration;

namespace HomeProperty.App {
    public class ResourceConfig : EntityTypeConfiguration<Resource> {
        public ResourceConfig() {
            HasKey(x => x.Id);
            Property(x => x.Culture).IsRequired().HasMaxLength(10);
            Property(x => x.Name).IsRequired().HasMaxLength(100);
            Property(x => x.Value).IsRequired().HasMaxLength(4000);
            HasOptional(x => x.Application).WithMany(x => x.Resources)
                .HasForeignKey(x => x.ApplicationId)
                .WillCascadeOnDelete(false);
        }
    }
}

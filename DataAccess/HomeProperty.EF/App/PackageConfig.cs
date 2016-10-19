using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeProperty.EF.App
{
    public class PackageConfig : EntityTypeConfiguration<Package> 
    {
        public PackageConfig()
        {
            HasKey(x => x.Id);
            Property(x => x.Name).IsRequired().HasMaxLength(50);
            HasOptional(x => x.Language).WithMany(x => x.Packages)
                .HasForeignKey(x => x.LanguageId)
                .WillCascadeOnDelete(false);
        }
    }
}

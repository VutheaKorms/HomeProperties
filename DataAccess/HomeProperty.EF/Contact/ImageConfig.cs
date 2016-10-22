using System.Data.Entity.ModelConfiguration;

namespace HomeProperty.Contacts
{
    public class ImageConfig : EntityTypeConfiguration<Image>
    {
        public ImageConfig()
        {
            HasKey(x => x.Id);
            Property(x => x.Name).IsOptional().HasMaxLength(50);
            Property(x => x.FileType).IsOptional();
            Property(x => x.ImageType).IsOptional();
            Property(x => x.Size).IsOptional();
        }
    }
}

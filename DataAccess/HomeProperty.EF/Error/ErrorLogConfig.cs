using System.Data.Entity.ModelConfiguration;

namespace HomeProperty.Error {
    public class ErrorLogConfig : EntityTypeConfiguration<ErrorLog> {
        public ErrorLogConfig() {
            HasKey(x => x.Id);
            Property(x => x.Message).IsRequired().HasMaxLength(1000);
            Property(x => x.StackTrace).IsOptional();
            Property(x => x.LineNumber).IsOptional();
            Property(x => x.FileName).IsOptional().HasMaxLength(255);
            Property(x => x.ErrorInfo).IsOptional().HasMaxLength(255);
            HasOptional(x => x.Application).WithMany(x => x.ErrorLogs)
               .HasForeignKey(x => x.ApplicationId)
               .WillCascadeOnDelete(false);
        }
    }
}

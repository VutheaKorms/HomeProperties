using HomeProperty.EF;
using HomeProperty.EF.App;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeProperty.Error {
    public class ErrorLog : BaseEntity {
        public ErrorLog() {
            IsResolved = false;
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Message { get; set; }
        public DateTime? OccuredDate { get; set; }
        public string ErrorInfo { get; set; }
        public string StackTrace { get; set; }
        public string FileName { get; set; }
        public int? LineNumber { get; set; }
        public Guid? ApplicationId { get; set; }
        public virtual Application Application { get; set; }
        public bool IsResolved { get; set; }
    }
}

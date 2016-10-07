using HomeProperty.App;
using HomeProperty.Error;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeProperty.EF.App {
    public class Application : BaseEntity {
        public Application() {
            ErrorLogs = new HashSet<ErrorLog>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ErrorLog> ErrorLogs { get; set; }
        public virtual ICollection<Resource> Resources { get; set; }
    }
}

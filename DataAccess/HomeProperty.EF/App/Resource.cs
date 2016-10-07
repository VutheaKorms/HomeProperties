using HomeProperty.EF;
using HomeProperty.EF.App;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeProperty.App {
    public class Resource : BaseEntity {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Culture { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public Guid? ApplicationId { get; set; }
        public virtual Application Application { get; set; }
    }
}

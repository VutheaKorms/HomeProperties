using HomeProperty.EF;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeProperty.Contacts {
    public class Email : BaseEntity {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Address { get; set; }
        public Guid EmailTypeId { get; set; }
        public virtual EmailType EmailType { get; set; }
        public bool? IsPrimary { get; set; }
    }
}

using HomeProperty.EF;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace HomeProperty.Contacts
{
    public class Phone : BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Number { get; set; }
        public Guid PhoneTypeId { get; set; }
        public virtual PhoneType PhoneType { get; set; }
        public bool? IsPrimary { get; set; }
        public ICollection<Location> Locations { get; internal set; }
    }
}

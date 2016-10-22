using HomeProperty.EF;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace HomeProperty.Contacts
{
    public class Location : BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public Guid EmailId { get; set; }
        public virtual Email Email { get; set; }
        public Guid PhoneId { get; set; }
        public virtual Phone Phone { get; set; }
        public string site { get; set; }
        public ICollection<Agent> Agents { get; set; }
    }
}

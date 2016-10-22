using HomeProperty.App;
using HomeProperty.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeProperty.Contacts
{
    public class PhoneType : BaseLookupEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Phone> Phones { get; set; }
        public Guid? LanguageId { get; set; }
        public Language Language { get; set; }
    }
}

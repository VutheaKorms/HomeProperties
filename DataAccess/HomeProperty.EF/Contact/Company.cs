using HomeProperty.App;
using HomeProperty.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeProperty.Contacts
{
    public class Company : BaseLookupEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string CompanyName { get; set; }
        public Guid? ImageId { get; set; }
        public Image Image { get; set; }
    }
}

using HomeProperty.EF;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using HomeProperty.App;

namespace HomeProperty.Contacts
{
    public class State : BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid CityId { get; set; }
        public virtual City City { get; set; }
        public Guid? LanguageId { get; set; }
        public Language Language { get; set; }
        public ICollection<Community> Communities { get; set; }
    }
}

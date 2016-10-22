using HomeProperty.EF;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using HomeProperty.App;

namespace HomeProperty.Contacts
{
    public class Community : BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid StatId { get; set; }
        public virtual State State { get; set; }
        public Guid? LanguageId { get; set; }
        public Language Language { get; set; }
    }
}

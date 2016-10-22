using HomeProperty.App;
using HomeProperty.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeProperty.Contacts
{
    public class Agent : BaseLookupEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid AgentTypeId { get; set; }
        public virtual AgentType AgentType { get; set; }
        public Guid LocationId { get; set; }
        public virtual Location Location { get; set; }
        public Guid? LanguageId { get; set; }
        public Language Language { get; set; }
    }
}

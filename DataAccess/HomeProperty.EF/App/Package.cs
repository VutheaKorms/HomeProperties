using HomeProperty.App;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeProperty.EF.App
{
    public class Package : BaseLookupEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Duration { get; set; }
        public string NumberPhoto { get; set; }
        public string NumberProperty { get; set; }
        public string NumberVideo { get; set; }
        public string Type { get; set; }
        public string Price { get; set; }
        public Guid? LanguageId { get; set; }
        public Language Language { get; set; }
    }
}

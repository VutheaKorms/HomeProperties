using HomeProperty.EF;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeProperty.App {
    public class MenuChildItem : BaseEntity {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string IconUrl { get; set; }
        public Guid MenuItemId { get; set; }
        public virtual MenuItem MenuItem { get; set; }
        public Guid? LanguageId { get; set; }
        public Language Language { get; set; }
    }
}

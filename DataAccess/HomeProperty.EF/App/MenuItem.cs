using HomeProperty.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeProperty.App {
    public class MenuItem : BaseEntity {
        public MenuItem() {
            MenuChildItems = new HashSet<MenuChildItem>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string IconUrl { get; set; }
        public Guid MenuId { get; set; }
        public virtual Menu Menu { get; set; }
        public virtual ICollection<MenuChildItem> MenuChildItems { get; set; }
        public Guid? LanguageId { get; set; }
        public Language Language { get; set; }
    }
}

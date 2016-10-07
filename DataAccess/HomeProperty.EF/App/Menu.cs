using HomeProperty.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeProperty.App {
    public class Menu : BaseEntity {
        public Menu() {
            MenuItems = new HashSet<MenuItem>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string NameConstant { get; set; }
        public virtual ICollection<MenuItem> MenuItems { get; set; }
    }
}

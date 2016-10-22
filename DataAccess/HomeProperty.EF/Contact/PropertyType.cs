using HomeProperty.EF;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace HomeProperty.Contacts {
    public class PropertyType : BaseEntity {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? ImageId { get; set; }
        public Image Image { get; set; }
        public Guid TypeId { get; set; }
        public virtual Type Types { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace HomeProperty.WebApp.Models {
    public class ViewModelBase {
        public ViewModelBase() {
            ModifiedDate = DateTime.UtcNow;
            IsActive = true;
        }
        public DateTime? ModifiedDate { get; set; }
        public Guid? ModifiedBy { get; set; }
        public bool IsActive { get; set; }
        [StringLength(250)]
        public string Description { get; set; }
    }
}
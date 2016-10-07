using HomeProperty.View.Hypermedia;
using System;
using System.ComponentModel.DataAnnotations;

namespace HomeProperty.View {

    public class BaseView : Resource {
        public BaseView() {
            ModifiedDate = DateTime.UtcNow;
            IsActive = true;
            //Options = null;
        }
        public DateTime? ModifiedDate { get; set; }
        public Guid? ModifiedBy { get; set; }
        public bool IsActive { get; set; }
        [StringLength(250)]
        public string Description { get; set; }
        // Include option information 
        // if we return multiple records in a collection
        //public FlexibleView Options { get; set; }
    }
}

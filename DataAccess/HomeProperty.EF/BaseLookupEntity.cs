using System.ComponentModel.DataAnnotations;

namespace HomeProperty.EF {
    public class BaseLookupEntity : BaseEntity {

        [StringLength(80)]
        public string Code { get; set; }
    }
}

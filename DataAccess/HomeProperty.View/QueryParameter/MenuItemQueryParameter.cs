using System;

namespace HomeProperty.View.QueryParameter {
    public class MenuItemQueryParameter : QueryParameterBase {
        public Guid MenuId { get; set; }
        public Guid[] Identities { get; set; }
        public string MenuName { get; set; }
        public string languageId { get; set; }
    }
}

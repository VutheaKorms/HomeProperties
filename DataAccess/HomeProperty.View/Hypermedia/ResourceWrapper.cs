using System;
using System.Collections.Generic;

namespace HomeProperty.View.Hypermedia {
    public class ResourceWrapper : Resource {
        public int Page { get; set; }
        public int Size { get; set; }
        public string Sort { get; set; }
        public string Filter { get; set; }
        public int TotalRecords { get; set; }
        public IEnumerable<object> Records { get; set; }
        public string ApplicationType { get; set; }
        public Type RecordType { get; set; }

        public bool ShouldSerializeRecordType() {
            return false;
        }
        public bool ShouldSerializeApplicationType() {
            return false;
        }
    }
}

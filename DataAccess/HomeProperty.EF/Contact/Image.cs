using HomeProperty.App;
using HomeProperty.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeProperty.Contacts
{
    public class Image : BaseLookupEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
        public string ImageType { get; set; }
        public string FileType { get; set; }
        public string FullPath { get; set; }
        public string SmallPath { get; set; }
        public string ThumbPath { get; set; }
        public string BigPath { get; set; }
        public ICollection<PropertyType> PropertyTypes { get; set; }
        public ICollection<Person> People { get; set; }
        public ICollection<Company> Companies { get; set; }
    }
}

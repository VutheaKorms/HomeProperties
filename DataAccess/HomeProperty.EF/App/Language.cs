using HomeProperty.Contacts;
using HomeProperty.EF;
using HomeProperty.EF.App;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeProperty.App
{
    public class Language : BaseEntity {
        public Language() {
            MenuItems = new HashSet<MenuItem>();
            MenuChildItems = new HashSet<MenuChildItem>();
            EmailTypes = new HashSet<EmailType>();
            Packages = new HashSet<Package>();
            Types = new HashSet<Contacts.Type>();
            PhoneTypes = new HashSet<PhoneType>();
            AgentTypes = new HashSet<AgentType>();
            Cities = new HashSet<City>();
            States = new HashSet<State>();
            Communities = new HashSet<Community>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Locale { get; set; }
        public virtual ICollection<MenuItem> MenuItems { get; set; }
        public virtual ICollection<MenuChildItem> MenuChildItems { get; set; }
        public virtual ICollection<EmailType> EmailTypes { get; set; }
        public virtual ICollection<Package> Packages { get; set; }
        public virtual ICollection<Contacts.Type> Types { get; set; }
        public virtual ICollection<PhoneType> PhoneTypes { get; set; }
        public virtual ICollection<AgentType> AgentTypes { get; set; }
        public virtual ICollection<City> Cities { get; set; }
        public virtual ICollection<State> States { get; set; }
        public virtual ICollection<Community> Communities { get; set; }
    }
}

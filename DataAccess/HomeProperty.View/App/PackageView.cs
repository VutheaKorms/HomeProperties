using FluentValidation.Attributes;
using HomeProperty.View.AppValidator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeProperty.View.App
{
    [Validator(typeof(PckageViewValidator))]
    public class PackageView : BaseView
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Duration { get; set; }
        public string NumberPhoto { get; set; }
        public string NumberProperty { get; set; }
        public string Price { get; set; }
        public string NumberVideo { get; set; }
        public string Type { get; set; }
        public Guid? LanguageId { get; set; }
    }
}

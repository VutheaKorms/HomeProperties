using System;

namespace HomeProperty.Service.Models {
    public class AddContactViewModel {
        public Guid PersonId { get; set; }
        public string Description { get; set; }
    }

    public class AddPhonetypeViewModel {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class AddPhoneViewModel {
        public string Number { get; set; }

        public Guid PhoneTypeId { get; set; }

        public Boolean IsPrimary { get; set; }

        public Guid ContactId { get; set; }

        public string Description { get; set; }
    }


    public class AddEmailtypeViewModel {
        public string Name { get; set; }
        public string Description { get; set; }
    }


    public class AddEmailViewModel {
        public string Address { get; set; }

        public Guid EmailTypeId { get; set; }

        public Boolean IsPrimary { get; set; }

        public Guid ContactId { get; set; }

        public string Description { get; set; }
    }

    public class AddFaxViewModel {
        public string Number { get; set; }

        public Guid EmailTypeId { get; set; }

        public Boolean IsPrimary { get; set; }

        public Guid ContactId { get; set; }

        public string Description { get; set; }
    }


    public class AddWebsiteViewModel {
        public string Url { get; set; }

        public Guid ContactId { get; set; }

        public string Description { get; set; }
    }


    public class AddInstantMessagetypeViewModel {
        public string Name { get; set; }
        public string Description { get; set; }
    }


    public class AddInstantMessageViewModel {
        public string Account { get; set; }

        public Guid InstantMessageTypeId { get; set; }

        public Guid ContactId { get; set; }

        public string Description { get; set; }
    }




}
// The personal information view model class
var PersonalInfoViewModel = function () {
    var self = this;

    self.firstName = ko.observable("Sith");
    self.lastName = ko.observable("Kong");
    self.preferredName = ko.observable("Soriya");
    self.streetAddress = ko.observable();
    self.city = ko.observable();
    self.stateId = ko.observable();
    self.states = ko.observableArray([]);
    self.zipCode = ko.observable();
    // I will need to add them in the form.
    self.countryId = ko.observable();
    self.countries = ko.observableArray();

    function submitPersonalInfoForm() {
        var personalInfoForm = $('#peronalInfoForm');
        personalInfoForm.submit(function () {
            return false;
        });
        $('#savePersonalInfo').click(function () {
            // alert('You are saving peronsal information.');
            if (!$('#peronalInfoForm').valid())
                return false;
        });
    }
    submitPersonalInfoForm();
};

// The contact view model class
var ContactViewModel = function () {
    var self = this;
    function submitContactForm() {
        $('#contactForm').submit(function () {
            return false;
        });
        $('#saveContact').click(function () {
            alert('You are saving contact information.');
        });
    }
    submitContactForm();
};

// The education view model class
var EducationViewModel = function () {
    var self = this;
    function submitEducationForm() {
        $('#educationForm').submit(function () {
            return false;
        });
        $('#saveEducation').click(function () {
            alert('You are saving education information.');
        });
    }
    submitEducationForm();
};

// The position view model class
var PositionViewModel = function () {
    var self = this;
    function submitPositionForm() {
        $('#positionForm').submit(function () {
            return false;
        });
        $('#savePosition').click(function () {
            alert('You are saving position information.');
        });
    }
    submitPositionForm();
};

// The documents view model cass 
var DocumentsViewModel = function () {
    var self = this;
    function submitDocumentsForm() {
        $('#documentsForm').submit(function () {
            return false;
        });
        $('#saveDocuments').click(function () {
            alert('You are saving documents information.');
        });
    }
    submitDocumentsForm();
};

// The membeship view model class 
// serves as the container for all
// view model classes of the Add Membership page.
var MembershipViewModel = function (params) {
    this.personalInfo = ko.observable(params.personalInfo);
    this.contact = ko.observable(params.contact);
    this.education = ko.observable(params.education);
    this.position = ko.observable(params.position);
    this.documents = ko.observable(params.documents);
};

// Validate personal information form
// @message - the validation messages
function validatePersonalInfoForm(messages) {
    $('#peronalInfoForm').validate({
        rules: {
            firstName: { required: true },
            lastName: { required: true },
            streetAddress: { required: true },
            city: { required: true },
            state: { selectRequired: true },
            zipCode: { required: true }
        },
        messages: {
            firstName: messages.firstName,
            lastName: messages.lastName,
            streetAddress: messages.streetAddress,
            city: messages.city,
            state: messages.state,
            zipCode: messages.zipCode
        }
    });
}

// Validates the contact form
// @messages - the validation messages
function validateContactForm() {
    return true; 
}

// Validates education form
// @messages - the validation messages
function validateEducationForm(messages) {
    return true;
}

// Validates position form 
// @messages - the validation messages
function validatePositionForm(messages) {
    return true;
}

// Validates documents form
// @messages - the validation messages
function validateDocumentsForm(messages) {
    return true; 
}
// Page load 
(function ($) {
    var params = {
        personalInfo: new PersonalInfoViewModel(),
        contact: new ContactViewModel(),
        education: new EducationViewModel(),
        position: new PositionViewModel(),
        documents: new DocumentsViewModel()
    };
    ko.applyBindings(new MembershipViewModel(params));
})(jQuery);
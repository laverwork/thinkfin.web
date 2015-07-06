var companyViewModel;

function Company(id, code, name) {
    var self = this;

    self.Id = ko.observable(id);
    self.Code = ko.observable(code);
    self.Name = ko.observable(name);
}


function CompanyList() {
    var self = this;

    self.companies = ko.observableArray([]);

    self.getCompanies = function() {
        self.companies.removeAll();

        $.getJSON('/api/marketdata', function(data) {
            $.each(data, function(key, value) {
                self.companies.push(new Company(value.Id, value.Code, value.Name));
            });
        });
    }
}

companyViewModel = { companyListViewModel: new CompanyList() }

$(document).ready(function() {

    ko.applyBindings(companyViewModel);

    companyViewModel.companyListViewModel.getCompanies();
})
function ViewModel() {
    var self = this;

    self.RegisterEmail = ko.observable(sessionStorage.getItem("registerEmail"));

}

var app = new ViewModel();
ko.applyBindings(app);
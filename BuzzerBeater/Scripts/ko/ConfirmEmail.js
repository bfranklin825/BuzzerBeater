function ViewModel() {
    var self = this;

    self.RegisterEmail = ko.observable(sessionStorage.getItem("registerEmail"));
    self.CallbackURL = ko.obervable(sessionStorage.getItem("callbackURL"));

}

var app = new ViewModel();
ko.applyBindings(app);
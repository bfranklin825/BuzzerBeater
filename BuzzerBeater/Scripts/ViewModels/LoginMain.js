require(['ko', 'ViewModels/LoginViewModel', 'domReady!'], function (ko, viewModel) {
    ko.applyBindings(new viewModel());
});
define(["ko", "koVal", "BuzzModel", "BindingHandlers", "CustomFunctions"], function (ko, koVal, model, bh, cf) {

    // Don't automatically show validation error messages
    ko.validation.init({ insertMessages: false });

    return function viewModel() {
        var self = this;

        //! Declarations
        var tokenKey = 'accessToken';

        self.result = ko.observable();
        self.user = ko.observable();

        self.registerEmail = ko.observable(sessionStorage.getItem("registerEmail") || "");
        self.registerPassword = ko.observable();
        self.registerPassword2 = ko.observable();

        self.CallbackURL = ko.observable(sessionStorage.getItem("callbackURL") || "");

        console.log(self.registerEmail());
        console.log(self.CallbackURL());

        self.loginEmail = ko.observable();
        self.loginPassword = ko.observable();

        function showError(jqXHR) {
            self.result(jqXHR.status + ': ' + jqXHR.statusText);
        }

        self.register = function () {
            self.result('');
            var data = {
                Email: self.registerEmail(),
                Password: self.registerPassword(),
                ConfirmPassword: self.registerPassword2()
            };

            //$.ajax({
            //    type: 'POST',
            //    url: '/api/Account/Register',
            //    contentType: 'application/json; charset=utf-8',
            //    data: JSON.stringify(data)
            //}).done(function (data) {
            //    sessionStorage.setItem("callbackURL", data)
            //    sessionStorage.setItem("registerEmail", self.registerEmail());
            //    window.location.href = '/Home/EmailVerification';
            //}).fail(showError);

            $.ajax({
                type: "POST",
                url: '/api/Account/Register',
                data: JSON.stringify(data),
                contentType: "application/json; charset=utf-8",
                dataType: 'json',
                success: function (data) {
                    sessionStorage.setItem("callbackURL", data)
                    sessionStorage.setItem("registerEmail", self.registerEmail());
                    window.location.href = '/Home/EmailVerification';
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    console.log(xhr);
                    console.log(ajaxOptions);
                    console.log(thrownError);


                    self.result(JSON.parse(xhr.responseText).Message);
                },
                complete: function (data) {

                }
            });

        }

        self.login = function () {
            self.result('');

            var loginData = {
                grant_type: 'password',
                username: self.loginEmail(),
                password: self.loginPassword()
            };

            $.ajax({
                type: 'POST',
                url: '/Token',
                data: loginData
            }).done(function (data) {
                self.user(data.userName);
                // Cache the access token in session storage.
                sessionStorage.setItem(tokenKey, data.access_token);
                window.location.href = '/';
            }).fail(showError);
        }

        self.logout = function () {
            var token = sessionStorage.getItem(tokenKey);
            var headers = {};
            if (token) {
                headers.Authorization = 'Bearer ' + token;
            }

            $.ajax({
                type: 'POST',
                url: 'api/Account/Logout',
                contentType: 'application/json; charset=utf-8',
                headers: headers
            }).done(function (data) {
                self.user('');
                sessionStorage.removeItem(tokenKey)
                window.location.href = '/';
            }).fail(showError);
        }
    }
});
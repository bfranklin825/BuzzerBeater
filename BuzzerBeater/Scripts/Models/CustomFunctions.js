define("CustomFunctions", ['ko'], function (ko) {

    //! Import this to use custom functions

    function CustomFunctions() {

        // USAGE:
        // self.choice = { id: 2, name: "two"};
        // self.choices = ko.observableArray({array of choices});
        // To get the name:
        // self.choices.find("id", choice).name; == "two"
        // http://jsfiddle.net/rniemeyer/zp79w/
        // Find function for observable array to select current record's property value in a dropdown/select
        ko.observableArray.fn.find = function (prop, data) {
            var valueToMatch = data[prop];
            return ko.utils.arrayFirst(this(), function (item) {
                return item[prop] === valueToMatch;
            });
        };

        // Same as above, but with observables that are unwrapped against observables that are not
        ko.observableArray.fn.findObs = function (prop, data) {
            var valueToMatch = data[prop];
            return ko.utils.arrayFirst(this(), function (item) {
                return item[prop]() === valueToMatch;
            });
        };

        // USAGE: myObject.subscribeChanged(function (newValue, oldValue) { do stuff });
        // http://stackoverflow.com/questions/12822954/get-previous-value-of-an-observable-in-subscribe-of-same-observable
        // Can figure out what the old value of a changing object was and what the new value will be,
        // instead of just the new value
        ko.subscribable.fn.subscribeChanged = function (callback) {
            var oldValue;
            this.subscribe(function (_oldValue) {
                oldValue = _oldValue;
            }, this, 'beforeChange');
            this.subscribe(function (newValue) {
                callback(newValue, oldValue);
            });
        };

        // Custom function to allow internal change tracking
        ko.subscribable.fn.withUpdater = function (handler, target, propname, originalValue) {
            var _oldValue;
            this.subscribe(function (oldValue) {
                _oldValue = oldValue;
            }, null, 'beforeChange');
            this.subscribe(function (newValue) {
                handler.call(target, _oldValue, newValue, propname, originalValue);
            });
            return this;
        };

    }

    return new CustomFunctions()

});
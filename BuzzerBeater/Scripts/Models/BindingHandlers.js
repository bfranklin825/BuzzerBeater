define("BindingHandlers", ['ko'], function (ko) {

    //! Import this to use binding handlers

    function BindingHandlers() {

        // Sorting binding handler - used for non-server-side sorting
        ko.bindingHandlers.sort = {
            init: function (element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
                var asc = false;
                element.style.cursor = 'pointer';
                element.onclick = function () {
                    var value = valueAccessor();
                    var prop = value.prop;
                    var data = value.arr;
                    asc = !asc;
                    data.sort(function (left, right) {
                        var rec1 = left;
                        var rec2 = right;
                        if (!asc) {
                            rec1 = right;
                            rec2 = left;
                        }

                        var props = prop.split('.');

                        for (var i in props) {
                            var propName = props[i];
                            var parenIndex = propName.indexOf('()');
                            if (parenIndex > 0) {
                                propName = propName.substring(0, parenIndex);
                                rec1 = rec1[propName]();
                                rec2 = rec2[propName]();
                            } else {
                                rec1 = rec1[propName];
                                rec2 = rec2[propName];
                            }
                        }

                        return rec1 == rec2 ? 0 : rec1 < rec2 ? -1 : 1;

                    });
                };
            }
        };

        // Custom binding handler for 'dateString' binding - a way format a date and keep it a date without having to convert it to string. Sorting dates as strings doesn't work the same.
        // Requires moment.js
        ko.bindingHandlers.dateString = {
            update: function (element, valueAccessor, allBindingsAccessor, viewModel) {
                var value = valueAccessor(),
                    allBindings = allBindingsAccessor();
                var valueUnwrapped = ko.utils.unwrapObservable(value);
                var pattern = allBindings.datePattern || 'dd/mm/yyyy';
                if (valueUnwrapped == undefined || valueUnwrapped == null) {
                    // For text properties
                    $(element).text("");
                    // For input values
                }
                else {
                    var date = moment(valueUnwrapped, "YYYY-MM-DDTHH:mm:ss");
                    // For text properties
                    $(element).text(moment(date).format(pattern));
                    // For input values
                    $(element).val(moment(date).format(pattern));
                }
            }
        }

        // Custom binding handler to show a formatted date in a bootstrap date picker
        //TODO: figure out why it won't highlight the selected date - pop up opens on selected month, but no date is highlighted
        ko.bindingHandlers.datepicker = {
            init: function (element, valueAccessor, allBindingsAccessor) {
                // Initialize date picker with some optional options
                var options = allBindingsAccessor().datepickerOptions || {};
                $(element).datepicker(options);

                // Set initial date in placeholder...
                var value = valueAccessor(),
                    allBindings = allBindingsAccessor();;
                var valueUnwrapped = ko.utils.unwrapObservable(value);
                var pattern = allBindings.datePattern || 'dd/mm/yyyy';

                // If no value exists, put a message in the placeholder
                if (valueUnwrapped == undefined || valueUnwrapped == null) {
                    valueUnwrapped = "Choose Date";
                    ko.applyBindingsToNode(element, { attr: { placeholder: valueUnwrapped } });
                } else { // Set the date
                    var date = new Date(valueUnwrapped);
                    $(element).datepicker('setDate', date);
                }
            },
            update: function (element, valueAccessor) {
            }
        };

        // Dialog binding handler
        ko.bindingHandlers.dialog = {
            init: function (element, valueAccessor, allBindingsAccessor) {
                var options = ko.utils.unwrapObservable(valueAccessor()) || {};
                //do in a setTimeout, so the applyBindings doesn't bind twice from element being copied and moved to bottom
                setTimeout(function () {
                    options.close = function () {
                        allBindingsAccessor().dialogVisible(false);
                    };

                    $(element).dialog(options);
                }, 0);

                ko.utils.domNodeDisposal.addDisposeCallback(element, function () {
                    $(element).dialog("destroy");
                });
            },
            update: function (element, valueAccessor, allBindingsAccessor) {
                var shouldBeOpen = ko.utils.unwrapObservable(allBindingsAccessor().dialogVisible),
                    $el = $(element),
                    dialog = $el.data("uiDialog") || $el.data("dialog");

                //don't call open/close before initialization
                if (dialog) {
                    $el.dialog(shouldBeOpen ? "open" : "close");
                }
            }
        };

        // Custom binding handler to hide stuff :)
        // USAGE:
        //      <span data-bind="hidden: myobject">Only show me when myobject is empty.</span>
        // VERSUS:
        //      <span data-bind="visible: !myObject()">Only show me when myobject is empty.</span>
        ko.bindingHandlers.hidden = {
            update: function (element, valueAccessor) {
                ko.bindingHandlers.visible.update(element, function () {
                    return !ko.utils.unwrapObservable(valueAccessor());
                });
            }
        };

    }

    return new BindingHandlers();

});
requirejs.config({
    baseUrl: '../Scripts',
    paths: {
        'jquery': 'jquery-2.2.0',
        'bootstrap': 'bootstrap',
        'ko': 'knockout-3.4.0',
        'koVal': 'knockout.validation.min',
        'BuzzModel': 'Models/BuzzModel',     
        'BindingHandlers': 'Models/BindingHandlers',
        'CustomFunctions': 'Models/CustomFunctions'
        //'LoginMain': 'ViewModels/LoginMain'
    },
    shim: {
        'koVal': {
            deps: ['knockout-3.4.0']
        }
        //Dependency section for legacy scripts that can't be loaded via the requriejs 'define()' method
        //EX:
        //'foo': {
        //    deps: ['bar'],
        //    exports: 'Foo',
        //    init: function (bar) {
        //          Using a function allows you to call noConflict for
        //          libraries that support it, and do other cleanup.
        //          However, plugins for those libraries may still want
        //          a global. "this" for the function will be the global
        //          object. The dependencies will be passed in as
        //          function arguments. If this function returns a value,
        //          then that value is used as the module export value
        //          instead of the object found via the 'exports' string.
        //          Note: jQuery registers as an AMD module via define(),
        //          so this will not work for jQuery.
        //
        //        return this.foo.noConflict();
        //    }
        //}
    }
});
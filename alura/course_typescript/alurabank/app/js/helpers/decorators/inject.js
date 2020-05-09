System.register([], function (exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    function inject(selector) {
        return function (target, key) {
            let element;
            const get = function () {
                if (!element) {
                    console.log(`Finding ${selector} in DOM for property ${key}`);
                    element = $(selector);
                }
                return element;
            };
            Object.defineProperty(target, key, {
                get,
            });
        };
    }
    exports_1("inject", inject);
    return {
        setters: [],
        execute: function () {
        }
    };
});
//# sourceMappingURL=inject.js.map
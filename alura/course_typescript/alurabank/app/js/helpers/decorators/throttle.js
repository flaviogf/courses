System.register([], function (exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    function throttle(milliseconds = 500) {
        return function (target, propertyKey, descriptor) {
            const method = descriptor.value;
            let timer;
            descriptor.value = function (...args) {
                if (event)
                    event.preventDefault();
                clearTimeout(timer);
                timer = setTimeout(() => method.apply(this, args), milliseconds);
            };
            return descriptor;
        };
    }
    exports_1("throttle", throttle);
    return {
        setters: [],
        execute: function () {
        }
    };
});
//# sourceMappingURL=throttle.js.map
System.register([], function (exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    function duration() {
        return function (target, propertKey, descriptor) {
            const method = descriptor.value;
            descriptor.value = function (...args) {
                const t1 = performance.now();
                const result = method.apply(this, args);
                const t2 = performance.now();
                console.log(`Has been passed ${t2 - t1} ms`);
                return result;
            };
            return descriptor;
        };
    }
    exports_1("duration", duration);
    return {
        setters: [],
        execute: function () {
        }
    };
});
//# sourceMappingURL=duration.js.map
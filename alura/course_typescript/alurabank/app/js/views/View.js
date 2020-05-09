System.register([], function (exports_1, context_1) {
    "use strict";
    var View;
    var __moduleName = context_1 && context_1.id;
    return {
        setters: [],
        execute: function () {
            View = class View {
                constructor(selector, escape = true) {
                    this._element = $(selector);
                    this._escape = escape;
                }
                update(model) {
                    if (!this._escape) {
                        this._element.html(this.template(model));
                        return;
                    }
                    this._element.html(this.template(model).replace(/<script>[\s\S]*?<\/script>/, ""));
                }
            };
            exports_1("View", View);
        }
    };
});
//# sourceMappingURL=View.js.map
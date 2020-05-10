System.register(["./controllers/NegotiationController"], function (exports_1, context_1) {
    "use strict";
    var NegotiationController_1, controller;
    var __moduleName = context_1 && context_1.id;
    return {
        setters: [
            function (NegotiationController_1_1) {
                NegotiationController_1 = NegotiationController_1_1;
            }
        ],
        execute: function () {
            controller = new NegotiationController_1.NegotiationController();
            $("button[type=button]").click(controller.import.bind(controller));
            $("form").submit(controller.add.bind(controller));
        }
    };
});
//# sourceMappingURL=app.js.map
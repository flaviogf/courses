System.register(["../models/Negotiation"], function (exports_1, context_1) {
    "use strict";
    var Negotiation_1, NegotiationService;
    var __moduleName = context_1 && context_1.id;
    return {
        setters: [
            function (Negotiation_1_1) {
                Negotiation_1 = Negotiation_1_1;
            }
        ],
        execute: function () {
            NegotiationService = class NegotiationService {
                getNegotiations(handler) {
                    return fetch("http://localhost:8080/dados")
                        .then(handler)
                        .then((res) => res.json())
                        .then((data) => data.map((it) => new Negotiation_1.Negotiation(new Date(), it.montante, it.vezes)));
                }
            };
            exports_1("NegotiationService", NegotiationService);
        }
    };
});
//# sourceMappingURL=NegotiationService.js.map
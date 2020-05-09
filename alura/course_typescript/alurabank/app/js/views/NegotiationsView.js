System.register(["./View"], function (exports_1, context_1) {
    "use strict";
    var View_1, NegotiationsView;
    var __moduleName = context_1 && context_1.id;
    return {
        setters: [
            function (View_1_1) {
                View_1 = View_1_1;
            }
        ],
        execute: function () {
            NegotiationsView = class NegotiationsView extends View_1.View {
                template(model) {
                    const dateFormatter = new Intl.DateTimeFormat("en-US", {
                        year: "numeric",
                        month: "long",
                        day: "numeric",
                    });
                    const numberFormatter = new Intl.NumberFormat("en-US", {
                        style: "currency",
                        currency: "USD",
                    });
                    return model
                        .toArray()
                        .map((it) => {
                        const date = dateFormatter.format(it.date);
                        const volume = numberFormatter.format(it.volume);
                        return `
        <li class="list-group-item d-flex justify-content-between align-items-center">
            ${date}
            <span class="badge badge-primary badge-pill">${volume}</span>
        </li>`;
                    })
                        .join("");
                }
            };
            exports_1("NegotiationsView", NegotiationsView);
        }
    };
});
//# sourceMappingURL=NegotiationsView.js.map
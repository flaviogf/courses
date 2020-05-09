System.register(["../models/Negotiation", "../models/Negotiations", "../views/MessageView", "../views/NegotiationsView"], function (exports_1, context_1) {
    "use strict";
    var Negotiation_1, Negotiations_1, MessageView_1, NegotiationsView_1, NegotiationController, WeekDays;
    var __moduleName = context_1 && context_1.id;
    return {
        setters: [
            function (Negotiation_1_1) {
                Negotiation_1 = Negotiation_1_1;
            },
            function (Negotiations_1_1) {
                Negotiations_1 = Negotiations_1_1;
            },
            function (MessageView_1_1) {
                MessageView_1 = MessageView_1_1;
            },
            function (NegotiationsView_1_1) {
                NegotiationsView_1 = NegotiationsView_1_1;
            }
        ],
        execute: function () {
            NegotiationController = class NegotiationController {
                constructor() {
                    this._negotiations = new Negotiations_1.Negotiations();
                    this._negotiationsView = new NegotiationsView_1.NegotiationsView("#negotiations");
                    this._messageView = new MessageView_1.MessageView("#message");
                    this._dateInput = $("#date");
                    this._amountInput = $("#amount");
                    this._valueInput = $("#value");
                    this._negotiationsView.update(this._negotiations);
                }
                add(event) {
                    event.preventDefault();
                    const date = this._getDate();
                    const amount = this._getAmount();
                    const value = this._getValue();
                    if (!this._isBusinessDay(date)) {
                        this._messageView.update("Negotiations are only allowed in business days!");
                        return;
                    }
                    const negotiation = new Negotiation_1.Negotiation(date, amount, value);
                    this._negotiations.adiciona(negotiation);
                    this._negotiationsView.update(this._negotiations);
                    this._messageView.update("Negotiation has been added successfully!");
                }
                _getDate() {
                    var _a;
                    const value = (_a = this._dateInput.val()) === null || _a === void 0 ? void 0 : _a.toString();
                    if (!value) {
                        return new Date();
                    }
                    return new Date(value.replace(/-/g, ","));
                }
                _getAmount() {
                    const value = this._amountInput.val();
                    if (!value) {
                        return 0;
                    }
                    return Number(value);
                }
                _getValue() {
                    const value = this._valueInput.val();
                    if (!value) {
                        return 0;
                    }
                    return Number(value);
                }
                _isBusinessDay(date) {
                    return (date.getDay() !== WeekDays.Sunday && date.getDay() !== WeekDays.Saturday);
                }
            };
            exports_1("NegotiationController", NegotiationController);
            (function (WeekDays) {
                WeekDays[WeekDays["Sunday"] = 0] = "Sunday";
                WeekDays[WeekDays["Monday"] = 1] = "Monday";
                WeekDays[WeekDays["Tuesday"] = 2] = "Tuesday";
                WeekDays[WeekDays["Wednesday"] = 3] = "Wednesday";
                WeekDays[WeekDays["Thursday"] = 4] = "Thursday";
                WeekDays[WeekDays["Friday"] = 5] = "Friday";
                WeekDays[WeekDays["Saturday"] = 6] = "Saturday";
            })(WeekDays || (WeekDays = {}));
        }
    };
});
//# sourceMappingURL=NegotiationController.js.map
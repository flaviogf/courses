System.register(["../helpers/decorators/inject", "../helpers/decorators/throttle", "../helpers/utils/print", "../models/Negotiation", "../models/Negotiations", "../services/NegotiationService", "../views/MessageView", "../views/NegotiationsView"], function (exports_1, context_1) {
    "use strict";
    var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
        var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
        if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
        else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
        return c > 3 && r && Object.defineProperty(target, key, r), r;
    };
    var inject_1, throttle_1, print_1, Negotiation_1, Negotiations_1, NegotiationService_1, MessageView_1, NegotiationsView_1, NegotiationController, WeekDays;
    var __moduleName = context_1 && context_1.id;
    return {
        setters: [
            function (inject_1_1) {
                inject_1 = inject_1_1;
            },
            function (throttle_1_1) {
                throttle_1 = throttle_1_1;
            },
            function (print_1_1) {
                print_1 = print_1_1;
            },
            function (Negotiation_1_1) {
                Negotiation_1 = Negotiation_1_1;
            },
            function (Negotiations_1_1) {
                Negotiations_1 = Negotiations_1_1;
            },
            function (NegotiationService_1_1) {
                NegotiationService_1 = NegotiationService_1_1;
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
                    this._negotiationService = new NegotiationService_1.NegotiationService();
                    this._negotiationsView.update(this._negotiations);
                }
                add() {
                    const date = this._getDate();
                    const amount = this._getAmount();
                    const value = this._getValue();
                    if (!this._isBusinessDay(date)) {
                        this._messageView.update("Negotiations are only allowed in business days!");
                        return;
                    }
                    const negotiation = new Negotiation_1.Negotiation(date, amount, value);
                    this._negotiations.add(negotiation);
                    this._negotiationsView.update(this._negotiations);
                    this._messageView.update("Negotiation has been added successfully!");
                    print_1.print(negotiation, this._negotiations);
                }
                import() {
                    this._negotiationService
                        .getNegotiations((res) => {
                        if (res.ok) {
                            return res;
                        }
                        throw new Error("It wasn't able to complete");
                    })
                        .then((negotiations) => {
                        const notRepeated = negotiations.filter((negotiation) => !this._negotiations.toArray().some((it) => it.isEqual(negotiation)));
                        return notRepeated;
                    })
                        .then((negotiations) => {
                        negotiations.forEach((it) => this._negotiations.add(it));
                    })
                        .then(() => {
                        this._negotiationsView.update(this._negotiations);
                    })
                        .catch((err) => {
                        this._messageView.update(err.message);
                    });
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
            __decorate([
                inject_1.inject("#date")
            ], NegotiationController.prototype, "_dateInput", void 0);
            __decorate([
                inject_1.inject("#amount")
            ], NegotiationController.prototype, "_amountInput", void 0);
            __decorate([
                inject_1.inject("#value")
            ], NegotiationController.prototype, "_valueInput", void 0);
            __decorate([
                throttle_1.throttle()
            ], NegotiationController.prototype, "add", null);
            __decorate([
                throttle_1.throttle()
            ], NegotiationController.prototype, "import", null);
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
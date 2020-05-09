import { Negotiation } from "../models/Negotiation";
import { Negotiations } from "../models/Negotiations";
import { MessageView } from "../views/MessageView";
import { NegotiationsView } from "../views/NegotiationsView";

export class NegotiationController {
  private _dateInput: JQuery<HTMLElement>;
  private _amountInput: JQuery<HTMLElement>;
  private _valueInput: JQuery<HTMLElement>;
  private _negotiations: Negotiations = new Negotiations();
  private _negotiationsView: NegotiationsView = new NegotiationsView(
    "#negotiations"
  );
  private _messageView: MessageView = new MessageView("#message");

  constructor() {
    this._dateInput = $("#date");
    this._amountInput = $("#amount");
    this._valueInput = $("#value");
    this._negotiationsView.update(this._negotiations);
  }

  add(event: Event): void {
    event.preventDefault();

    const date = this._getDate();
    const amount = this._getAmount();
    const value = this._getValue();

    if (!this._isBusinessDay(date)) {
      this._messageView.update(
        "Negotiations are only allowed in business days!"
      );
      return;
    }

    const negotiation = new Negotiation(date, amount, value);

    this._negotiations.adiciona(negotiation);

    this._negotiationsView.update(this._negotiations);

    this._messageView.update("Negotiation has been added successfully!");
  }

  private _getDate(): Date {
    const value = this._dateInput.val()?.toString();

    if (!value) {
      return new Date();
    }

    return new Date(value.replace(/-/g, ","));
  }

  private _getAmount(): number {
    const value = this._amountInput.val();

    if (!value) {
      return 0;
    }

    return Number(value);
  }

  private _getValue(): number {
    const value = this._valueInput.val();

    if (!value) {
      return 0;
    }

    return Number(value);
  }

  private _isBusinessDay(date: Date): boolean {
    return (
      date.getDay() !== WeekDays.Sunday && date.getDay() !== WeekDays.Saturday
    );
  }
}

enum WeekDays {
  Sunday,
  Monday,
  Tuesday,
  Wednesday,
  Thursday,
  Friday,
  Saturday,
}

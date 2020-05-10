import { inject } from "../helpers/decorators/inject";
import { throttle } from "../helpers/decorators/throttle";
import { print } from "../helpers/utils/print";
import { Negotiation } from "../models/Negotiation";
import { Negotiations } from "../models/Negotiations";
import { NegotiationService } from "../services/NegotiationService";
import { MessageView } from "../views/MessageView";
import { NegotiationsView } from "../views/NegotiationsView";

export class NegotiationController {
  @inject("#date")
  private _dateInput: JQuery<HTMLElement>;

  @inject("#amount")
  private _amountInput: JQuery<HTMLElement>;

  @inject("#value")
  private _valueInput: JQuery<HTMLElement>;

  private _negotiations: Negotiations = new Negotiations();

  private _negotiationsView: NegotiationsView = new NegotiationsView(
    "#negotiations"
  );

  private _messageView: MessageView = new MessageView("#message");

  private _negotiationService: NegotiationService = new NegotiationService();

  constructor() {
    this._negotiationsView.update(this._negotiations);
  }

  @throttle()
  add(): void {
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

    this._negotiations.add(negotiation);

    this._negotiationsView.update(this._negotiations);

    this._messageView.update("Negotiation has been added successfully!");

    print(negotiation, this._negotiations);
  }

  @throttle()
  import() {
    this._negotiationService
      .getNegotiations((res) => {
        if (res.ok) {
          return res;
        }

        throw new Error("It wasn't able to complete");
      })
      .then((negotiations) => {
        const notRepeated = negotiations.filter(
          (negotiation) =>
            !this._negotiations.toArray().some((it) => it.isEqual(negotiation))
        );
        return notRepeated;
      })
      .then((negotiations) => {
        negotiations.forEach((it) => this._negotiations.add(it));
      })
      .then(() => {
        this._negotiationsView.update(this._negotiations);
      })
      .catch((err: Error) => {
        this._messageView.update(err.message);
      });
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

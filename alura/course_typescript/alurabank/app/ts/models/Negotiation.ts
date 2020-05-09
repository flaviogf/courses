class Negotiation {
  constructor(
    private _date: Date,
    private _amount: number,
    private _value: number
  ) {}

  get date(): Date {
    return this._date;
  }

  get amount(): number {
    return this._amount;
  }

  get value(): number {
    return this._value;
  }

  get volume(): number {
    return this._amount * this._value;
  }
}

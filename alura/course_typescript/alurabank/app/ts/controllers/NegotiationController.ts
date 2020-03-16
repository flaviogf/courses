class NegotiationController {
  private _dateInput: HTMLInputElement;
  private _quantityInput: HTMLInputElement;
  private _valueInput: HTMLInputElement;
  private _negotiations = new Negotiations();
  private _view = new NegotiationsView("#negotiations");

  constructor() {
    this._dateInput = <HTMLInputElement>document.querySelector("#date");
    this._quantityInput = <HTMLInputElement>document.querySelector("#quantity");
    this._valueInput = <HTMLInputElement>document.querySelector("#value");
    this._view.update(this._negotiations);
  }

  add(event: Event) {
    event.preventDefault();

    const negotiation = new Negotiation(
      new Date(this._dateInput.value.replace(/-/, ",")),
      parseInt(this._quantityInput.value),
      parseFloat(this._valueInput.value)
    );

    this._negotiations.add(negotiation);

    this._view.update(this._negotiations);
  }
}

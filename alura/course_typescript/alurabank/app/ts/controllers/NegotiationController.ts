class NegotiationController {
  private _dateInput: HTMLInputElement;
  private _amountInput: HTMLInputElement;
  private _valueInput: HTMLInputElement;
  private _negotiations: Negotiations = new Negotiations();
  private _negotiationsView: NegotiationsView = new NegotiationsView(
    "#negotiations"
  );

  constructor() {
    this._dateInput = document.querySelector("#date");
    this._amountInput = document.querySelector("#amount");
    this._valueInput = document.querySelector("#value");
    this._negotiationsView.update(this._negotiations);
  }

  add(event: Event) {
    event.preventDefault();

    const negotiation = new Negotiation(
      new Date(this._dateInput.value.replace(/-/g, ",")),
      parseFloat(this._amountInput.value),
      parseFloat(this._valueInput.value)
    );

    this._negotiations.adiciona(negotiation);

    this._negotiationsView.update(this._negotiations);
  }
}

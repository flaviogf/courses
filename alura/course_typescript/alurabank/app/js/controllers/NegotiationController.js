class NegotiationController {
    constructor() {
        this._negotiations = new Negotiations();
        this._negotiationsView = new NegotiationsView("#negotiations");
        this._dateInput = document.querySelector("#date");
        this._amountInput = document.querySelector("#amount");
        this._valueInput = document.querySelector("#value");
        this._negotiationsView.update(this._negotiations);
    }
    add(event) {
        event.preventDefault();
        const negotiation = new Negotiation(new Date(this._dateInput.value.replace(/-/g, ",")), parseFloat(this._amountInput.value), parseFloat(this._valueInput.value));
        this._negotiations.adiciona(negotiation);
        this._negotiationsView.update(this._negotiations);
    }
}

class NegotiationController {
    constructor() {
        this._negotiations = new Negotiations();
        this._view = new NegotiationsView("#negotiations");
        this._dateInput = document.querySelector("#date");
        this._quantityInput = document.querySelector("#quantity");
        this._valueInput = document.querySelector("#value");
        this._view.update(this._negotiations);
    }
    add(event) {
        event.preventDefault();
        const negotiation = new Negotiation(new Date(this._dateInput.value.replace(/-/, ",")), parseInt(this._quantityInput.value), parseFloat(this._valueInput.value));
        this._negotiations.add(negotiation);
        this._view.update(this._negotiations);
    }
}

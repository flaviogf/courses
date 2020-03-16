class Negotiations {
    constructor() {
        this._negotiations = [];
    }
    add(negotiation) {
        this._negotiations.push(negotiation);
    }
    toArray() {
        return [].concat(this._negotiations);
    }
}

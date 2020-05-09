class Negotiations {
    constructor() {
        this._negotiations = [];
    }
    adiciona(negotiation) {
        this._negotiations.push(negotiation);
    }
    toArray() {
        return [].concat(this._negotiations);
    }
}

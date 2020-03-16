class Negotiations {
  private _negotiations: Negotiation[];

  constructor() {
    this._negotiations = [];
  }

  add(negotiation: Negotiation): void {
    this._negotiations.push(negotiation);
  }

  toArray(): Negotiation[] {
    return [].concat(this._negotiations);
  }
}

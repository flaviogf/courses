class Negotiations {
  private _negotiations: Negotiation[] = [];

  adiciona(negotiation: Negotiation): void {
    this._negotiations.push(negotiation);
  }

  toArray(): Negotiation[] {
    return [].concat(this._negotiations);
  }
}

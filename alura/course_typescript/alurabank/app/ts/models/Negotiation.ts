export class Negotiation {
  constructor(
    readonly date: Date,
    readonly amount: number,
    readonly value: number
  ) {}

  get volume(): number {
    return this.amount * this.value;
  }
}

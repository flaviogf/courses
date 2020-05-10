import { Equatable } from "./Equatable";
import { Printable } from "./Printable";

export class Negotiation implements Printable, Equatable<Negotiation> {
  constructor(
    readonly date: Date,
    readonly amount: number,
    readonly value: number
  ) {}

  get volume(): number {
    return this.amount * this.value;
  }

  print(): void {
    console.log(JSON.stringify(this));
  }

  isEqual(other: Negotiation): boolean {
    return (
      this.date.getDate() === other.date.getDate() &&
      this.date.getMonth() === other.date.getMonth() &&
      this.date.getFullYear() === other.date.getFullYear()
    );
  }
}

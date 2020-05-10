import { Negotiation } from "./Negotiation";
import { Printable } from "./Printable";

export class Negotiations implements Printable {
  private _negotiations: Negotiation[] = [];

  add(negotiation: Negotiation): void {
    this._negotiations.push(negotiation);
  }

  toArray(): Negotiation[] {
    return ([] as Negotiation[]).concat(this._negotiations);
  }

  print(): void {
    console.log(JSON.stringify(this));
  }
}

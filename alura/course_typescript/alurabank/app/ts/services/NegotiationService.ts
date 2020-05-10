import { Negotiation } from "../models/Negotiation";
import { PartialNegotiation } from "../models/PartialNegotiation";

export class NegotiationService {
  getNegotiations(handler: HandleFunction): Promise<Negotiation[]> {
    return fetch("http://localhost:8080/dados")
      .then(handler)
      .then((res) => res.json())
      .then((data: PartialNegotiation[]) =>
        data.map((it) => new Negotiation(new Date(), it.montante, it.vezes))
      );
  }
}

export interface HandleFunction {
  (res: Response): Response;
}

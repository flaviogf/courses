import { View } from "./View";
import { Negotiations } from "../models/Negotiations";

export class NegotiationsView extends View<Negotiations> {
  template(model: Negotiations): string {
    const dateFormatter = new Intl.DateTimeFormat("en-US", {
      year: "numeric",
      month: "long",
      day: "numeric",
    });

    const numberFormatter = new Intl.NumberFormat("en-US", {
      style: "currency",
      currency: "USD",
    });

    return model
      .toArray()
      .map((it) => {
        const date = dateFormatter.format(it.date);
        const volume = numberFormatter.format(it.volume);
        return `
        <li class="list-group-item d-flex justify-content-between align-items-center">
            ${date}
            <span class="badge badge-primary badge-pill">${volume}</span>
        </li>`;
      })
      .join("");
  }
}

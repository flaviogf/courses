class NegotiationsView {
  private _element: HTMLElement;

  constructor(selector: string) {
    this._element = document.querySelector(selector);
  }

  update(negotiations: Negotiations): void {
    this._element.innerHTML = this.template(negotiations);
  }

  template(negotiations: Negotiations): string {
    const dateFormatter = new Intl.DateTimeFormat("en-US", {
      year: "numeric",
      month: "long",
      day: "numeric",
    });

    const numberFormatter = new Intl.NumberFormat("en-US", {
      style: "currency",
      currency: "USD",
    });

    return negotiations
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

class NegotiationsView {
  private _element: Element;

  constructor(selector: string) {
    this._element = document.querySelector(selector);
  }

  update(model: Negotiations): void {
    this._element.innerHTML = this.template(model);
  }

  template(model: Negotiations): string {
    return `
        <table class="table table-hover table-bordered">
            <thead>
                <tr>
                <th>DATA</th>
                <th>QUANTIDADE</th>
                <th>VALOR</th>
                <th>VOLUME</th>
                </tr>
            </thead>

            <tbody>
            ${model
              .toArray()
              .map(
                it =>
                  `
                    <tr>
                        <td>${it.date.getFullYear()}-${it.date.getMonth() + 1}-${it.date.getDate()}</td>
                        <td>${it.quantity}</td>
                        <td>${it.value}</td>
                        <td>${it.volume}</td>
                    </tr>
                `
              )
              .join("")}
            </tbody>

            <tfoot></tfoot>
        </table>
    `;
  }
}

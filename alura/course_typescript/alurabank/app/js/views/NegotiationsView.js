class NegotiationsView {
    constructor(selector) {
        this._element = document.querySelector(selector);
    }
    update(model) {
        this._element.innerHTML = this.template(model);
    }
    template(model) {
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
            .map(it => `
                    <tr>
                        <td>${it.date.getFullYear()}-${it.date.getMonth() + 1}-${it.date.getDate()}</td>
                        <td>${it.quantity}</td>
                        <td>${it.value}</td>
                        <td>${it.volume}</td>
                    </tr>
                `)
            .join("")}
            </tbody>

            <tfoot></tfoot>
        </table>
    `;
    }
}

export abstract class View<T> {
  private _element: JQuery<HTMLElement>;
  private _escape: boolean;

  constructor(selector: string, escape: boolean = true) {
    this._element = $(selector);
    this._escape = escape;
  }

  update(model: T): void {
    if (!this._escape) {
      this._element.html(this.template(model));
      return;
    }

    this._element.html(
      this.template(model).replace(/<script>[\s\S]*?<\/script>/, "")
    );
  }

  abstract template(model: T): string;
}

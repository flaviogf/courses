import { View } from "./View";

export class MessageView extends View<string> {
  template(model: string): string {
    return `
      <div class="alert alert-info">
        ${model}
        <button class="close" data-dismiss="alert" type="button">
          <span>&times;</span>
        </button>
      </div>
    `;
  }
}

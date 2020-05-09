System.register(["./View"], function (exports_1, context_1) {
    "use strict";
    var View_1, MessageView;
    var __moduleName = context_1 && context_1.id;
    return {
        setters: [
            function (View_1_1) {
                View_1 = View_1_1;
            }
        ],
        execute: function () {
            MessageView = class MessageView extends View_1.View {
                template(model) {
                    return `
      <div class="alert alert-info">
        ${model}
        <button class="close" data-dismiss="alert" type="button">
          <span>&times;</span>
        </button>
      </div>
    `;
                }
            };
            exports_1("MessageView", MessageView);
        }
    };
});
//# sourceMappingURL=MessageView.js.map
export function inject(selector: string) {
  return function (target: any, key: string) {
    let element: JQuery<HTMLElement>;

    const get = function () {
      if (!element) {
        console.log(`Finding ${selector} in DOM for property ${key}`);
        element = $(selector);
      }

      return element;
    };

    Object.defineProperty(target, key, {
      get,
    });
  };
}

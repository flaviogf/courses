export function throttle(milliseconds: number = 500) {
  return function (
    target: any,
    propertyKey: string,
    descriptor: PropertyDescriptor
  ) {
    const method = descriptor.value;

    let timer: NodeJS.Timeout;

    descriptor.value = function (...args: any[]) {
      if (event) event.preventDefault();

      clearTimeout(timer);

      timer = setTimeout(() => method.apply(this, args), milliseconds);
    };

    return descriptor;
  };
}

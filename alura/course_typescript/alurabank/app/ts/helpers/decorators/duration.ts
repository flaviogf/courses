export function duration() {
  return function (
    target: any,
    propertKey: string,
    descriptor: PropertyDescriptor
  ) {
    const method = descriptor.value;

    descriptor.value = function (...args: any[]) {
      const t1 = performance.now();
      const result = method.apply(this, args);
      const t2 = performance.now();
      console.log(`Has been passed ${t2 - t1} ms`);
      return result;
    };

    return descriptor;
  };
}

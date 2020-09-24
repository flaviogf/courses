export function decorator(clazz, handler) {
  Object.keys(handler).forEach((property) => {
    const method = clazz.prototype[property];
    const decorator = handler[property];
    clazz.prototype[property] = function (...args) {
      return decorator(method.bind(this), property, args);
    };
  });
}

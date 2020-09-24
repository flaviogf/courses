export function memoizer(fn) {
  const cache = new Map();

  const newFn = (...args) => {
    const key = JSON.stringify(args);

    if (cache.has(key)) {
      console.log("Returning cached result");

      return cache.get(key);
    }

    console.log("Calculating and caching a new result");

    const result = fn(...args);

    cache.set(key, result);

    return result;
  };

  newFn.release = () => {
    console.log('Cleaning the cache')

    cache.clear();
  };

  return newFn;
}

export function logExecutionTime(method, property, args) {
  console.time(property);
  const result = method(...args);
  console.timeEnd(property);
  return result;
}

export function inspectMethod(excludeReturn = false) {
  return (method, property, args) => {
    console.log(`Invoking the method ${property}`);
    console.log(`Args: ${JSON.stringify(args)}`)
    const result = method(...args);
    if(!excludeReturn) {
      console.log(`Result ${result}`)
    }
    console.log(`The method ${property} was executed`)
    return result;
  }
}

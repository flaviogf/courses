export function logExecutionTime(method, property, args) {
  console.log(`Executing method ${property}`);
  console.log(`Executing method with args: ${JSON.stringify(args)}`);
  console.time(property);
  const result = method(...args);
  console.timeEnd(property);
  console.log("Execution has finished");
  return result;
}

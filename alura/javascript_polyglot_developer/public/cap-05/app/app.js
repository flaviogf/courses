import { Person } from "./models/person.js";
import { logExecutionTime } from "./decorators/decorators.js";
import { decorator } from "./infra/decorator.js";

const method = Person.prototype.getFullName;

Person.prototype.getFullName = function (...args) {
  console.time("getFullName");
  const result = method.call(this, ...args);
  console.timeEnd("getFullName");
  return result;
};

const person = new Person("Flávio", "Fernandes");
person.getFullName();
person.speak('Hi');

decorator(Person, {
  getFullName: logExecutionTime,
  speak: logExecutionTime,
});

person.getFullName();
person.speak('Hi, how are you doing?');

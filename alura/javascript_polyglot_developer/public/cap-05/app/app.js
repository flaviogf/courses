import { Person } from "./models/person.js";
import { logExecutionTime, inspectMethod } from "./decorators/decorators.js";
import { decorator } from "./infra/decorator.js";

const method = Person.prototype.getFullName;

const person = new Person("Flávio", "Fernandes");
person.getFullName();
person.speak('Hi');

decorator(Person, {
  getFullName: [logExecutionTime, inspectMethod(true)],
  speak: [logExecutionTime, inspectMethod()],
});

person.getFullName();
person.speak('Hi, how are you doing?');

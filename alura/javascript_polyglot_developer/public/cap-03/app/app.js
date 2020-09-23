import { ActiveRecord } from "./infra/active-record.js";
import { Animal } from "./models/animal.js";
import { Person } from "./models/person.js";

(async function () {
  await new ActiveRecord({
    name: "db",
    version: 1,
    mappers: [
      {
        clazz: Animal,
        converter: (data) => new Animal(data.name),
      },
      {
        clazz: Person,
        converter: (data) => new Person(data.name, data.surname),
      },
    ],
  }).init();

  const person = new Person("Flávio", "Fernandes");
  await person.save();

  const animal = new Animal("Calopsita");
  await animal.save();

  const people = await Person.find();
  console.log(people);

  const animals = await Animal.find();
  console.log(animals);
})();

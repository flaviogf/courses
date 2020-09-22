import { SessionFactory } from "./infra/session-factory.js";
import { Animal } from "./models/animal.js";
import { Person } from "./models/person.js";

(async function () {
  const session = await new SessionFactory({
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
  }).openSession();

  const person = new Person("Flávio", "Fernandes");
  await session.save(person);
  console.log(person);

  const animal = new Animal("Calopsita");
  await session.save(animal);
  console.log(animal);
})();

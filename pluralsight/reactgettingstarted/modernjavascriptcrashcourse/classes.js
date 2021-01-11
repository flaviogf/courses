class Person {
  constructor(name) {
    this.name = name;
  }

  greet() {
    console.log(`Hi ${this.name}`);
  }
}

class Student extends Person {
  constructor(name, level) {
    super(name);
    this.level = level;
  }

  greet() {
    console.log(`Hi ${this.name} from ${this.level}`);
  }
}

const o1 = new Person("Max");
const o2 = new Student("Tine", "1st Grade");
const o3 = new Student("Mary", "2st Grade");
o3.greet = () => console.log("Hi I'm special");

o1.greet();
o2.greet();
o3.greet();

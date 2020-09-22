export class Person {
  constructor(name, surname) {
    Object.assign(this, { name, surname });
  }

  get fullname() {
    return `${this.name} ${this.surname}`;
  }
}

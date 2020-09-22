let connection = null;

const request = window.indexedDB.open("db", 5);

request.onupgradeneeded = function () {
  if (this.result.objectStoreNames.contains(Person.name)) {
    this.result.deleteObjectStore(Person.name);
  }

  this.result.createObjectStore(Person.name, { autoIncrement: true });

  console.log("IndexDB has been upgraded");
};

request.onsuccess = function () {
  console.log("Connection has been opened");
  connection = this.result;
  adiciona();
};

request.onerror = function () {
  console.error("Something goes wrong");
  console.error(e);
};

class Person {
  constructor(name) {
    Object.assign(this, { name });
  }
}

function adiciona() {
  const transaction = connection.transaction([Person.name], "readwrite");
  const store = transaction.objectStore(Person.name);
  const person = new Person("Flávio");
  const request = store.add(person);
  request.onsuccess = function () {
    console.log("Registered");
  };
  request.onerror = function (e) {
    console.error("Something goes wrong");
    console.error(e);
  };
}

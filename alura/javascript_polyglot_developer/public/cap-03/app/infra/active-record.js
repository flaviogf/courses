let connection;

let stores = {};

export class ActiveRecord {
  constructor({ name, version, mappers }) {
    this.name = name;
    this.version = version;
    stores = mappers.reduce((aggregator, it) => {
      it.clazz.prototype.save = save;
      it.clazz.find = find;

      return { ...aggregator, [it.clazz.name]: it.converter };
    }, {});
  }

  async init() {
    connection = await createConnection(this.name, this.version);
  }
}

function createConnection(name, version) {
  return new Promise((resolve, reject) => {
    const request = window.indexedDB.open(name, version);

    request.onupgradeneeded = function () {
      const connection = this.result;

      for (const [key, value] of Object.entries(stores)) {
        if (connection.objectStoreNames.contains(key)) {
          connection.deleteObjectStore(key);
        }

        connection.createObjectStore(key, { autoIncrement: true });
      }
    };

    request.onsuccess = function () {
      resolve(this.result);
    };

    request.onerror = function (err) {
      console.error(err);

      reject("Something goes wrong");
    };
  });
}

function save() {
  return new Promise((resolve, reject) => {
    const object = this;

    const request = connection
      .transaction([object.constructor.name], "readwrite")
      .objectStore(object.constructor.name)
      .add(object);

    request.onsuccess = function () {
      resolve();
    };

    request.onerror = function (err) {
      console.error(err);

      reject("Something goes wrong");
    };
  });
}

function find() {
  return new Promise((resolve, reject) => {
    const storeName = this.name;

    const store = connection
      .transaction([storeName], "readwrite")
      .objectStore(storeName);

    const cursor = store.openCursor();

    const converter = stores[storeName];

    const list = [];

    cursor.onsuccess = function () {
      const current = this.result;

      if (current) {
        list.push(converter(current.value));
        current.continue();
        return;
      }

      resolve(list);
    };
  });
}

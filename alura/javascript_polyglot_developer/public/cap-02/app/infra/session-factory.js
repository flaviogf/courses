export class SessionFactory {
  constructor({ name, version, mappers }) {
    Object.assign(this, { name, version });

    this.stores = mappers.reduce(
      (aggregator, it) => ({ ...aggregator, [it.clazz.name]: it.converter }),
      {}
    );
  }

  async openSession() {
    const connection = await createConnection(
      this.name,
      this.version,
      this.stores
    );

    return new Session(connection, this.stores);
  }
}

class Session {
  constructor(connection, stores) {
    Object.assign(this, { connection, stores });
  }

  save(object) {
    return new Promise((resolve, reject) => {
      const storeName = object.constructor.name;

      const transaction = this.connection.transaction(
        [storeName],
        "readwrite"
      );

      const request = transaction.objectStore(storeName).add(object);

      request.onsuccess = function () {
        resolve();
      };

      request.onerror = function (e) {
        console.error(e);
        reject("Something goes wrong");
      };
    });
  }
}

function createConnection(name, version, stores) {
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

    request.onerror = function (e) {
      console.error("Something goes wrong");
      console.error(e);
      reject(e);
    };
  });
}

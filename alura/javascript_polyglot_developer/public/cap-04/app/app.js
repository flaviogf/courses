import { memoizer } from "./infra/memoizer.js";

function sum(x, y) {
  return x + y;
}

const memoizedSum = memoizer(sum);

const factorial = memoizer((n) => {
  if (n <= 1) return 1;
  return n * factorial(--n);
});

function fetchNoteById(id) {
  return fetch(`http://localhost:3000/notas/${id}`).then(responseHandler);
}

function responseHandler(res) {
  return res.ok ? res.json() : Promise.reject();
}

const memoizedFetchNoteById = memoizer(fetchNoteById);

console.log(memoizedSum(10, 10));
console.log(memoizedSum(10, 20));
console.log(memoizedSum(10, 10));
console.log(factorial(5));
console.log(factorial(3));

memoizedFetchNoteById(0)
  .then(console.log)
  .then(() => memoizedFetchNoteById(0))
  .then(console.log)
  .then(() => memoizedFetchNoteById.release())
  .then(() => memoizedFetchNoteById(0))
  .then(console.log);

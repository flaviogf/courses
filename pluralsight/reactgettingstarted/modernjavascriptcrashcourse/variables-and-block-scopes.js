{
  {
    {
      {
        var v = 1;
      }
    }
  }
}

console.log(v);

{
  // block scope
}

if (true) {
  // block scope
}

for (var i = 0; i < 10; i++) {
  // block scope
}

console.log(i);

function sum(x, y) {
  // function scope
  var result = x + y;
}

// console.log(result); ReferenceError: result is not defined

for (let l = 0; l < 10; l++) {
  // block scope
}

// console.log(l); ReferenceError: l is not defined

const answer = 42;
const greeting = "Hello";

const numbers = [2, 4, 6];
const person = {
  firstName: "John",
  lastName: "Doe",
};

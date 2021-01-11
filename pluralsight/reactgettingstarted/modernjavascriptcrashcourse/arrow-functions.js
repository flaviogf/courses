const X = function () {
  console.log(this);
};

const Y = () => {
  console.log(this);
};

const testerObj = {
  func1: function () {
    console.log("func1", this);
  },
  func2: () => {
    console.log("func2", this);
  },
};

testerObj.func1();

testerObj.func2();

const square1 = (a) => {
  return a * a;
};

const square2 = (a) => a * a;

const square3 = (a) => a * a;

[1, 2, 3, 4].map((a) => a * a);

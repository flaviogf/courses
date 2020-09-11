import Account from "./account.js";
import { bmi } from "./who.js";

console.log(bmi({ weight: 62, height: 1.7 }));
console.log(bmi({ height: 1.7, weight: 62 }));
console.log(
  new Account({ owner: "Frank", bank: "Nu", agency: "000", number: "00000" })
);

import { Printable } from "../../models/Printable";

export function print(...args: Printable[]) {
  args.forEach((it) => it.print());
}

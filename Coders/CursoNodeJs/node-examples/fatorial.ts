export const fatorial = (num: number): number => {
  if (num === 1) {
    return num;
  }

  return num * fatorial(num - 1);
};

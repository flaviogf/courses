export const handleStatus = res =>
    res.ok ? res.json() : Promise.reject('Error')


export const log = (item) => {
  console.log(item)
  return item
}

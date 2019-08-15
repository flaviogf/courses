export const handleStatus = res =>
    res.ok ? res.json() : Promise.reject('Error')


export const log = (item) => {
  console.log(item)
  return item
}

export const promiseTimeout = (ms, promise) => {
  const timeout = new Promise((resolve, reject) => setTimeout(() => reject('Timeout'), ms))
  return Promise.race([timeout, promise])
}

export const delay = (ms) => (data) =>
  new Promise((resolve, reject) => setTimeout(() => resolve(data), ms))


export const retry = (retries, ms, promise) =>
  promise.catch(err => {
    console.log(retries)

    return delay(ms)().then(() => {
      return retries > 1
        ? retry(--retries, ms, promise)
        : Promise.reject(err)
    })
  })

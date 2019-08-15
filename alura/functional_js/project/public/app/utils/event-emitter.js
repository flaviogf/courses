const events = new Map()


export const EventEmitter = {
  on(event, fn) {
    if (!events.has(event)) events.set(event, [])
    events.get(event).push(fn)
  },
  emit(event, value) {
    const subscribers = events.get(event)
    if (!subscribers) return
    subscribers.forEach(subscriber => subscriber(value))
  }
}

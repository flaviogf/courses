import { log, promiseTimeout, delay, retry } from './utils/promise-helpers.js'
import { noteService as service } from './notes/service.js'
import { debounce, takeUnitl, pipe, partialize } from './utils/operators.js'
import { EventEmitter } from './utils/event-emitter.js'

/*
const showMessage = () => console.log('hello')
const operation1 = takeUnitl(2, showMessage)
operation1()
operation1()
operation1()
operation1()
operation1()
*/

/*
const showMessage = () => console.log('hello')
const operation2 = debounce(500, showMessage)
operation2()
operation2()
operation2()
operation2()
operation2()
*/

const operation = pipe(
  partialize(takeUnitl, 3),
  partialize(debounce, 500)
)

const action = operation(() =>
  retry(3, 5000, promiseTimeout(5000, service.sumItems('2143')))
    .then(sum => EventEmitter.emit('sumItems', sum))
    .catch(log))


document
    .querySelector("#myButton")
    .onclick = action

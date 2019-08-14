import { log } from './utils/promise-helpers.js'
import { noteService as service } from './notes/service.js'
import { debounce, takeUnitl, pipe, partialize } from './utils/operators.js'

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
  service
    .sumItems('2143')
    .then(log)
    .catch(log))


document
    .querySelector("#myButton")
    .onclick = action

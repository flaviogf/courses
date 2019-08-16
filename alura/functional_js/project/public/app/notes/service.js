import { handleStatus } from '../utils/promise-helpers.js'
import '../utils/array-helpers.js'
import { partialize, compose, pipe } from '../utils/operators.js'
import { Maybe } from '../utils/maybe.js'


const getNotesItems = notesM => notesM.map(notes => notes.$flatMap(note => note.itens))
const filterItensByCode = (code, itemsM) => itemsM.map(items => items.filter(item => item.codigo == code))
const sumItemsValue = itemsM => itemsM.map(items => items.reduce((total, item) => total + item.valor, 0))


export const noteService = {
  all() {
    return fetch('http://localhost:3000/notas')
        .then(handleStatus)
        .then(notes => Maybe.of(notes))
  },
  sumItems(code) {
    const filterItems = partialize(filterItensByCode, code)

    // const sumItems = compose(sumItemsValue, filterItems, getNotesItems)

    const sumItems = pipe(getNotesItems, filterItems, sumItemsValue)

    return this.all().then(sumItems).then(value => value.getOrElse(0))
  }
}

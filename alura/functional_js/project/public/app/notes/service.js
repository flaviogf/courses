import { handleStatus } from '../utils/promise-helpers.js'
import '../utils/array-helpers.js'
import { partialize, compose, pipe } from '../utils/operators.js'


const getNotesItems = notes => notes.$flatMap(note => note.itens)
const filterItensByCode = (code, items) => items.filter(item => item.codigo == code)
const sumItemsValue = items => items.reduce((total, item) => total + item.valor, 0)


export const noteService = {
  all() {
    return fetch('http://localhost:3000/notas').then(handleStatus)
  },
  sumItems(code) {
    const filterItems = partialize(filterItensByCode, code)

    // const sumItems = compose(sumItemsValue, filterItems, getNotesItems)

    const sumItems = pipe(getNotesItems, filterItems, sumItemsValue)

    return this.all().then(sumItems)
  }
}

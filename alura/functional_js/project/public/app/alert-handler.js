import { EventEmitter } from './utils/event-emitter.js'

EventEmitter.on('sumItems', sum => alert(sum))

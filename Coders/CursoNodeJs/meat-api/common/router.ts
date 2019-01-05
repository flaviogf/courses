import { EventEmitter } from 'events';
import * as restify from 'restify';

export abstract class Router extends EventEmitter {
  public abstract applyRoute(application: restify.Server): void;

  public render(res: restify.Response, next: restify.Next) {
    return (document) => {
      if (document) {
        this.emit('beforeRender', document);
        res.json(document);
      } else {
        res.send(404);
      }
      return next();
    };
  }
}

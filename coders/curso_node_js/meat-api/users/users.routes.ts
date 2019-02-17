import * as restify from 'restify';
import { Router } from '../common/router';
import { User } from './users.model';

class UsersRoutes extends Router {
  constructor() {
    super();
    this.on('beforeRender', (it) => {
      it.password = undefined;
    });
  }
  public applyRoute(application: restify.Server) {
    application.get('/users', (req, res, next) => {
      User
      .find()
      .select('name email')
      .then(this.render(res, next))
      .catch(next);
    });
    application.get('/users/:id', (req, res, next) => {
      User
      .findById(req.params.id)
      .select('name email')
      .then(this.render(res, next))
      .catch(next);
    });
    application.post('/users', (req, res, next) => {
      new User(req.body)
      .save()
      .then(this.render(res, next))
      .catch(next);
    });
    application.put('/users/:id', (req, res, next) => {
      User
      .update({ _id: req.params.id }, req.body, { overwrite: true })
      .exec()
      .then(() => {
        res.send(204);
        return next();
      })
      .catch(next);
    });
    application.patch('/users/:id', (req, res, next) => {
      User
      .findByIdAndUpdate(req.params.id, req.body, { new: true })
      .select('name email')
      .then(this.render(res, next))
      .catch(next);
    });
    application.del('/users/:id', (req, res, next) => {
      User
      .remove({ _id: req.params.id })
      .exec()
      .then(() => {
          res.send(204);
          return next();
      })
      .catch(next);
    });
  }
}

export const userRoutes = new UsersRoutes();

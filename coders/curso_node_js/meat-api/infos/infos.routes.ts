import * as restify from 'restify';
import { Router } from '../common/router';

class InfosRoutes extends Router {
  public applyRoute(application: restify.Server): void {
    application.get('/infos', (req, res, next) => {
      res.json({
        browser: req.userAgent(),
        path: req.path(),
        query: req.query,
        url: req.href(),
      });
      return next();
    });
  }
}

export const infosRoutes = new InfosRoutes();

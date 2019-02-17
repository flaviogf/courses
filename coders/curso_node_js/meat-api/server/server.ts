import * as mongoose from 'mongoose';
import * as restify from 'restify';
import { enviroment } from '../common/enviroment';
import { Router } from '../common/router';
import { errorHandler } from './error.handler';

export class Server {
  private application: restify.Server;

  public bootstrap(...routes: Router[]): Promise<restify.Server> {
    return this
      .initDb()
      .then(() => this.initRoutes(routes))
      .then((server) => server);
  }

  private initDb(): Promise<any> {
    const options = { useNewUrlParser: true, useCreateIndex: true };
    return mongoose.connect(enviroment.db.url, options);
  }

  private initRoutes(routes: Router[]): Promise<restify.Server> {
    return new Promise((resolve, reject) => {
      try {
        this.application = restify.createServer({
          name: 'meat-api',
          version: '0.0.1',
        });
        this.application.use(restify.plugins.queryParser());
        this.application.use(restify.plugins.bodyParser());
        for (const it of routes) {
          it.applyRoute(this.application);
        }
        this.application.listen(enviroment.server.port, () => resolve(this.application));
        this.application.on('restifyError', errorHandler());
      } catch (error) {
        reject(error);
      }
    });
  }
}

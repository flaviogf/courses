import * as restify from 'restify';

export const errorHandler = () => (req: restify.Request, res: restify.Response, err, done) => {
    err.toJSON = () => {
      return {
        message: err.message,
      };
    };
    err.toString = () => {
      return err.message;
    };
    switch (err.name) {
      case 'MongoError':
      case 'CastError':
        err.statusCode = 400;
        break;
    }
    done();
};

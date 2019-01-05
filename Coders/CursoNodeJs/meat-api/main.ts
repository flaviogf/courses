import { infosRoutes } from './infos/infos.routes';
import { Server } from './server/server';
import { userRoutes } from './users/users.routes';

const server = new Server();

server
  .bootstrap(infosRoutes, userRoutes)
  .then((app) => {
    console.log('Server is running in:', app.address());
  })
  .catch((error) => {
    console.log('Server failed starter');
    console.error(error);
    process.exit(-1);
  });

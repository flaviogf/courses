export const enviroment = {
  db: {
    url: process.env.DB_URL || 'mongodb://flavio:flavio123@ds031088.mlab.com:31088/meat-api',
  },
  server: {
    port: process.env.PORT || 3000,
  },
};

FROM node:15

WORKDIR /usr/src/app

COPY package-lock.json package-lock.json
COPY package.json package.json

RUN npm install

COPY index.js index.js

EXPOSE 3000

CMD [ "node", "index.js" ]

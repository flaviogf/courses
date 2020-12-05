const knex = require("../database");

module.exports.get = async (event) => {
  const { id } = event.pathParameters;

  const author = await knex("authors").where("id", id).first("*");

  return {
    statusCode: 200,
    body: JSON.stringify(author),
  };
};

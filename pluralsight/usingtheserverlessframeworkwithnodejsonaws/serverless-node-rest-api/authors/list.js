const knex = require("../database");

module.exports.list = async (event) => {
  const authors = await knex("authors").select("*");

  return {
    statusCode: 200,
    body: JSON.stringify(authors),
  };
};

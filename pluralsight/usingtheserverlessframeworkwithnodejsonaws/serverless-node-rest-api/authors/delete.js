const knex = require('../database')

module.exports.delete = async (event) => {
  const { id } = event.pathParameters;

  await knex('authors').where('id',id).delete()

  return {
    statusCode: 200,
  };
};

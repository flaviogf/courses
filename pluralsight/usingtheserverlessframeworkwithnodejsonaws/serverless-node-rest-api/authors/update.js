const knex = require("../database");

module.exports.update = async (event) => {
  const { id } = event.pathParameters;

  const body = JSON.parse(event.body);

  const { firstName, lastName, dateOfBirth, mainCategory } = body;

  const author = {
    first_name: firstName,
    last_name: lastName,
    date_of_birth: dateOfBirth,
    main_category: mainCategory,
  };

  await knex("authors").update(author).where("id", id);

  return {
    statusCode: 200,
    body: JSON.stringify(author),
  };
};

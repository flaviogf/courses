const uuid = require("uuid");
const knex = require("../database");

module.exports.create = async (event) => {
  const body = JSON.parse(event.body);

  const { firstName, lastName, dateOfBirth, mainCategory } = body;

  const author = {
    id: uuid.v4(),
    first_name: firstName,
    last_name: lastName,
    date_of_birth: dateOfBirth,
    main_category: mainCategory,
  };

  await knex("authors").insert(author);

  return {
    statusCode: 201,
    body: JSON.stringify(author),
  };
};

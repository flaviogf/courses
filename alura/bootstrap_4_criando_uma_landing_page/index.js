import $ from "jquery";

$(document).ready(() => {
  const recipes = [
    {
      img: "https://picsum.photos/id/25/150/100",
      title: "Tigela de abacate",
      description:
        "Receita refrescante e cheia de vitamina para o seu café da manhã!"
    },
    {
      img: "https://picsum.photos/id/35/150/100",
      title: "Salada de kiwi",
      description:
        "Receita refrescante e cheia de vitamina para o seu café da manhã!"
    },
    {
      img: "https://picsum.photos/id/45/150/100",
      title: "Beterraba assada",
      description:
        "Receita refrescante e cheia de vitamina para o seu café da manhã!"
    },
    {
      img: "https://picsum.photos/id/25/150/100",
      title: "Tigela de abacate",
      description:
        "Receita refrescante e cheia de vitamina para o seu café da manhã!"
    },
    {
      img: "https://picsum.photos/id/35/150/100",
      title: "Salada de kiwi",
      description:
        "Receita refrescante e cheia de vitamina para o seu café da manhã!"
    },
    {
      img: "https://picsum.photos/id/45/150/100",
      title: "Beterraba assada",
      description:
        "Receita refrescante e cheia de vitamina para o seu café da manhã!"
    },
  ];

  const sectionRecipes = $("#recipes");

  for (const recipe of recipes) {
    const card = $("<div>");
    card.addClass("card");
    card.addClass("recipe");

    const img = $("<img>");
    img.addClass("card-img-top");
    img.attr("src", recipe.img);

    const body = $("<div>");
    body.addClass("card-body");

    const title = $("<h5>");
    title.addClass("card-title");
    title.text(recipe.title);

    const description = $("<p>");
    description.addClass("card-text");
    description.text(recipe.description);

    const button = $("<button>");
    button.addClass("btn btn-special");
    button.text("Veja a receita");

    card.append(img);
    body.append(title);
    body.append(description);
    body.append(button);

    card.append(body);

    sectionRecipes.append(card);
  }
});

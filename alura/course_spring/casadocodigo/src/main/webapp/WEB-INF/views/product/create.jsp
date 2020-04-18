<!DOCTYPE html>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>
<html lang="en">
  <head>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Casa do Codigo</title>
  </head>
  <body>
    <form action="/casadocodigo/product/store" method="POST">
      <div>
        <label for="name">Name</label>
        <input id="name" name="name" type="text" />
      </div>
      <div>
        <label for="summary">Summary</label>
        <textarea id="summary" name="summary"></textarea>
      </div>
      <div>
        <label for="pages">Pages</label>
        <input id="pages" name="pages" type="number" />
      </div>
      <c:forEach items="${priceTypes}" var="priceType" varStatus="status">
        <div>
          <label>${priceType}</label>
          <input name="prices[${status.index}].value" />
          <input
            hidden
            name="prices[${status.index}].type"
            value="${priceType}"
          />
        </div>
      </c:forEach>
      <div>
        <button type="submit">Submit</button>
      </div>
    </form>
  </body>
</html>

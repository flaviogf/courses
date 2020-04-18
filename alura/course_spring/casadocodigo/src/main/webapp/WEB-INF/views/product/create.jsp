<%@ page language="java" contentType="text/html; charset=UTF-8" pageEncoding="UTF-8"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>
<%@taglib uri="http://www.springframework.org/tags" prefix="s"%>
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form" %>
<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Casa do Código</title>
  </head>
  <body>
    <form:form action="${s:mvcUrl('PC#store').build()}" method="POST" commandName="product">
      <div>
        <label for="name">Name</label>
        <input id="name" name="name" type="text" />
        <form:errors path="name" />
      </div>
      <div>
        <label for="summary">Summary</label>
        <textarea id="summary" name="summary"></textarea>
        <form:errors path="summary" />
      </div>
      <div>
        <label for="pages">Pages</label>
        <input id="pages" name="pages" type="number" />
        <form:errors path="pages" />
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
    </form:form>
  </body>
</html>

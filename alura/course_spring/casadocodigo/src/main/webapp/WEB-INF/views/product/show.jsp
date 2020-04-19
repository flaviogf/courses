<%@ page language="java" contentType="text/html; charset=UTF-8" pageEncoding="UTF-8"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>
<%@taglib uri="http://www.springframework.org/tags" prefix="spring"%>
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form" %>
<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Casa do Código</title>
  </head>
  <body>
    <h1>${product.name}</h1>
    <p>${product.summary}</p>
    <p>${product.pages}</p>
    <form action='<c:url value="/basket" />' method="POST">
        <input id="productId" name="productId" type="hidden" value="${product.id}" />
        <c:forEach items="${product.prices}" var="price">
            <div>
                <label>${price.type}</label>
                <input id="priceType" name="priceType" type="radio" value=${price.type} />
            </div>
        </c:forEach>
        <button>Buy</button>
    </form>
  </body>
</html>

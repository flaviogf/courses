<%@ page language="java" contentType="text/html; charset=UTF-8" pageEncoding="UTF-8"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>
<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Casa do Código</title>
  </head>
  <body>
    <div>
      <span>${info}</span>
    </div>

    <table>
      <thead>
        <tr>
          <th>Name</th>
          <th>Summary</th>
          <th>Pages</th>
        </tr>
      </thead>
      <tbody>
        <c:forEach items="${products}" var="product">
          <tr>
            <td>${product.name}</td>
            <td>${product.summary}</td>
            <td>${product.pages}</td>
          </tr>
        </c:forEach>
      </tbody>
    </table>
  </body>
</html>

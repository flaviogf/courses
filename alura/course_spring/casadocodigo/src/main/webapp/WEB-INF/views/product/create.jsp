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
    <form:form action="${spring:mvcUrl('PC#store').build()}" method="POST" commandName="product" enctype="multipart/form-data" >
      <div>
        <label for="name">Name</label>
        <form:input path="name" />
        <form:errors path="name" />
      </div>
      <div>
        <label for="summary">Summary</label>
        <form:textarea path="summary"></form:textarea>
        <form:errors path="summary" />
      </div>
      <div>
        <label for="pages">Pages</label>
        <form:input path="pages" />
        <form:errors path="pages" />
      </div>
      <div>
        <label for="releaseDate">Release date</label>
        <form:input path="releaseDate" />
        <form:errors path="releaseDate" />
      </div>
      <c:forEach items="${priceTypes}" var="priceType" varStatus="status">
        <div>
          <label>${priceType}</label>
          <form:input path="prices[${status.index}].value" />
          <form:hidden path="prices[${status.index}].type" value="${priceType}" />
        </div>
      </c:forEach>
      <div>
        <label>Cover</label>
        <input id="file" name="file" type="file" />
      </div>
      <div>
        <button type="submit">Submit</button>
      </div>
    </form:form>
  </body>
</html>

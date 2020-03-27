<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>

<h3>Companies</h3>

<c:if test="${user != null}">
    <span>${user.username}</span>
</c:if>

<table>
  <thead>
    <tr>
      <th>Id</th>
      <th>Name</th>
      <th>Date</th>
    </tr>
  </thead>

  <tbody>
      <c:forEach items="${companies}" var="company">
          <c:url value="/company/edit" var="edit">
            <c:param value="${company.id}" name="id" />
          </c:url>

          <tr>
              <td><a href="${edit}">${company.id}</a></td>
              <td>${company.name}</td>
              <td>${company.foundationDate}</td>
          </tr>
      </c:forEach>
  </tbody>
</table>

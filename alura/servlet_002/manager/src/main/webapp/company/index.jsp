<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>

<h3>Companies</h3>

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
          <tr>
              <td>${company.id}</td>
              <td>${company.name}</td>
              <td>${company.date}</td>
          </tr>
      </c:forEach>
  </tbody>
</table>

<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>
<%@ taglib uri="http://java.sun.com/jsp/jstl/fmt" prefix="fmt" %>

<html>
    <body>
        <table>
            <thead>
                <tr>
                    <th>Id</th>
                    <th>Name</th>
                    <th>Date</th>
                    <th>Actions<th>
                </tr>
            </thead>
            <tbody>
                <c:forEach items="${companies}" var="company">
                    <tr>
                        <td>${company.id}</td>
                        <td>${company.name}</td>
                        <td><fmt:formatDate type="date" value="${company.date}" pattern="yyyy-MM-dd" /></td>
                        <td>
                            <c:url value="show" var="show">
                                <c:param name="id" value="${company.id}" />
                            </c:url>
                            <a href="${show}">Show</a>
                            <c:url value="destroy" var="destroy">
                                <c:param name="id" value="${company.id}" />
                            </c:url>
                            <a href="${destroy}">Destroy</a>
                            <c:url value="update" var="update">
                                <c:param name="id" value="${company.id}" />
                            </c:url>
                            <a href="${update}">Update</a>
                        </td>
                    </tr>
                </c:forEach>
            </tbody>
        </table>
    </body>
</html>

<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>

<html>
    <body>
        <ul>
            <c:forEach items="${companies}" var="company">
                <li>${company.id} ${company.name}</li>
            </c:forEach>
        </ul>
    </body>
</html>

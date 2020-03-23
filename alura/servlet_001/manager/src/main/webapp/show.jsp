<%@ taglib uri="http://java.sun.com/jsp/jstl/fmt" prefix="fmt" %>

<fmt:formatDate type="date" value="${company.date}" pattern="yyyy-MM-dd" var="date" />

<html>
    <body>
        <input name="name" value="${company.name}" type="text" disabled="true" />
        <input name="date" value="${date}" type="date" disabled="true" />
    </body>
</html>

<%@ taglib uri="http://java.sun.com/jsp/jstl/fmt" prefix="fmt" %>

<fmt:formatDate value="${company.date}" pattern="yyyy-MM-dd" var="date" />

<html>
    <body>
        <form method="post">
            <input name="id" value="${company.id}" hidden />
            <input name="name" value="${company.name}" />
            <input name="date" value="${date}" />
            <button>Update</button>
        </form>
    </body>
</html>

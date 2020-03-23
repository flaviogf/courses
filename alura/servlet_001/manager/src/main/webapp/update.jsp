<%@ taglib uri="http://java.sun.com/jsp/jstl/fmt" prefix="fmt" %>

<fmt:formatDate value="${company.date}" pattern="yyyy-MM-dd" var="date" />

<html>
    <body>
        <form method="post">
            <input name="id" value="${company.id}" type="hidden" />
            <input name="name" value="${company.name}" type="text" />
            <input name="date" value="${date}" type="date" />
            <button>Update</button>
        </form>
    </body>
</html>

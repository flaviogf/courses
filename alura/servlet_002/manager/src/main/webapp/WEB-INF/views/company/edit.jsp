<%@ taglib uri="http://java.sun.com/jsp/jstl/fmt" prefix="fmt" %>

<fmt:formatDate value="${company.foundationDate}" pattern="yyyy-MM-dd" var="date" />

<form method="POST" action="/company/update">
    <input name="id" id="id" value="${company.id}" type="hidden" />
    <div>
        <input name="name" id="name" placeholder="Nome" value="${company.name}" type="text" />
    </div>
    <div>
        <input name="foundationDate" id="foundationDate" placeholder="Foundation date" value="${date}" type="date" />
    </div>
    <button type="submit">Update</button>
</form>
<%@ page contentType="text/html;charset=UTF-8" %>
<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<html>
<head>
    <title>Produtos - Casa do Código</title>
</head>
<body>

<h1>Produtos - Casa do Código</h1>

<h3>${sucesso}</h3>

<table>
    <thead>
    <tr>
        <th>Titulo</th>
        <th>Descricao</th>
        <th>Paginas</th>
    </tr>
    </thead>
    <tbody>
    <c:forEach items="${produtos}" var="produto">
        <tr>
            <td>${produto.titulo}</td>
            <td>${produto.descricao}</td>
            <td>${produto.valor}</td>
        </tr>
    </c:forEach>
    </tbody>
</table>

</body>
</html>

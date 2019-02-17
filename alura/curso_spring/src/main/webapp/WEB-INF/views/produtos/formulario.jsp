<%@ page contentType="text/html;charset=UTF-8" %>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>
<%@ taglib prefix="form" uri="http://www.springframework.org/tags/form" %>
<html>
<head>
    <title>Produtos - Casa do Código</title>
</head>
<body>
<h1>Produtos - Casa do Código</h1>

<form:form action="/produtos" method="post" commandName="produto" enctype="multipart/form-data">

    <fieldset>
        <label for="titulo">Titulo</label>
        <form:input path="titulo" id="titulo"/>
        <form:errors path="titulo"/>
    </fieldset>

    <fieldset>
        <label for="descricao">Descrição</label>
        <form:textarea path="descricao" id="descricao"/>
        <form:errors path="descricao"/>
    </fieldset>

    <fieldset>
        <label for="valor">Valor</label>
        <form:input path="valor" id="valor"/>
        <form:errors path="valor"/>
    </fieldset>

    <fieldset>
        <label for="valor">Data de lançamento</label>
        <form:input path="dataLancamento" id="dataLancamento"/>
        <form:errors path="dataLancamento"/>
    </fieldset>

    <c:forEach items="${tipos}" var="tipo" varStatus="status">
        <fieldset>
            <label>${tipo}</label>
            <form:input path="precos[${status.index}].valor"/>
            <form:hidden path="precos[${status.index}].tipoPreco" value="${tipo}"/>
        </fieldset>
    </c:forEach>

    <fieldset>
        <label for="arquivoSumario">Sumario</label>
        <input id="arquivoSumario" name="arquivoSumario" type="file"/>
    </fieldset>

    <button type="submit">Salvar</button>
</form:form>

</body>
</html>

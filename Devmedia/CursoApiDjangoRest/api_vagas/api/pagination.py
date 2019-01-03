from rest_framework.pagination import PageNumberPagination


class VagaPagination(PageNumberPagination):
    page_size = 2
    page_query_param = 'pagina'

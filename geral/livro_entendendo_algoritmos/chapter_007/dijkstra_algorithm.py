grafo = {}

grafo["inicio"] = {}
grafo["inicio"]["a"] = 6
grafo["inicio"]["b"] = 2

grafo["a"] = {}
grafo["a"]["fim"] = 1

grafo["b"] = {}
grafo["b"]["a"] = 3
grafo["b"]["fim"] = 5

grafo["fim"] = {}

print(grafo)

custos = {}
custos["a"] = 6
custos["b"] = 2
custos["fim"] = float("inf")

print(custos)

pais = {}
pais["a"] = "inicio"
pais["b"] = "inicio"
pais["fim"] = None

print(pais)

processados = []

def custo_mais_baixo(custos):
    mais_baixo = float("inf")
    nodo_mais_baixo = None
    for nodo, custo in custos.items():
        if custo < mais_baixo and nodo not in processados:
            mais_baixo = custo
            nodo_mais_baixo = nodo
    return nodo_mais_baixo

nodo = custo_mais_baixo(custos)

while nodo is not None:
    custo = custos[nodo]
    vizinhos = grafo[nodo]
    for n in vizinhos.keys():
        novo_custo = custo + vizinhos[n]
        if custos[n] > novo_custo:
            custos[n] = novo_custo
            pais[n] = nodo
    processados.append(nodo)
    nodo = custo_mais_baixo(custos)


print(grafo)

print(custos)

print(pais)


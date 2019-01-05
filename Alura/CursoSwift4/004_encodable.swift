import Foundation

class Viagem : Encodable, CustomStringConvertible {

    enum CodingKeys: String, CodingKey {
        case id
        case local
        case preco
        case quantidadeDeDias = "quantidade_de_dias"
    }

    let id: Int
    let local: String
    let preco: String
    let quantidadeDeDias: Int

    init(_ id: Int, _ local: String, _ preco: String, _ quantidadeDeDias: Int) {
        self.id = id
        self.local = local
        self.preco = preco
        self.quantidadeDeDias = quantidadeDeDias
    }

    var description: String {
        return "Viagem(id=\(id), local=\(local), preco=\(preco), quantidadeDeDias=\(quantidadeDeDias))"
    }
}

let viagem = Viagem(1, "Franca", "R$ 1.00", 1)

if let data = try? JSONEncoder().encode(viagem), let json = String(data: data, encoding: .utf8) {
    print(json)
}

print(viagem)

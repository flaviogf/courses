Number.prototype.duasCasas = function () {
    return this.toFixed(2).replace('.', ',');
}

class Carrinho {

    clickIncrementar(btn) {
        var data = this.getData(btn);
        data.Quantidade++;
        this.postQuantidade(data);
    }

    clickDecrementar(btn) {
        var data = this.getData(btn);
        data.Quantidade--;
        this.postQuantidade(data);
    }

    updateData(input) {
        var data = this.getData(input);
        this.postQuantidade(data);
    }

    getData(elemento) {
        var linha = $(elemento).parents('[data-item-id]');
        var id = linha.attr('data-item-id');
        var quantidade = linha.find('input').val();
        return {
            Id: id,
            Quantidade: quantidade
        };
    }

    getItem(itemCarrinho) {
        return $(`[data-item-id=${itemCarrinho.id}]`);
    }

    setQuantidade(itemCarrinho) {
        if (itemCarrinho.quantidade <= 0) {
            this.getItem(itemCarrinho).remove();
            return;
        }
        this.getItem(itemCarrinho)
            .find('input').val(itemCarrinho.quantidade);
    }

    setSubTotal(itemCarrinho) {
        this.getItem(itemCarrinho)
            .find('[data-sub-total]').text(itemCarrinho.subTotal.duasCasas());
    }

    setTotal(carrinhoViewModel) {
        $('[data-total]').text(carrinhoViewModel.total.duasCasas());
    }

    setItens(carrinhoViewModel) {
        $('[data-itens]').html(`Total: ${carrinhoViewModel.itens.length} ${carrinhoViewModel.itens.length > 1 ? 'itens' : 'item'}`);
    }

    postQuantidade(data) {
        $.ajax({
            url: '/Pedido/PostQuantidade',
            method: 'POST',
            data: JSON.stringify(data),
            contentType: 'application/json'
        }).then((response) => {
            this.setQuantidade(response.itemCarrinho);
            this.setSubTotal(response.itemCarrinho);
            this.setTotal(response.carrinhoViewModel);
            this.setItens(response.carrinhoViewModel);
        });
    }
}

var carrinho = new Carrinho();
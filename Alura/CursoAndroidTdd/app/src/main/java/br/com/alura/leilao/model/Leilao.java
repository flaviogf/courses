package br.com.alura.leilao.model;

import java.io.Serializable;
import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.Comparator;
import java.util.List;
import java.util.stream.Collectors;

import br.com.alura.leilao.exceptions.MaisDeCincoLancesException;
import br.com.alura.leilao.exceptions.UltimoLanceMaiorException;
import br.com.alura.leilao.exceptions.UltimoUsuarioIgualException;

import static br.com.alura.leilao.utils.CollectionUtils.getUltimoItem;

public class Leilao implements Serializable {

    private final String descricao;
    private final List<Lance> lances;

    public Leilao(String descricao) {
        this.descricao = descricao;
        this.lances = new ArrayList<>();
    }

    public void propoe(Lance lance) {
        if (ultimoLanceMaiorQueNovoLance(lance)) throw new UltimoLanceMaiorException();
        if (usuarioIgualAoUltimoLance(lance)) throw new UltimoUsuarioIgualException();
        if (usuarioTemMaisDeCincoLances(lance)) throw new MaisDeCincoLancesException();
        lances.add(lance);
    }

    public String getDescricao() {
        return descricao;
    }

    public BigDecimal getMaiorLance() {
        return lances.stream()
                .map(Lance::getValor)
                .max(Comparator.naturalOrder())
                .orElse(BigDecimal.ZERO);
    }

    public BigDecimal getMenorLance() {
        return lances.stream()
                .map(Lance::getValor)
                .min(Comparator.naturalOrder())
                .orElse(BigDecimal.ZERO);
    }

    public List<Lance> getTresMaioresLances() {
        return lances.stream()
                .sorted()
                .limit(3)
                .collect(Collectors.toList());
    }

    private boolean usuarioTemMaisDeCincoLances(Lance lance) {
        return lances.stream()
                .filter(it -> it.getUsuario().equals(lance.getUsuario()))
                .collect(Collectors.toList())
                .size() >= 5;
    }

    private boolean usuarioIgualAoUltimoLance(Lance lance) {
        return getUltimoItem(lances).isPresent() && getUltimoItem(lances).get().getUsuario().equals(lance.getUsuario());
    }

    private boolean ultimoLanceMaiorQueNovoLance(Lance lance) {
        return getMaiorLance().compareTo(lance.getValor()) > 0;
    }
}

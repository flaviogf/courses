(function () {
  const TEMPO_INICIAL = 5;

  const elementoFrase = $("h4");
  const elementoQuantidadePalavrasFrase = $("#quantidade-palavras-frase");
  const elementoCampoDigitacao = $("#campo-digitacao");
  const elementoQuantidadeCaractersDigitadas = $("#quantidade-caracteres-digitadas");
  const elementoQuantidadePalavrasDigitadas = $("#quantidade-palavras-digitadas");
  const elementoTempoRestante = $("#tempo-restante");
  const elementoBtnReiniciar = $("#btn-reiniciar");

  const quantidadePalvarasFrase = elementoFrase.text().split(" ").length;
  elementoQuantidadePalavrasFrase.text(quantidadePalvarasFrase);

  function configuraBtnReinicia() {
    elementoBtnReiniciar.click(function () {
      elementoTempoRestante.text(TEMPO_INICIAL);
      elementoQuantidadeCaractersDigitadas.text(0);
      elementoQuantidadePalavrasDigitadas.text(0);
      elementoCampoDigitacao.attr("disabled", false);
      elementoCampoDigitacao.toggleClass("campo-digitacao-desabilitado");
      elementoCampoDigitacao.val("");
      configuraEventoFocusCampoDigitacao();
      elementoBtnReiniciar.attr("disabled", true);
    });
  }

  function configuarEventoInputCampoDigitacao() {
    elementoCampoDigitacao.on("input", function () {
      const texto = $(this).val();
      const palavras = texto.split(/\S+/).length - 1;
      const caracteres = texto.trim().length;
      elementoQuantidadeCaractersDigitadas.text(caracteres);
      elementoQuantidadePalavrasDigitadas.text(palavras);
    });
  }

  function configuraEventoFocusCampoDigitacao() {
    elementoCampoDigitacao.one("focus", function () {
      const id = setInterval(function () {
        let tempoRestante = +elementoTempoRestante.text();
        elementoTempoRestante.text(--tempoRestante);
        if (tempoRestante > 0) return;
        clearInterval(id);
        elementoCampoDigitacao.attr("disabled", true);
        elementoCampoDigitacao.toggleClass("campo-digitacao-desabilitado");
        elementoBtnReiniciar.attr("disabled", false);
      }, 1000);
    });
  }

  function incializa() {
    configuraBtnReinicia();
    configuarEventoInputCampoDigitacao();
    configuraEventoFocusCampoDigitacao();
  }

  incializa();
})();

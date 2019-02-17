export class Coracao {

  constructor(
    public cheio: boolean,
    public urlCoracaoCheio: string = '/assets/coracao_cheio.png',
    public urlCoracaoVazio: string = '/assets/coracao_vazio.png'
  ) { }

  exibiCoracao() {

    return this.cheio ? this.urlCoracaoCheio : this.urlCoracaoVazio;

  }

}

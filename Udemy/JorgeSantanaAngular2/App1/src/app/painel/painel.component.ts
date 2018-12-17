import { Component, OnInit, EventEmitter, Output, OnDestroy } from '@angular/core';

import { Frase } from '../shared/frase.model';
import { FRASES } from './painel-mock';

@Component({
  selector: '[app-painel]',
  templateUrl: './painel.component.html',
  styleUrls: ['./painel.component.css']
})
export class PainelComponent implements OnInit, OnDestroy {

  public frases: Frase[] = FRASES;
  public instrucao: string = 'Traduza esta frase';
  public resposta: string = '';

  public rodada: number = 0;
  public rodadaFrase: Frase;
  public progresso: number = 0;
  public tentativas: number = 3;
  @Output() public encerrarJogo: EventEmitter<string> = new EventEmitter();

  constructor() {

    this.atualizaRodada();

  }

  ngOnInit() {

  }

  ngOnDestroy() {

  }

  atualizaResposta(event: Event) {

    this.resposta = (<HTMLInputElement>event.target).value;

  }

  verificarResposta() {

    if (this.rodadaFrase.frasePtBr === this.resposta) {

      this.rodada++;
      this.progresso = this.progresso + (100 / this.frases.length);

      if (this.rodada === this.frases.length) {

        this.encerrarJogo.emit('vitoria');

      }

      this.atualizaRodada();

    } else {

      this.tentativas--;

      if (this.tentativas === -1) {

        this.encerrarJogo.emit('derrota');

      }

    }

  }

  atualizaRodada() {

    this.rodadaFrase = this.frases[this.rodada];
    this.resposta = '';

  }

}

import { Component, Input, OnInit, OnChanges } from '@angular/core';

import { Coracao } from '../shared/coracao.model';

@Component({
  selector: '[app-tentativas]',
  templateUrl: './tentativas.component.html',
  styleUrls: ['./tentativas.component.css']
})
export class TentativasComponent implements OnInit, OnChanges {

  @Input() tentativas: number;

  public coracoes: Coracao[] = [
    new Coracao(true),
    new Coracao(true),
    new Coracao(true)
  ];

  constructor() {

  }

  ngOnChanges() {

    if (this.tentativas !== this.coracoes.length) {

      const indice = this.coracoes.length - this.tentativas;

      this.coracoes[indice - 1].cheio = false;

    }

  }

  ngOnInit() {

  }

}

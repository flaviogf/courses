//dependencias
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

//componentes
import ContatoBuscaComponent from './contato-busca.component';
import ContatoDetalheComponent from './contato-detalhe.component';
import ContatosListaComponent from './contatos-lista.component';

//modulos
import ContatoRoutingModule from './contato-rounting.module';

//services
import ContatoService from './contato.service';
import DialogService from './../dialog.service';

@NgModule({
    imports: [
        CommonModule,
        ContatoRoutingModule,
        FormsModule
    ],
    declarations: [
        ContatoBuscaComponent,
        ContatoDetalheComponent,
        ContatosListaComponent
    ],
    exports: [
        ContatoBuscaComponent,
        ContatoDetalheComponent,
        ContatosListaComponent
    ],
    providers: [
        ContatoService,
        DialogService
    ]
})
export default class ContatosModule {}

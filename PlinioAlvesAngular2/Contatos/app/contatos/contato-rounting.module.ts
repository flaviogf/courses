//dependencias
import { NgModule } from '@angular/core';
import { RouterModule, Route } from '@angular/router';

//componentes
import ContatoDetalheComponent from './contato-detalhe.component';
import ContatosListaComponent from './contatos-lista.component';

const contatoRoutes: Route[] = [
    {
        path: 'contato',
        component: ContatosListaComponent
    },
    {
        path: 'contato/save',
        component: ContatoDetalheComponent
    },
    {
        path: 'contato/save/:id',
        component: ContatoDetalheComponent
    }
];

@NgModule({
    imports: [ RouterModule.forChild(contatoRoutes) ],
    exports: [ RouterModule ]
})
export default class ContatoRountingModule {}

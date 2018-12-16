//dependencias
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { InMemoryWebApiModule } from 'angular-in-memory-web-api';
import './utils/rxjs-extensions';

//componente
import AppComponent from './app.component';

//modulos
import AppRoutingModule from './app-rounting.module';
import ContatosModule from './contatos/contatos.module';

//services
import InMemoryDataService from './in-memory-data.service';

@NgModule({
    imports: [ 
        AppRoutingModule,
        BrowserModule,
        FormsModule,
        ContatosModule,
        HttpModule,
        InMemoryWebApiModule.forRoot(InMemoryDataService)
    ],
    declarations: [ AppComponent ],
    bootstrap: [ AppComponent ]
})
export default class AppModule {};

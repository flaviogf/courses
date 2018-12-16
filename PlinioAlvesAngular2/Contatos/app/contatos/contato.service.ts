//dependencias
import { Injectable } from '@angular/core';
import { Http, Headers } from '@angular/http';
import Contato from './contato.model';
import { Observable } from 'rxjs';

//lista de contatos
import { CONTATOS } from './contatos-mock';

//bibliotecas auxiliares
import 'rxjs/add/operator/toPromise';

//interface
import { ServiceInterface } from './../interfaces/service.interfaces';

@Injectable()
export default class ContatoService implements ServiceInterface<Contato> {
    private url: string = 'app/contatos';
    private headers: Headers = new Headers({ 'Content-Type': 'application/json' });

    constructor(private http: Http) {}

    findAll(): Promise<Contato[]> {
        return this.http.get(this.url)
            .toPromise()
            .then(response => response.json().data as Contato[])
            .catch(error => Promise.reject(error));
    }

    find(id: number): Promise<Contato> {
        return this.findAll()
            .then((contatos: Contato[]) => contatos.find((contato: Contato) => contato.id === id));
    }

    create(contato: Contato): Promise<Contato> {
        return this.http.post(this.url, JSON.stringify(contato), this.headers)
            .toPromise()
            .then(response => response.json().data as Contato)
            .catch(error => Promise.reject(error));
    }

    update(contato: Contato): Promise<Contato> {
        const url = `${this.url}/${contato.id}`;
        return this.http.put(url, JSON.stringify(contato), this.headers)
            .toPromise()
            .then(() => contato)
            .catch(error => Promise.reject(error));
    }

    deletar(contato: Contato): Promise<Contato> {
        const url = `${this.url}/${contato.id}`;
        return this.http.delete(url)
            .toPromise()
            .then(() => contato)
            .catch(error => Promise.reject(error));
    }

    search(termo: string): Observable<Contato[]> {
        return this.http.get(`${this.url}/?nome=${termo}`)
            .map(res => res.json().data as Contato[]);
    }
}

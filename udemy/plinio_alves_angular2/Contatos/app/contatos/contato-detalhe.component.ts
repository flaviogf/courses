//dependencias
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { Location } from '@angular/common';
import Contato from './contato.model';

//services
import ContatoService from './contato.service';

@Component({
    moduleId: module.id,
    selector: 'contato-detalhe',
    templateUrl: 'contato-detalhe.component.html'
})
export default class ContatoDetalheComponent implements OnInit{
    contato: Contato;
    isNew: boolean = true;

    constructor(
        private contatoService: ContatoService,
        private route: ActivatedRoute,
        private location: Location
    ) {}

    ngOnInit(): void {
        this.contato = new Contato(0, '', '', '');

        this.route.params.forEach((param: Params) => {
            const id: number = +param['id'];

            if(id) {
                this.isNew = false;

                this.contatoService.find(id)
                    .then((contato: Contato) => this.contato = contato)
                    .catch((error: any) => console.log(error));
            }
        });
    }

    getFormGroupClass(valid: boolean, pristine: boolean): Object {
        return {
            'form-group': true,
            'has-success': valid && !pristine,
            'has-danger': !valid && !pristine
        };
    }

    getFormControlClass(valid: boolean, pristine: boolean): Object {
        return {
            'form-control': true,
            'form-control-success': valid && !pristine,
            'form-control-danger': !valid && !pristine
        };
    }

    onSubmit(): void {
        let promise: Promise<Contato>;

        if(this.isNew){
            promise = this.contatoService.findAll()
                .then(contatos => {
                    if(contatos.length > 0)
                        return contatos.reverse()[0].id + 1;
                    else
                        return 1;
                })
                .then(id => this.contato.id = id)
                .then(() => this.contatoService.create(this.contato));
        }
        else
            promise = this.contatoService.update(this.contato);

        promise.then((contato: Contato) => this.goBack());
    }

    goBack(): void {
        this.location.back();
    }
}

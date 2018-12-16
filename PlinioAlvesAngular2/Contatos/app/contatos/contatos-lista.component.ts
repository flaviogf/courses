//dependencias
import { Component, OnInit } from '@angular/core';
import Contato from './contato.model';

//services
import ContatoService from './contato.service';
import DialogService from './../dialog.service';

@Component({
    moduleId: module.id,
    selector: 'contatos-lista',
    templateUrl: 'contatos-lista.component.html'
})
export default class ContatosListaComponent implements OnInit {
    contatos: Contato[] = [];
    mensagem: Object;
    alertClass: Object;
    private timeOutAtual: any;

    constructor(
        private contatoService: ContatoService,
        private dialogService: DialogService
    ) {}

    ngOnInit(): void {
        this.contatoService.findAll()
            .then((contatos: Contato[]) => this.contatos = contatos)
            .catch(() => this.messageAlert('danger', 'erro ao buscar os contatos'));
    }

    onDelete(contato: Contato): void {
        this.dialogService.confirm('Deseja deletar o contato: ' + contato.nome)
            .then((confirmar: boolean) => {
                if(confirmar) {
                    this.contatoService.deletar(contato)
                        .then(() => {
                            this.messageAlert('success', 'o contato foi excluido');
                            this.contatos = this.contatos.filter(c => c.id !== contato.id);
                        })
                        .catch(() => this.messageAlert('danger', 'erro ao excluir o contato'));
                }
            })
    }

    messageAlert(tipo: string, texto: string): void {
        if(tipo !== 'danger') {
            if(this.timeOutAtual) {
                clearTimeout(this.timeOutAtual);
            }

            this.timeOutAtual = setTimeout(() => this.mensagem = undefined, 4000);
        }
            
        this.mensagem = { tipo, texto };
        this.alertClass = { 
            'alert': true,
            'alert-success': tipo === 'success',
            'alert-danger': tipo === 'danger'
        }
    }
}

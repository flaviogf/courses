//dependencias
import { Component, EventEmitter, OnInit, OnChanges, Output, Input, SimpleChange, SimpleChanges } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Subject } from 'rxjs/Subject';
import Contato from './contato.model';
import { Router } from '@angular/router';

//services
import ContatoService from './contato.service';

@Component({
    moduleId: module.id,
    selector: 'contato-busca',
    templateUrl: 'contato-busca.component.html',
    styles: [`
        .cursor-pointer:hover {
            cursor: pointer;
        }
    `]
})
export default class ContatoBuscaComponent implements OnInit, OnChanges {
    @Input() busca: string;
    @Output() buscaChange: EventEmitter<string> = new EventEmitter<string>();
    contatos: Observable<Contato[]>;
    private termosBusca: Subject<string> = new Subject<string>();

    constructor(
        private contatoService: ContatoService,
        private router: Router
    ) { }

    ngOnInit(): void {
        this.contatos = this.termosBusca
            .debounceTime(500)
            .distinctUntilChanged()
            .switchMap(termo => termo ? this.contatoService.search(termo) : Observable.of<Contato[]>([]))
            .catch(err => Observable.of<Contato[]>());

        this.contatos.subscribe((contatos: Contato[]) => contatos);
     }

     ngOnChanges(changes: SimpleChanges): void {
        let busca: SimpleChange = changes['busca'];
        this.search(busca.currentValue);
     }

    search(termo: string): void {
        this.termosBusca.next(termo);
        this.buscaChange.emit(termo);
    }

    verDetalhe(contato: Contato): void {
        this.router.navigate(['contato/save', contato.id]);
        this.buscaChange.emit('');
    }
}

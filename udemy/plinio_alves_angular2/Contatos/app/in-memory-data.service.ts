//dependencias
import { InMemoryDbService } from 'angular-in-memory-web-api';
import Contato from './contatos/contato.model';

export default class InMemoryDataService implements InMemoryDataService {
    createDb(): Object {
        const contatos: Contato[] = [
            { id: 1, nome: 'Flavio', email: 'flavio@email.com', telefone: '(99)99999-9999' },
            { id: 2, nome: 'Fatima', email: 'fatima@email.com', telefone: '(99)99999-9999' },
            { id: 3, nome: 'Luis Fernando', email: 'luis@email.com', telefone: '(99)99999-9999' },
        ];

        return { contatos };
    }
}

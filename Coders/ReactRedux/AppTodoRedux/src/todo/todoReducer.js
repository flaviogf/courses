const INITIAL_STATE = {
    description: 'Tarefa teste',
    list: [
        {
            _id: 1,
            description: 'Pagar fatura do cartão',
            done: true
        },
        {
            _id: 2,
            description: 'Reunião com a equipe às 10:00',
            done: false
        },
        {
            _id: 3,
            description: 'Consulta médica na terça depois do almoço',
            done: false
        }
    ]
};

export default (state = INITIAL_STATE, action) => {
    switch(action.type) {
        case 'DESCRIPTION_CHANGED':
            return { ...state, description: action.payload }; break;
        case 'TODO_SEARCH':
            return { ...state, list: action.payload.data }; break;
        case 'TODO_ADDED':
            return { ...state, description: '' }; break;
        default:
            return state;
    }
};
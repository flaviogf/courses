const INITIAL_STATE = {
  lista: []
};

export default (state = INITIAL_STATE, action) => {
  switch (action.type) {
    case 'BILLING_CYCLES_FETCHED':
      return { ...state, lista: action.payload };
    default:
      return state;
  }
};

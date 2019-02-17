const INITIAL_STATE = { sumary: { credito: 0, debito: 0 } };

const DashboardReducer = (state = INITIAL_STATE, action) => {
  switch (action.type) {
    case 'GET_SUMARY':
      return { ...state, sumary: action.payload };
    default:
      return state;
  }
};

export default DashboardReducer;

import { combineReducers } from 'redux';
import { reducer as formReducer } from 'redux-form';
import { reducer as toastReducer } from 'react-redux-toastr';

import DashboardReducer from '../dashboard/dashboardReducer';
import TabReducer from '../common/tabs/tabReducer';
import BillingCycleReducer from '../billingCycle/billingCyclesReducer';

const reducer = combineReducers({
  dashboard: DashboardReducer,
  tab: TabReducer,
  billingCycle: BillingCycleReducer,
  form: formReducer,
  toastr: toastReducer
});

export default reducer;

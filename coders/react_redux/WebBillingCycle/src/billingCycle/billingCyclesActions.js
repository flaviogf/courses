import axios from 'axios';
import { toastr } from 'react-redux-toastr';
import { reset as resetFrom, initialize } from 'redux-form';
import { showTabs, selectTab } from '../common/tabs/tabActions';

const BASE_URL = 'http://localhost:3003/api';
const INITIAL_VALUES = { creditos: [{ valor: 0 }], debitos: [{ valor: 0 }] };

export const getList = async () => {
  const response = await axios.get(`${BASE_URL}/billingCycle`);
  return {
    type: 'BILLING_CYCLES_FETCHED',
    payload: response.data
  };
};

export const create = (values) => submit(values, 'post');

export const update = (values) => submit(values, 'put');

export const remove = (values) => submit(values, 'delete');

const submit = (values, method) => async (dispatch) => {
  try {
    const id = values._id || '';
    await axios[method](`${BASE_URL}/billingCycle/${id}`, values);
    toastr.success('Sucesso', 'adicionado com sucesso');
    dispatch(init());
  } catch (error) {
    error.response.data.erros.forEach((erro) => toastr.error('Erro', erro));
  }
  return {
    type: 'TEMP'
  };
}

export const showUpdate = (bc) => [
  showTabs('alterar'),
  selectTab('alterar'),
  initialize('billingCycleForm', bc)
];

export const showDelete = (bc) => [
  showTabs('excluir'),
  selectTab('excluir'),
  initialize('billingCycleForm', bc)
];

export const init = () => [
  showTabs('listar', 'incluir'),
  selectTab('listar'),
  getList(),
  initialize('billingCycleForm', INITIAL_VALUES)
];

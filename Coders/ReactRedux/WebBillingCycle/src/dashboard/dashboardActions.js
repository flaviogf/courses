import axios from 'axios';
const BASE_URL = 'http://localhost:3003/api/billingCycle';

export const getSumary = async () => {
  const request = await axios.get(`${BASE_URL}/sumary`);
  return {
    type: 'GET_SUMARY',
    payload: request.data
  };
};

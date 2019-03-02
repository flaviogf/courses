import Cadastro from './components/cadastro/Cadastro.vue'
import Home from './components/home/Home.vue'

export default [
  {
    path: '',
    component: Home,
    name: 'Home'
  },
  {
    path: '/cadastro',
    component: Cadastro,
    name: 'Cadastro'
  }
]

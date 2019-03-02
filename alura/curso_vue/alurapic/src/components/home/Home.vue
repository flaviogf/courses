<template>
  <div>
    <h1>{{ titulo }}</h1>
    <input type="text" placeholder="filtre pelo nome" @input="filtro = $event.target.value">
    <ul>
      <li v-for="foto of fotosFiltradas">
        <alurapic-painel :titulo="foto.titulo">
          <img :src="foto.url" :alt="foto.titulo">
        </alurapic-painel>
      </li>
    </ul>
  </div>
</template>

<script>
import Painel from "../shared/painel/Painel.vue";

export default {
  components: {
    "alurapic-painel": Painel
  },
  created() {
    this.$http
      .get("http://localhost:3000/v1/fotos")
      .then(res => res.json())
      .then(fotos => (this.fotos = fotos))
      .catch(console.log);
  },
  data() {
    return {
      titulo: "Alurapic",
      fotos: [],
      filtro: ""
    };
  },
  computed: {
    fotosFiltradas() {
      if (!this.filtro) {
        return this.fotos;
      } else {
        const filtro = new RegExp(this.filtro, "i");
        return this.fotos.filter(it => filtro.test(it.titulo));
      }
    }
  }
};
</script>

<style lang="sass">

</style>

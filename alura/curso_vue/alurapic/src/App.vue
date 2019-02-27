<template>
  <div>
    <h1>{{ titulo }}</h1>
    <ul>
      <li v-for='foto of fotos'>
        <img :src="foto.url" :alt="foto.titulo">
      </li>
    </ul>
  </div>
</template>

<script>
export default {
  created() {
    this.$http.get('http://localhost:3000/v1/fotos')
      .then(res => res.json())
      .then(fotos => this.fotos = fotos)
      .catch(console.log)
  },
  data() {
    return {
      titulo: 'Alurapic',
      fotos: [],
    }
  },
}
</script>

<style lang="scss">
</style>

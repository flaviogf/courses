<template>
  <div>
    <alurapic-menu :routes="routes"></alurapic-menu>
    <div class="conteudo">
      <transition name="fade">
        <router-view></router-view>
      </transition>
    </div>
  </div>
</template>

<script>
import Menu from "./components/shared/menu/Menu.vue";
import routes from "./routes";

export default {
  components: {
    "alurapic-menu": Menu
  },
  data() {
    return {
      routes
    };
  }
};
</script>

<style lang="sass">
body
  font-family: Helvetica, sans-serif
  background-color: #f5f5f5
  text-align: center
  margin: 0 auto
  color: #2f2f2f
  width: 75%

ul
  padding: 0


ul li
  list-style-type: none
  display: inline-block

img
  width: 100%

input
  padding: 3px 5px
  font-size: 18px
  height: 35px
  width: 100%

a
  color: #2f2f2f

.conteudo
  margin-top: 60px

.fade-enter, .fade-leave-to
  opacity: 0

.fade-enter-active, fade-leave-active
  transition: opacity .3s
</style>

<template>
  <div @dblclick="fotoVisivel = !fotoVisivel" class="painel">
    <div class="painel__titulo">{{ titulo }}</div>
    <transition name="fade">
      <div v-if="fotoVisivel" class="painel__conteudo">
        <slot></slot>
      </div>
    </transition>
  </div>
</template>

<script>
export default {
  props: ["titulo"],
  data() {
    return {
      fotoVisivel: false
    };
  }
};
</script>

<style lang="sass" scoped>
.painel
  box-shadow: 0 1px 1px rgba(0,0,0,.2)
  background-color: white
  overflow-x: hidden
  overflow-y: hidden
  flex-direction: column
  border-radius: 3px
  padding: 8px 7px
  max-height: 275px
  width: 275px
  display: flex
  margin: 5px

.painel__titulo
  user-select: none
  font-weight: bold
  padding: 5px
  font-size: 24px
  flex: 1

.painel__conteudo
  align-items: center
  user-select: none
  display: flex
  padding: 5px
  flex: 3

.fade-enter, .fade-leave-to
  opacity: 0

.fade-enter-active, .fade-leave-active
  transition: opacity .25s
</style>

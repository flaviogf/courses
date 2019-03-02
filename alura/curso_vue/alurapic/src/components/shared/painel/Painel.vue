<template>
  <div class="painel">
    <div class="painel__titulo">{{ titulo }}</div>
    <div class="painel__conteudo">
      <slot></slot>
    </div>
  </div>
</template>

<script>
export default {
  props: ["titulo"]
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
  height: 275px
  width: 275px
  display: flex
  margin: 5px

.painel__titulo
  font-weight: bold
  padding: 5px
  font-size: 24px
  flex: 1

.painel__conteudo
  padding: 5px
  align-items: center
  display: flex
  flex: 3
</style>

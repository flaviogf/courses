<template>
  <nav>
    <ul>
      <li v-for="it of routes">
        <router-link :to="it.path || '/'">{{ it.name }}</router-link>
      </li>
    </ul>
  </nav>
</template>

<script>
export default {
  props: {
    routes: {
      required: true,
      type: Array
    }
  }
};
</script>

<style lang="sass" scoped>
nav
  box-shadow: 0 1px 1px rgba(0,0,0,.3)
  background-color: white
  position: fixed
  height: 50px
  top: 0
  right: 0
  left: 0

ul
  text-align: left
  margin: 0 auto
  height: 100%
  width: 75%


ul li
  padding: 0 8px 0 0
  height: 100%

ul li a
  text-decoration: none
  align-items: center
  display: flex
  height: 100%
</style>

<template>
  <div>
    <the_header></the_header>
    <div class="main">
      <the_navbar></the_navbar>
      <the_content></the_content>
    </div>
  </div>
</template>

<script>

import the_header from './components/layout/the_header.vue'
import the_navbar from './components/layout/the_navbar.vue'
import the_content from './components/layout/the_content.vue'
export default {
  name: 'App',
  components: {
    the_header,
    the_navbar,
    the_content
    
  }
}
</script>

<style>
@import url(./style/css/main.css);
</style>

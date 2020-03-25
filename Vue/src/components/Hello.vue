<template>
  <div class="hello">
    <h1>{{ msg }}</h1>
    <h2>Discover the app</h2>
    <ul>
      <li class="nav-item"><router-link :to="{ name: 'AssociationsList'}">Associations list</router-link></li>
    </ul>
  </div>
</template>

<script>
export default {
  name: 'hello',
  data () {
    return {
      msg: 'Welcome to AssociationsManager'
    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style>
.hello {
  text-align: center;
}

h1, h2 {
  font-weight: normal;
}

ul {
  list-style-type: none;
  padding: 0;
}

li {
  display: inline-block;
  margin: 0 10px;
}

a {
  color: #35495E;
}
</style>

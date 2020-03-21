<template>
  <div>
  	<ul>
  		<li v-for="association in associations">
  			<b>{{ association.Name }}</b></br>
  			<p>{{ association.Description }}</p>
  		</li>
  	</ul>
  </div>
</template>

<script>
import axios from 'axios'

export default {
  name: 'associationsList',
  data () {
    return {
      associations: null
    }
  },
  mounted () {
    axios
      .get('https://localhost:44302/api/associations')
      .then(response => (this.associations = response.data))
      .catch(error => console.log(error))
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style>
h1, h2 {
  font-weight: normal;
}

ul {
  list-style-type: none;
  padding: 0;
}

li {
  margin: 0 10px;
}

a {
  color: #35495E;
}
</style>

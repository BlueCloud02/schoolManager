<template>
  <div>
    <!-- Error messages -->
    <b-alert variant="danger" v-model="showErrorLoadingData" fade>
      Error when loading data
      <a href="#" class="alert-link" v-on:click="getAssociation">Reload</a>
    </b-alert>
    <b-alert variant="danger" v-model="showErrorSubmitForm" dismissible fade>
      Error when submitting form
    </b-alert>
    <!-- Navigation -->
    <div class="float-right">
      <router-link :to="{ name: 'AssociationsList'}">Go back to associations list</router-link>
    </div>
    <!-- Title -->
    <h1>{{ title }}</h1>
    <!-- Form -->
    <form @submit.stop.prevent="submit">
      <div class="form-group">
        <label for="name">Name</label>
        <input v-model="association.name" type="text" class="form-control" id="name">
      </div>
      <div class="form-group">
        <label for="description">Description</label>
        <textarea v-model="association.description" class="form-control" id="description" rows="3"></textarea>
      </div>
      <button type="submit" class="btn btn-primary">Submit</button>
    </form>
  </div>
</template>

<script>
import api from '@/AssociationsApiService'

export default {
  name: 'associationEdit',
  data () {
    return {
      title: this.$route.params.id ? 'Edit association' : 'Create an association',
      association: {},
      showErrorLoadingData: false,
      showErrorSubmitForm: false
    }
  },
  async created () {
    if (this.$route.params.id) {
      this.getAssociation()
    }
  },
  methods: {
    async getAssociation () {
      this.showErrorLoadingData = false
      api.getOne(this.$route.params.id).then((result) => {
        this.association = result
      }).catch((err) => {
        console.debug(err)
        this.showErrorLoadingData = true
      })
    },
    async submit () {
      this.showErrorSubmitForm = false
      // Update association
      if (this.$route.params.id) {
        api.update(this.$route.params.id, this.association).then((result) => {
          this.$router.push({ name: 'AssociationsList' })
        }).catch((err) => {
          console.debug(err)
          this.showErrorSubmitForm = true
        })
      } else { // Create association
        api.create(this.association).then((result) => {
          this.$router.push({ name: 'AssociationsList' })
        }).catch((err) => {
          console.debug(err)
          this.showErrorSubmitForm = true
        })
      }
    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style>
</style>

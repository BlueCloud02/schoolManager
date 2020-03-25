<template>
  <div>
    <!-- Error messages -->
    <b-alert variant="danger" v-model="showErrorLoadingData" fade>
      Error when loading data
      <a href="#" class="alert-link" v-on:click="getAll">Reload</a>
    </b-alert>
    <b-alert variant="danger" v-model="showErrorLoadingData" dismissible fade>
      Error when deleting association
    </b-alert>
    <!-- Navigation -->
    <div class="float-right">
      <router-link :to="{ name: 'AssociationEdit'}" class="btn btn-success">Create an association</router-link>
    </div>
    <!-- Title -->
    <h1>{{ title }}</h1>
    <!-- Associations list -->
    <table class="table">
      <thead>
        <tr>
          <th scope="col">Name</th>
          <th scope="col">Description</th>
          <th scope="col" style="width: 170px">Actions</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="association in associations" :key="association.id">
          <td>{{ association.name }}</td>
          <td>{{ association.description }}</td>
          <td>
            <router-link :to="{ name: 'AssociationEdit', params: { id : association.id }}" class="btn btn-primary">Edit</router-link>
            <button type="button" class="btn btn-danger" v-on:click="deleteAssociation(association.id)">Delete</button>
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
import api from '@/AssociationsApiService'

export default {
  name: 'associationsList',
  data () {
    return {
      title: 'Associations list',
      associations: null,
      showErrorLoadingData: false,
      showErrorDeleteAssociation: false
    }
  },
  async created () {
    this.getAll()
  },
  methods: {
    async getAll () {
      this.showErrorLoadingData = false
      api.getAll().then((result) => {
        this.associations = result
      }).catch((err) => {
        console.debug(err)
        this.showErrorLoadingData = true
      })
    },
    async deleteAssociation (id) {
      this.showErrorDeleteAssociation = false
      api.delete(id).then((result) => {
        // Remove deleted association from this.associations
        let i = this.associations.map(association => association.id).indexOf(id)
        this.associations.splice(i, 1)
      }).catch((err) => {
        console.debug(err)
        this.showErrorDeleteAssociation = true
      })
    }
  }
}
</script>

<style>
table {
  margin: 30px 0;
}
</style>

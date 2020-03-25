# SchoolManager
This repository is a learning project where you can manage the student associations of a school. It uses different technologies: MongoDB, ASP.Net Core, Vue.JS with Vue-Cli and Vuex, Elasticsearch and Docker.

## Directory architecture
### SchoolApi
It contains an ASP.Net Core 3 project. The structure follows the recommandations of this tutorial: [https://docs.microsoft.com/fr-fr/aspnet/core/tutorials/first-mongo-app?view=aspnetcore-3.0&tabs=visual-studio](https://docs.microsoft.com/fr-fr/aspnet/core/tutorials/first-mongo-app?view=aspnetcore-3.0&tabs=visual-studio)

### Vue
It is a Node project including Vue package. It uses the PWA template for Vue.js applications.
Under _src_ directory:
* _router_: there are routes with vue-router
* _components_: there are our app components, in particular those used by router
* App.vue: the layout of our application
* AssociationApiService: contains the endpoints we use in our application

## Install & Run project
* Clone the repository
* Create a MongoDb database called SchoolDb and a collection called Associations. Insert the data below in your collection:
```json
[
  {
    "Name": "Enactus",
    "Description": "Worldwide association promoting entrepreneurship for environmental and social issues"
  },
  {
    "Name": "International Students Association",
    "Description": "Association that helps and organize events for international students"
  }
]
```
* In Visual Studio, open the solution in SchoolApi directory and run it with IIS Express. It opens your browser on [https://localhost:44302/api/association](https://localhost:44302/api/association) where you see all the associations of your database
* With Node Command Prompt, go in Vue directory and launch `npm start`. It opens your browser on [http://localhost:8080/](http://localhost:8080/) where you can manage the associations

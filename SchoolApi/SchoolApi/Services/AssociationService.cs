using MongoDB.Driver;
using SchoolApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace SchoolApi.Services
{
    public class AssociationService
    {
        private readonly IMongoCollection<Association> _associations;

        public AssociationService(ISchoolDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _associations = database.GetCollection<Association>(settings.AssociationsCollectionName);
        }

        public List<Association> Get() =>
            _associations.Find(association => true).ToList();

        public Association Get(string id) =>
            _associations.Find<Association>(book => book.Id == id).FirstOrDefault();

        public Association Create(Association asso)
        {
            _associations.InsertOne(asso);
            return asso;
        }

        public void Update(string id, Association assoIn) =>
            _associations.ReplaceOne(association => association.Id == id, assoIn);

        public void Remove(Association assoIn) =>
            _associations.DeleteOne(association => association.Id == assoIn.Id);

        public void Remove(string id) =>
            _associations.DeleteOne(association => association.Id == id);
    }
}
namespace SchoolApi.Models
{
    public class SchoolDatabaseSettings : ISchoolDatabaseSettings
    {
        public string AssociationsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface ISchoolDatabaseSettings
    {
        string AssociationsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
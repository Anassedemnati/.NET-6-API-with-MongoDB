namespace api_with_MongoDb.Models
{
    public interface IStudentStoreDatabaseSettings
    {
        string StudentCouresesCollectionName { get;set;}
        string ConnectionString { get; set;}
        string DatabaseName { get; set;}    
    }
}

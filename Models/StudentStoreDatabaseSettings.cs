namespace api_with_MongoDb.Models
{
    public class StudentStoreDatabaseSettings: IStudentStoreDatabaseSettings
    {
        public string StudentCouresesCollectionName { get; set; } = string.Empty;
        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
    }
}

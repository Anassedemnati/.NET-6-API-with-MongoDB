using api_with_MongoDb.Models;
using MongoDB.Driver;

namespace api_with_MongoDb.Services
{
    public class StudentServiceImp : IStudentService
    {
        private readonly IMongoCollection<Student> _students;

        public StudentServiceImp(IStudentStoreDatabaseSettings settings,IMongoClient mongoClient)
        {
           var database =  mongoClient.GetDatabase(settings.DatabaseName);
            _students= database.GetCollection<Student>(settings.StudentCouresesCollectionName);
        }
        public Student Create(Student student)
        {
            _students.InsertOne(student);
            return student;
        }

        public List<Student> Get()
        {
             return _students.Find(student => true).ToList();
        }

        public Student GetById(string id)
        {
            return _students.Find(student=>student.Id == id).FirstOrDefault();
        }
        public void Delete(string id)
        {
            _students.DeleteOne(student => student.Id == id);
        }
        public void Update(string id, Student student)
        {
            _students.ReplaceOne(student => student.Id == id,student);
        }
    }
}

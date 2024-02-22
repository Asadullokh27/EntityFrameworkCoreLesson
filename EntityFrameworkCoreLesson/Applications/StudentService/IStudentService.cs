using EntityFrameworkCoreLesson.Models;

namespace EntityFrameworkCoreLesson.Applications.StudentService 
{
    public interface IStudentService
    {

        public Task<string> CreateStudentAsync(Student type);
        public Task<List<Student>> GetAllStudentsAsync();
        public Task<Student> GetStudentByIdAsync(int id);
        public Task<string> UpdateStudentAsync(int id, Student type);
        public Task<string> DeleteStudentByIdAsync(int id);

    }
}

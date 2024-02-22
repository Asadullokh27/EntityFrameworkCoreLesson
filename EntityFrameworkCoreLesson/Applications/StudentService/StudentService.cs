using EntityFrameworkCoreLesson.Infrastructure;
using EntityFrameworkCoreLesson.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCoreLesson.Applications.StudentService
{
    public class StudentService : IStudentService
    {

        private ApplicationDBContext _context;

        public StudentService(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<string> CreateStudentAsync(Student type)
        {
            await _context.Students.AddAsync(type);
            await _context.SaveChangesAsync();

            return "Created Successfully";
        }

        public async Task<List<Student>> GetAllStudentsAsync()
        {
            var result = await _context.Students.ToListAsync();

            return result;
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            var result = await _context.Students.FirstOrDefaultAsync(x => x.Id == id);

            return result ?? new Student() { };
        }

        public async Task<string> UpdateStudentAsync(int id, Student type)
        {
            var result = await _context.Students.FirstAsync(x => x.Id == id);

            if (result is not null)
            {
                result.FullName = type.FullName;
                result.Age = type.Age;
                result.Field = type.Field;
                result.GroupNumber = type.GroupNumber;
                _context.SaveChanges();
                return "Updated Successfully";
            }
            return "No, something went wrong";
        }
        public async Task<string> DeleteStudentByIdAsync(int id)
        {
            var phone = await _context.Students.FirstAsync(x => x.Id == id);
            if (phone is not null)
            {
                _context.Students.Remove(phone);
                _context.SaveChanges();
                return "Deleted Successfully";
            }
            return "No, something went wrong";
        }

    }
}

using EntityFrameworkCoreLesson.Infrastructure;
using EntityFrameworkCoreLesson.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCoreLesson.Applications.LearningCentreService
{
    public class LearningCentreService : ILearningCentreService
    {

        private ApplicationDBContext _context;

        public LearningCentreService(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<string> CreateLearningCentreAsync(LearningCentre model)
        {
            await _context.LearningCentres.AddAsync(model);
            await _context.SaveChangesAsync();

            return "Created successfullly";
        }

        public async Task<List<LearningCentre>> GetAllLearningCentreAsync()
        {
            List<LearningCentre>? item = await _context.LearningCentres.ToListAsync();

            return item;
        }

        public async Task<LearningCentre> GetPhoneStoreByIdAsync(int id)
        {
            LearningCentre? item = await _context.LearningCentres.FirstOrDefaultAsync(predicate: x => x.Id == id);

            return item!;
        }

        public async Task<string> UpdatePhoneStoreAsync(int id, LearningCentre centre)
        {
            var item = await _context.LearningCentres.FirstOrDefaultAsync(x => x.Id == id);

            if (item is not null)
            {
                item.StudentId = centre.StudentId;
                item.PhoneNumber = centre.PhoneNumber;
                item.Email = centre.Email;
                item.Teacher = centre.Teacher;

                _context.SaveChanges();
                return "Updated successfully ";
            }
            return "No, someting went wrong";
        }

        public async Task<string> DeleteLearningCentreByIdAsync(int id)
        {
            LearningCentre? result = await _context.LearningCentres.FirstOrDefaultAsync(predicate: x => x.Id == id);
            if (result is not null)
            {
                _context.LearningCentres.Remove(entity: result!);
                _context.SaveChanges();
                return "Deleted successfully";
            }
            return "No, someting went wrong";
        }

    }
}

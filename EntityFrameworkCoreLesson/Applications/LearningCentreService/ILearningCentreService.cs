using EntityFrameworkCoreLesson.Models;

namespace EntityFrameworkCoreLesson.Applications.LearningCentreService
{
    public interface ILearningCentreService
    {

        public Task<string> CreateLearningCentreAsync(LearningCentre learningcentre);
        public Task<List<LearningCentre>> GetAllLearningCentreAsync();
        public Task<LearningCentre> GetLearningCentreByIdAsync(int id);
        public Task<string> UpdateLearningCentreAsync(int id, LearningCentre centre);
        public Task<string> DeleteLearningCentreByIdAsync(int id);

    }
}

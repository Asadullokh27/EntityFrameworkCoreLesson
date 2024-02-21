using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkCoreLesson.Models
{
    public class LearningCentre
    {
        public int Id { get; set; }

        public int StudentId { get; set; }

        [Phone]
        public string PhoneNumber { get; set; } = string.Empty;

        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        public string Teacher { get; set; } = string.Empty;
        
    }
}

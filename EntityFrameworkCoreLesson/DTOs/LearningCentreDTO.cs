using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkCoreLesson.DTOs
{
    public class LearningCentreDTO
    {

        public int StudentId { get; set; }
        public string Name { get; set; } = string.Empty;
        [RegularExpression(@"((\(\d{2}\) ?)|(\d{2}-))?\d{3}-\d{2}-\d{2}", ErrorMessage = "Invalid Phone Number!")]
        [Phone]
        public string PhoneNumber { get; set; } = string.Empty;
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        public string Teacher { get; set; } = string.Empty;

    }
}

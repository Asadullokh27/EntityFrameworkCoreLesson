namespace EntityFrameworkCoreLesson.DTOs
{
    public class StudentDTO
    {

        public string FullName { get; set; } = string.Empty;
        public string Field { get; set; } = string.Empty;
        public int Age { get; set; }
        public int GroupNumber { get; set; }

    }
}

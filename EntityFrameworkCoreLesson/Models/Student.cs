namespace EntityFrameworkCoreLesson.Models
{
    public class Student
    {

        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Field { get; set; } = string.Empty;
        public int GroupNumber { get; set; }

    }
}

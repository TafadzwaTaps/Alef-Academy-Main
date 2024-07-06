namespace Alef_Academy_Main.Models
{
    public class Instructors
    {
        public int InstructorId { get; set; }
        public string? InstructorsName { get; set; }

        public string? Bio { get; set; }

        public string? ContactEmail { get; set; }

        public Instructors()
        {
            
        }

        public Instructors(string _instructorsName, string _bio, string _contactEmail)
        {
            InstructorsName = _instructorsName;
            Bio = _bio;
            ContactEmail = _contactEmail;
        }

    }
}

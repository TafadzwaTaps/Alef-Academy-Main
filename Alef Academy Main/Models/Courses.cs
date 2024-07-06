namespace Alef_Academy_Main.Models
{
    public class Courses
    {
        public int CourseId { get; set; }
        public string? CourseName { get; set; }
        public string? Description { get; set; }
        public int InstructorId { get; set; }

        public int CategoryId { get; set; }

        public decimal Price { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public bool IsActive {  get; set; }

        public Courses()
        {
            
        }

        public Courses(string _courseName, string _description, int _instructiorID, int _categoryID, decimal _price, DateTime _startdate, DateTime _endDate, bool _isactive)
        {
            CourseName = _courseName;
            Description = _description;
            InstructorId = _instructiorID;
            CategoryId = _categoryID;
            Price = _price;
            StartDate = _startdate;
            EndDate = _endDate;
            IsActive = _isactive;
        }
    }
}

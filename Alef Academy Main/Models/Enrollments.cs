namespace Alef_Academy_Main.Models
{
    public class Enrollments
    {
        public int EnrollmentID {  get; set; }
        public int UserId { get; set; }

        public int CourseId { get; set; }

        public DateTime EnrollmentDate { get; set; }

        public bool IsCompleted {  get; set; }

        public DateTime CompletionDate { get; set; }

        public Enrollments()
        {
            
        }

        public Enrollments(int _userID, int _courseID, DateTime _enrollmentdate, bool _isCompleted, DateTime _completiondate)
        {
            UserId = _userID;
            CourseId = _courseID;
            EnrollmentDate = _enrollmentdate;
            IsCompleted = _isCompleted;
            CompletionDate = _completiondate;
        }
    }
}

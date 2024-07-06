using System.ComponentModel.DataAnnotations;

namespace Alef_Academy_Main.Models
{
    public class Reviews
    {
        [Required]
        public int ReviewId { get; set; }

        [Required]
        public int UserID { get; set; }

        [Required]
        public int CourseID { get; set; }

        [Required]
        [Range(0, 10, ErrorMessage = "Rating must be between 0 and 10.")]
        public int Rating { get; set; }
        [Required]
        public string? Comment { get; set; }
        public DateTime ReviewDate { get; set; }

        public Reviews()
        {
            Rating = 0;
        }
        public Reviews(int _userID, int _courseID,  int _rating, string _comment, DateTime _reviewDate)
        {
            UserID = _userID;
            CourseID = _courseID;
            Rating = _rating;
            Comment = _comment;
            ReviewDate = _reviewDate;
        }
    }
}

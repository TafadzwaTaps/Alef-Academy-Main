using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alef_Academy_Main.Models
{
    public class Internship
    {
        public int ApplicationId { get; set; }
        
        public string? Position { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]

        public string? CvFileName { get; set; } 
        
        public string? PortfolioLink { get; set; }

        public bool IsAwareOfUnpaid { get; set; }

        public bool IsAvailableASAP {  get; set; }

        public bool IsCommitToThreeMonths { get; set; }

        public bool IsAwareOfCommitment { get; set; }

        public DateTime ApplicationDate { get; set; } = DateTime.Now;

        [NotMapped] // This tells EF Core not to map this property to the database
        [Required(ErrorMessage = "Please select a file.")]
        [Display(Name = "File")]
        public IFormFile? CvFile { get; set; }

        public Internship()
        {
            
        }
        public Internship(string _position , string _name, string _email, string _cvfileName, string _portfolioLink, bool _isAwareOfUnpaid, bool _isAvailableAsap, bool _isCommitedToThreeMonths, bool _isAWareOfCommitment, DateTime _applicationDate)
        {
            Position = _position;
            Name = _name;
            Email = _email;
            CvFileName = _cvfileName;
            PortfolioLink = _portfolioLink;
            IsAwareOfUnpaid = _isAwareOfUnpaid;
            IsAvailableASAP = _isAvailableAsap;
            IsCommitToThreeMonths = _isCommitedToThreeMonths;
            IsAwareOfCommitment = _isAWareOfCommitment;
            ApplicationDate = _applicationDate;

        }
    }
}

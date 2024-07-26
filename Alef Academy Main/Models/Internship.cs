using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alef_Academy_Main.Models
{
    public class Internship
    {
        public int applicationid { get; set; }
        
        public string? position { get; set; }
        [Required]
        public string? name { get; set; }
        [Required]
        public string? email { get; set; }
        [Required]

        public string? cvfilename { get; set; } 
        
        public string? portfoliolink { get; set; }

        public bool isawareofunpaid { get; set; }

        public bool isavailableasap {  get; set; }

        public bool iscommittothreemonths { get; set; }

        public bool isawareofcommitment { get; set; }

        public DateTime applicationdate { get; set; } = DateTime.Now;

        [NotMapped] // This tells EF Core not to map this property to the database
        [Required(ErrorMessage = "Please select a file.")]
        [Display(Name = "File")]
        public IFormFile? CvFile { get; set; }

        public Internship()
        {
            
        }
        public Internship(string _position , string _name, string _email, string _cvfileName, string _portfolioLink, bool _isAwareOfUnpaid, bool _isAvailableAsap, bool _isCommitedToThreeMonths, bool _isAWareOfCommitment, DateTime _applicationDate)
        {
            position = _position;
            name = _name;
            email = _email;
            cvfilename = _cvfileName;
            portfoliolink = _portfolioLink;
            isawareofunpaid = _isAwareOfUnpaid;
            isavailableasap = _isAvailableAsap;
            iscommittothreemonths = _isCommitedToThreeMonths;
            isawareofcommitment = _isAWareOfCommitment;
            applicationdate = _applicationDate;

        }
    }
}

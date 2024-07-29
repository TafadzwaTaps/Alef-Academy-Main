using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alef_Academy_Main.Models
{
    public class Internships
    {
        [Key]
        public int applicationid { get; set; }

        [Required]
        [StringLength(100)]
        public string? position { get; set; }

        [Required]
        [StringLength(100)]
        public string? name { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string? email { get; set; }

        [StringLength(255)]
        public string? cvfilename { get; set; }

        [StringLength(255)]
        public string? portfoliolink { get; set; }

        [Required]
        public bool isawareofunpaid { get; set; }

        [Required]
        public bool isavailableasap { get; set; }

        [Required]
        public bool iscommittothreemonths { get; set; }

        [Required]
        public bool isawareofcommitment { get; set; }

        [Required]
        public DateTime applicationdate { get; set; } = DateTime.Now;

        [NotMapped]
        [Required(ErrorMessage = "Please select a file.")]
        [Display(Name = "File")]
        public IFormFile? CvFile { get; set; }

        public Internships() { }
    }
}

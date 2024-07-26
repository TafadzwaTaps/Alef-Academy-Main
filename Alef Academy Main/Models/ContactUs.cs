using System.ComponentModel.DataAnnotations;

namespace Alef_Academy_Main.Models
{
    public class ContactUs
    {
        public int inquiryid { get; set; }

        [Required]
        [StringLength(100)]
        public string name { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string email { get; set; } = string.Empty;

        [Required]
        public string message { get; set; } = string.Empty;

        public DateTime inquirydate { get; set; }

        public ContactUs()
        {
            // Set the default value for InquiryDate here if not using the database default
            inquirydate = DateTime.UtcNow; // Use UTC to match PostgreSQL timestamp with time zone
        }

        public ContactUs(string _name, string _email, string _message)
        {
            name = name;
            email = email;
            message = message;
            inquirydate = DateTime.UtcNow; // Set default value in constructor
        }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Alef_Academy_Main.Models
{
    public class ContactUs
    {
        public int InquiryId { get; set; }

        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Message { get; set; }
        
        public DateTime InquiryDate { get; set; } = DateTime.Now;

        public ContactUs()
        {
            
        }

        public ContactUs(string _name, string _email, string _message)
        {
            Name = _name;
            Email = _email;
            Message = _message;
        }
    }
}

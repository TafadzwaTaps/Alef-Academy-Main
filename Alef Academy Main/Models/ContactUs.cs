namespace Alef_Academy_Main.Models
{
    public class ContactUs
    {
        public int InquiryId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }

        public string? Message { get; set; }

        public DateTime InquiryDate { get; set; }

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

namespace Alef_Academy_Main.Models
{
    public class Payments
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public int CourseId { get; set; }

        public decimal Amount { get; set; }

        public DateTime PaymentDate { get; set; }

        public string? PaymentStatus { get; set; }

        public Payments()
        {
            
        }

        public Payments(int _userID, int _courseID, decimal _amount, DateTime _paymentDate, string _paymentStatus)
        {
            UserId = _userID;
            CourseId = _courseID;
            Amount = _amount;
            PaymentDate = _paymentDate;
            PaymentStatus = _paymentStatus;
        }
    }
}

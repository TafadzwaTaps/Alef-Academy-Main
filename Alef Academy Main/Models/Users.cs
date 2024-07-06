namespace Alef_Academy_Main.Models
{
    public class Users
    {
        public int Id { get; set; }

        public string? UserName { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public DateTime RegistrationDate {get; set; }

        public Users()
        {

        }

        public Users(string _username, string _email, string _passwordhash, DateTime _registrationDate)
        {
            UserName = _username;
            Email = _email;
            Password = _passwordhash;
            RegistrationDate = _registrationDate;
        }
    }
}

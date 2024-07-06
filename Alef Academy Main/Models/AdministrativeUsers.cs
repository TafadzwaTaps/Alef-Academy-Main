namespace Alef_Academy_Main.Models
{
    public class AdministrativeUsers
    {
        public int AdminUserId;
        public string? AdminUserName { get; set; }
        public string? AdminPassword { get; set; } 
        public string? AdminEmail { get; set; }
        
        public AdministrativeUsers()
        { 
        
        }

        public AdministrativeUsers(string _adminUserName, string _adminPassword, string _adminEmail)
        {
            AdminUserName = _adminUserName;
            AdminPassword = _adminPassword;
            AdminEmail = _adminEmail;
        }
    }
}

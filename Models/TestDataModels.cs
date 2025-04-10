namespace TerracorTestFramework.Models
{
    public class LoginCredentials
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
    }

    public class TestDataModel
    {
        public string? Url { get; set; } 
        public required LoginCredentials LoginCredentials { get; set; }
    }
}
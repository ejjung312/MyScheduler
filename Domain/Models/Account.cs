namespace Domain.Models
{
    public class Account : DomainObject
    {
        public string UserId { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
    }
}

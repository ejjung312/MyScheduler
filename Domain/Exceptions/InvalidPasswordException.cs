namespace Domain.Exceptions
{
    public class InvalidPasswordException : Exception
    {
        public string UserId { get; set; }
        public string Password { get; set; }

        public InvalidPasswordException(string userId, string password)
        {
            UserId = userId;
            Password = password;
        }

        public InvalidPasswordException(string? message, string userId, string password) : base(message)
        {
            UserId = userId;
            Password = password;
        }

        public InvalidPasswordException(string? message, Exception? innerException, string userId, string password) : base(message, innerException)
        {
            UserId = userId;
            Password = password;
        }
    }
}

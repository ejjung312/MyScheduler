namespace Domain.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public string UserId { get; set; }

        public UserNotFoundException(string userId)
        {
            UserId = userId;
        }

        public UserNotFoundException(string? message, string userId) : base(message)
        {
            UserId = userId;
        }

        public UserNotFoundException(string? message, Exception? innerException, string userId) : base(message, innerException)
        {
            UserId = userId;
        }
    }
}

using Domain.Exceptions;
using Domain.Models;
using Microsoft.AspNet.Identity;

namespace Domain.Services.AuthenticationServices
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAccountService _accountService;
        private readonly IPasswordHasher _passwordHasher;

        public AuthenticationService(IAccountService accountService, IPasswordHasher passwordHasher)
        {
            _accountService = accountService;
            _passwordHasher = passwordHasher;
        }

        public async Task<Account> Login(string userId, string password)
        {
            Account storedUser = await _accountService.GetByUserId(userId);

            if (storedUser == null)
            {
                throw new UserNotFoundException(userId);
            }

            PasswordVerificationResult passwordResult = _passwordHasher.VerifyHashedPassword(storedUser.PasswordHash, password);

            if (passwordResult != PasswordVerificationResult.Success)
            {
                throw new InvalidPasswordException(userId, password);
            }

            return storedUser;
        }

        public async Task<RegistrationResult> Register(string userId, string userName, string password, string confirmPassword)
        {
            RegistrationResult result = RegistrationResult.Success;

            if (password != confirmPassword)
            {
                result = RegistrationResult.PasswordDoNotMatch;
            }

            Account userAccount = await _accountService.GetByUserId(userId);
            if (userAccount != null)
            {
                result = RegistrationResult.UserAlreadyExists;
            }

            if (result == RegistrationResult.Success)
            {
                string hashedPassword = _passwordHasher.HashPassword(password);

                Account account = new Account()
                {
                    UserId = userId,
                    Username = userName,
                    PasswordHash = hashedPassword,
                    CreateDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                };

                await _accountService.Create(account);
            }

            return result;
        }
    }
}

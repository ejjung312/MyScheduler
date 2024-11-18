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

            //PasswordVerificationResult passwordResult = _passwordHasher.VerifyHashedPassword(storedUser.PasswordHash, password);

            //if (passwordResult != PasswordVerificationResult.Success)
            //{
            //    // TODO - 처리
            //    throw new Exception();
            //}

            return storedUser;
        }
    }
}

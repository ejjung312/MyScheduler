using Domain.Models;
using Domain.Services;
using EntityFramework.Services.Common;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework.Services
{
    public class AccountDataService : IAccountService
    {
        private readonly ForSuccessDbContextFactory _contextFactory;
        private readonly NonQueryDataService<Account> _nonQueryDataService;

        public AccountDataService(ForSuccessDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
            _nonQueryDataService = new NonQueryDataService<Account>(contextFactory);
        }

        public async Task<Account> Create(Account entity)
        {
            return await _nonQueryDataService.Create(entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await _nonQueryDataService.Delete(id);
        }

        public async Task<Account> Get(int id)
        {
            using (ForSuccessDbContext context = _contextFactory.CreateDbContext())
            {
                Account entity = await context.Users.FirstOrDefaultAsync((e) => e.Id == id);
                return entity;
            }
        }

        public async Task<IEnumerable<Account>> GetAll()
        {
            using (ForSuccessDbContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<Account> entities = await context.Users
                    .Include(a => a.UserId).ToListAsync();

                return entities;
            }
        }

        public async Task<Account> GetByUserId(string userid)
        {
            using (ForSuccessDbContext context = _contextFactory.CreateDbContext())
            {
                return await context.Users.FirstOrDefaultAsync(a => a.UserId == userid);
            }
        }

        public async Task<Account> Update(int id, Account entity)
        {
            return await _nonQueryDataService.Update(id, entity);
        }
    }
}

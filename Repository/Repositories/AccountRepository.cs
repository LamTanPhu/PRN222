using Microsoft.EntityFrameworkCore;
using ModelViews.Entity;
using Repository.Context;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ApplicationDbContext _context;

        public AccountRepository(ApplicationDbContext context) => _context = context;
        public async Task<Account> GetAccountByEmail(string email) =>
            await _context.Accounts.FirstOrDefaultAsync(a => a.Email.Equals(email));
    }
}

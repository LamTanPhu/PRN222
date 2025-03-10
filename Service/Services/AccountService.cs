using ModelViews.Entity;
using Repository.Interfaces;
using Repository.Repositories;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public async Task<bool> Login(string username, string password)
        {
            Account account = await _accountRepository.GetAccountByEmail(username);
            if (account is null)
                return false;
            if (account.Password != password) 
                return false;
            return true;
        }
    }
}

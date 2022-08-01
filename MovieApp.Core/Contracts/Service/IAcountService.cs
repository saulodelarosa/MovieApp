using MovieApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Core.Contracts.Service
{
    public interface IAcountService
    {

        Task<int> InsertAccount(AccountModel AccountModel);
        Task<IEnumerable<AccountModel>> GetAllAccounts();
        Task<int> DeleteAccountAsync(int id);
        Task<int> UpdateAccountAsync(AccountModel model);
        Task<AccountModel> GetAccountByIdAsync(int id);

    }
}

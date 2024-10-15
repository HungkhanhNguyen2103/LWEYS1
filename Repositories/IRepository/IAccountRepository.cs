using BusinessObject;
using BusinessObject.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repository
{
    public interface IAccountRepository
    {
        Task<ReponderModel<string>> Register(AccountModel account);
        Task<ReponderModel<string>> Login(AccountModel account);
        Task<ReponderModel<Account>> GetAll();

    }
}

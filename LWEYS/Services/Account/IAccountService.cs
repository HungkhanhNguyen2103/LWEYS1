using BusinessObject.BaseModel;

namespace LWEYS.Services.Account
{
    public interface IAccountService
    {
        Task<ReponderModel<string>> Register(AccountModel model);
        Task<ReponderModel<string>> Login(AccountModel model);
        Task<ReponderModel<BusinessObject.Account>> GetAll();
    }
}

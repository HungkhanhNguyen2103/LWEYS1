using BusinessObject.BaseModel;

namespace LWEYS.Services.Account
{
    public interface IAccountService
    {
        Task<ReponderModel<string>> Register(AccountModel model);
        Task<ReponderModel<string>> Login(AccountModel model);
        Task<ReponderModel<BusinessObject.Account>> GetAll();
        Task<ReponderModel<string>> ConfirmEmail(string token);
        Task<ReponderModel<AccountModel>> GetInformation(string username);
        Task<ReponderModel<string>> UpdateInformation(AccountModel account);
    }
}

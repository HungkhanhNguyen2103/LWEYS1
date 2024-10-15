using BusinessObject.BaseModel;

namespace LWEYS.Services.AboutUs
{
    public interface IAboutUsService
    {
        Task<ReponderModel<string>> Update(BusinessObject.AboutUs aboutUs);
        Task<ReponderModel<BusinessObject.AboutUs>> Get();
    }
}

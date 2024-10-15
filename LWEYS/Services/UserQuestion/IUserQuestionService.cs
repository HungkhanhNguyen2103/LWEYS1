using BusinessObject.BaseModel;

namespace LWEYS.Services.UserQuestion
{
    public interface IUserQuestionService
    {
        Task<ReponderModel<string>> SendQuestion(BusinessObject.UserQuestion userQuestion);
        Task<ReponderModel<BusinessObject.UserQuestion>> Get();
    }
}

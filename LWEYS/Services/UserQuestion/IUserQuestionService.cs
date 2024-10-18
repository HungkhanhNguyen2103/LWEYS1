using BusinessObject.BaseModel;

namespace LWEYS.Services.UserQuestion
{
    public interface IUserQuestionService
    {
        Task<ReponderModel<string>> SendQuestion(BusinessObject.UserQuestion userQuestion);
        Task<ReponderModel<BusinessObject.UserQuestion>> Get();
        Task<ReponderModel<BusinessObject.UserQuestion>> GetByUserName(string username);
        Task<ReponderModel<string>> FeedbackUserQuestion(BusinessObject.UserQuestion question);
    }
}

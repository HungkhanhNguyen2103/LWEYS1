using BusinessObject;
using BusinessObject.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.IRepository
{
    public interface IUserQuestionRepository
    {
        Task<ReponderModel<string>> SendQuestion(UserQuestion question);
        Task<ReponderModel<UserQuestion>> Get();
    }
}

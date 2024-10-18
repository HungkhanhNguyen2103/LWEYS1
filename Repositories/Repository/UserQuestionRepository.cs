using BusinessObject;
using BusinessObject.BaseModel;
using Microsoft.EntityFrameworkCore;
using Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repository
{
    public class UserQuestionRepository : IUserQuestionRepository
    {
        private readonly LWEYSDbContext LWEYSDbContext;
        public UserQuestionRepository(LWEYSDbContext lWEYSDbContext)
        {
            LWEYSDbContext = lWEYSDbContext;
        }

        public async Task<ReponderModel<string>> FeedbackUserQuestion(UserQuestion question)
        {
            var response = new ReponderModel<string>();
            if (question == null)
            {
                response.Message = "Dữ liệu không hợp lệ";
                return response;
            }
            try
            {
                var userQuestion = await LWEYSDbContext.UserQuestions.FirstOrDefaultAsync(c => c.Id == question.Id);
                if (userQuestion == null)
                {
                    response.Message = "Dữ liệu không tồn tại";
                    return response;
                }
                userQuestion.AdminMessage = question.AdminMessage;
                userQuestion.AdminUserName = question.AdminUserName;
                await LWEYSDbContext.SaveChangesAsync();
                response.IsSussess = true;
                response.Message = "Đã phản hồi";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ReponderModel<UserQuestion>> Get()
        {
            var reponse = new ReponderModel<UserQuestion>();
            var result = await LWEYSDbContext.UserQuestions.ToListAsync();
            reponse.DataList = result;
            return reponse;
        }

        public async Task<ReponderModel<UserQuestion>> GetByUserName(string username)
        {
            var reponse = new ReponderModel<UserQuestion>();
            var result = await LWEYSDbContext.UserQuestions.Where(c => c.UserName == username).ToListAsync();
            reponse.DataList = result;
            return reponse;
        }

        public async Task<ReponderModel<string>> SendQuestion(UserQuestion question)
        {
            var response = new ReponderModel<string>();
            if (question == null)
            {
                response.Message = "Dữ liệu không hợp lệ";
                return response;
            }
            try
            {
                await LWEYSDbContext.UserQuestions.AddAsync(question);
                await LWEYSDbContext.SaveChangesAsync();
                response.IsSussess = true;
                response.Message = "Câu hỏi đã được gửi đi";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
                
        }
    }
}

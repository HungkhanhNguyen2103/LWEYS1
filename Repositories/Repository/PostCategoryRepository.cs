using Azure;
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
    public class PostCategoryRepository : IPostCategoryRepository
    {
        private readonly LWEYSDbContext LWEYSDbContext;
        public PostCategoryRepository(LWEYSDbContext lWEYSDbContext)
        {
            LWEYSDbContext = lWEYSDbContext;
        }

        public async Task<ReponderModel<string>> DeletePostCategory(int id)
        {
            var response = new ReponderModel<string>();
            var result = await LWEYSDbContext.PostCategories.FirstOrDefaultAsync(c => c.Id == id);
            if(result == null)
            {
                response.Message = "Dữ liệu không hợp lệ";
                return response;
            }
            LWEYSDbContext.PostCategories.Remove(result);
            await LWEYSDbContext.SaveChangesAsync();
            response.IsSussess = true;
            response.Message = "Xóa thành công";
            return response;
        }

        public async Task<ReponderModel<PostCategory>> GetPostCategories()
        {
            var response = new ReponderModel<PostCategory>();
            response.DataList = await LWEYSDbContext.PostCategories.ToListAsync();
            response.IsSussess = true;
            return response;
        }

        public async Task<ReponderModel<string>> UpdatePostCategory(PostCategory postCategory)
        {
            var reponse = new ReponderModel<string>();
            if (postCategory == null)
            {
                reponse.Message = "Dữ liệu không hợp lệ";
                return reponse;
            }
            if(postCategory.Id == 0)
            {
                await LWEYSDbContext.PostCategories.AddAsync(postCategory);
            }
            else
            {
                var postCate = await LWEYSDbContext.PostCategories.FirstOrDefaultAsync(c => c.Id == postCategory.Id);
                if (postCate == null)
                {
                    reponse.Message = "Data không hợp lệ";
                    return reponse;
                }
                postCate.Name = postCategory.Name;
                postCate.Description = postCategory.Description;
            }
            await LWEYSDbContext.SaveChangesAsync();
            reponse.IsSussess = true;
            reponse.Message = "Cập nhật thành công";
            return reponse;
        }
    }
}

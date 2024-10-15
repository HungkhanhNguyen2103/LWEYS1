using Azure;
using BusinessObject;
using BusinessObject.BaseModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repository
{
    public class PostRepository : IPostRepository
    {
        private readonly LWEYSDbContext LWEYSDbContext;
        private readonly IConfiguration _configuration;
        public PostRepository(LWEYSDbContext lWEYSDbContext,IConfiguration configuration)
        {
            LWEYSDbContext = lWEYSDbContext;
            _configuration = configuration;
        }

        public async Task<ReponderModel<string>> DeletePost(int id)
        {
            var response = new ReponderModel<string>();
            var result = await LWEYSDbContext.Posts.FirstOrDefaultAsync(c => c.Id == id);
            if (result == null)
            {
                response.Message = "Dữ liệu không hợp lệ";
                return response;
            }
            LWEYSDbContext.Posts.Remove(result);
            await LWEYSDbContext.SaveChangesAsync();
            response.IsSussess = true;
            response.Message = "Xóa thành công";
            return response;
        }

        public async Task<ReponderModel<PostModel>> Get()
        {
            var response = new ReponderModel<PostModel>();
            var result = await LWEYSDbContext.Posts.Include(c => c.PostCategory).Select(c => new PostModel
            {
                Id = c.Id,
                PostDescription = c.PostDescription,
                CreateDate = c.CreateDate.ToString("dd-MM-yyyy"),
                Image = c.Image,
                Title = c.Title,
                PostCategoryId = c.PostCategoryId,
                PostCategory = c.PostCategory != null ? c.PostCategory.Name : string.Empty
            }).ToListAsync();
            response.IsSussess = true;
            response.DataList = result;
            return response;
        }

        public async Task<ReponderModel<Post>> Get(int id)
        {
            var reponse = new ReponderModel<Post>();
            var result = await LWEYSDbContext.Posts.FirstOrDefaultAsync(c => c.Id == id);
            reponse.Data = result;
            return reponse;
        }

        public async Task<ReponderModel<string>> UpdatePost(Post post)
        {
            var originPath = _configuration["API:Url"];
            var path = Environment.CurrentDirectory;
            path = Path.Combine(path,"wwwroot" ,"Resource", "Images");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            var reponse = new ReponderModel<string>();
            var fileName = string.Empty;
            if (post == null)
            {
                reponse.Message = "Dữ liệu không hợp lệ";
                return reponse;
            }
            try
            {
                if (!string.IsNullOrEmpty(post.Image) && !post.Image.Contains(originPath))
                {
                    fileName = Path.GetFileName("Post-" + Guid.NewGuid().ToString() + "-Cate-" + post.PostCategoryId + ".png");
                    var urlPath = Path.Combine(path, fileName);
                    post.Image = post.Image.Split(";base64,")[1];
                    byte[] imageBytes = Convert.FromBase64String(post.Image);
                    File.WriteAllBytes(urlPath, imageBytes);
                    post.Image = Path.Combine(originPath, "Resource","Images", fileName); ;
                }
            }
            catch (Exception ex)
            {
                reponse.Message = ex.Message;
                return reponse;
            }
            post.CreateDate = DateTime.Now;
            if (post.Id == 0)
            {
                await LWEYSDbContext.Posts.AddAsync(post); 
            }
            else
            {
                var postDb = await LWEYSDbContext.Posts.FirstOrDefaultAsync(c => c.Id == post.Id);
                if (postDb == null)
                {
                    reponse.Message = "Data không hợp lệ";
                    return reponse;
                }
                postDb.PostCategoryId = post.PostCategoryId;
                postDb.PostDescription = post.PostDescription;
                postDb.CreateDate = post.CreateDate;
                postDb.Title = post.Title;
                postDb.Image = post.Image;
            }
            await LWEYSDbContext.SaveChangesAsync();

            reponse.IsSussess = true;
            reponse.Message = "Cập nhật thành công";
            return reponse;
        }
    }
}

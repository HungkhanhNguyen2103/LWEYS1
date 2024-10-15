using BusinessObject;
using BusinessObject.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.IRepository
{
    public interface IPostCategoryRepository
    {
        Task<ReponderModel<PostCategory>> GetPostCategories();

        Task<ReponderModel<string>> UpdatePostCategory(PostCategory postCategory);
        Task<ReponderModel<string>> DeletePostCategory(int id);
    }
}

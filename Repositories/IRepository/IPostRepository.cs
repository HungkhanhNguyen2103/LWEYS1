using BusinessObject;
using BusinessObject.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.IRepository
{
    public interface IPostRepository
    {
        Task<ReponderModel<PostModel>> Get();

        Task<ReponderModel<Post>> Get(int id);

        Task<ReponderModel<string>> UpdatePost(Post post);
        Task<ReponderModel<string>> DeletePost(int id);
    }
}

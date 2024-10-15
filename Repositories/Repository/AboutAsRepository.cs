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
    public class AboutAsRepository : IAboutUsRepository
    {
        private readonly LWEYSDbContext LWEYSDbContext;
        public AboutAsRepository(LWEYSDbContext lWEYSDbContext) 
        {
            LWEYSDbContext = lWEYSDbContext;    
        }

        public async Task<ReponderModel<AboutUs>> Get()
        {
            var result = new ReponderModel<AboutUs>();
            var rs = await LWEYSDbContext.AboutUs.FirstOrDefaultAsync(c => c.Id == 1);
            if(rs == null) rs = new AboutUs { Id = 1};
            result.Data = rs;
            return result;
        }

        public async Task<ReponderModel<string>> Update(AboutUs us)
        {
            var result = new ReponderModel<string>();
            var rs = await LWEYSDbContext.AboutUs.FirstOrDefaultAsync(c => c.Id == us.Id);
            if(rs == null)
            {
                rs = new AboutUs
                {
                    Content = us.Content
                };
                await LWEYSDbContext.AboutUs.AddAsync(rs);
            }
            else
            {
                rs.Content = us.Content;
            }
            await LWEYSDbContext.SaveChangesAsync();
            result.IsSussess = true;
            result.Message = "Cập nhật thành công";
            return result;
        }
    }
}

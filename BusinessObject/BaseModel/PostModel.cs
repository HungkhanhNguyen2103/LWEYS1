using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.BaseModel
{
    public class PostModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? PostDescription { get; set; }
        public string? Image { get; set; }
        public string? CreateDate { get; set; }
        public int PostCategoryId { get; set; }
        public string? PostCategory { get; set; }
    }
}

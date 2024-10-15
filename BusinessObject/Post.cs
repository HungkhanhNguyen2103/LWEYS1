using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class Post
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? PostDescription { get; set; }
        public string? Image { get; set; }
        public DateTime CreateDate { get; set; }
        public int PostCategoryId { get; set; }

        [ForeignKey("PostCategoryId")]
        public PostCategory? PostCategory { get; set; }
    }
}

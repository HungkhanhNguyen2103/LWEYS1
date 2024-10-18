using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject
{
    public class AboutUs
    {
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Content { get; set; }
    }
}

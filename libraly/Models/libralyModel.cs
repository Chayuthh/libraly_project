using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libraly.Models
{
    public class libralyModel
    {
        [Key]
        public int id { get; set; }
        [Column (TypeName = "nvarchar(100)")]
        public string title { get; set; }
        [Column (TypeName = "nvarchar(50)")]
        public string author { get; set; }
        [Column (TypeName = "nvarchar(100)")]
        public string isbn { get; set; }
        [Column (TypeName = "nvarchar(100)")]
        public string url { get; set; }
    }
}

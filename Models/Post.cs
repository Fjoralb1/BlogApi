using DevAlApplication.Enum;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DevAlApplication.Models
{
    public class Post
    {
        [Key]
        [JsonIgnore]
        public Guid ID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public StatusEnum Status { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime PublishDate { get; set; }
        public Guid CreatedBy { get; set; }
        public List<Category> Categories { get; set; }
    }
}

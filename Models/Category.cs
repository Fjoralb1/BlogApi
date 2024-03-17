using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DevAlApplication.Models
{
    public class Category
    {
        [Key]
        [JsonIgnore]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}

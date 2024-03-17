using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DevAlApplication.Models
{
    public class User
    {
        [Key]
        [JsonIgnore]
        public Guid UserID { get; set; }
        public string Name { get; set; }
        public string Surename { get; set; }
        public string Email { get; set; }
        public string Cellphone { get; set; }
    }
}

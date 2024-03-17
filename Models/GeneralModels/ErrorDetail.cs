using System.ComponentModel.DataAnnotations;

namespace DevAlApplication.Models.GeneralModels
{
    public class ErrorDetail
    {
        [Key]
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
    }
}

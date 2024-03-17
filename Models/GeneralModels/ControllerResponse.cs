namespace DevAlApplication.Models.GeneralModels
{
    public class ControllerResponse<T>
    {
        public bool Success { get; set; }

        public string ErrorMessage { get; set; }

        public Response<T> ResponseObject { get; set; }

        public ErrorDetail ErrorDetail { get; set; }

        public ControllerResponse(bool success = true, string errorMessage = null, Response<T> responseObject = null, ErrorDetail errorDetail = null)
        {
            Success = success;
            ErrorMessage = errorMessage;
            ResponseObject = responseObject;
            ErrorDetail = errorDetail;
        }

    }

    public class Response<T>
    {
        private T _value;

        public T Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }

        public static implicit operator T(Response<T> value)
        {
            return value.Value;
        }

        public static implicit operator Response<T>(T value)
        {
            return new Response<T> { Value = value };
        }
    }
}

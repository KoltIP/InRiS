using B.Middleware.Models;

namespace B.Middleware
{
    public static class ExceptionExtensions
    {
        public static ErrorResponse ToErrorResponse(this Exception data)
        {
            var res = new ErrorResponse()
            {
                ErrorCode = -1,
                Message = data.Message
            };

            return res;
        }
    }
}

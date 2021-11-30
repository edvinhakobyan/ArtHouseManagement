using Shared.Enums;

namespace Shared.IOModels
{
    public class ErrorModel
    {
        public ErrorModel() { }
        public ErrorModel(ErrorTypeEnum errorType, CustomErrorCodeEnum errorCode, string message)
        {
            ErrorType = errorType;
            ErrorCode = errorCode;
            Message = message;
        }

        public string Message { get; set; }
        public ErrorTypeEnum ErrorType { get; set; }
        public CustomErrorCodeEnum ErrorCode { get; set; }
    }
}

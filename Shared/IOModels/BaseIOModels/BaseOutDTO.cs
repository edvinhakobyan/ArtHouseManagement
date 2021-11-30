using System.Linq;
using Shared.Enums;
using System.Collections.Generic;

namespace Shared.IOModels.BaseIOModels
{
    public class BaseOutDTO
    {
        public List<ErrorModel> ErrorList { get; set; }

        public BaseOutDTO()
        {
            ErrorList = new List<ErrorModel>();
        }

        public virtual void AddError(ErrorModel error)
        {
            ErrorList.Add(error);
        }

        public virtual void AddError(ErrorTypeEnum errorType, CustomErrorCodeEnum errorCode, string message = null)
        {
            ErrorList.Add(new ErrorModel(errorType, errorCode, message));
        }

        public bool ContainsError(CustomErrorCodeEnum errorCodeEnum)
        {
            return ErrorList.Any(a => a.ErrorCode == errorCodeEnum);
        }
    }
}

using Shared.IOModels.BaseIOModels;
using Shared.IOModels.FilterDTOs;

namespace Shared.IOModels.DTOs.PaymentDTOs
{
    public class GetPaymentInDTO : BaseInDTO
    {
        public PaymentFilterDTO Filter { get; set; }
    }
}
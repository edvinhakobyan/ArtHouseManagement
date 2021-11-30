using Shared.IOModels.BaseIOModels;

namespace Shared.IOModels.DTOs.PaymentDTOs
{
    public class DeletePaymentInDTO : BaseInDTO
    {
        public int PaymentId { get; set; }
    }
}
using Shared.IOModels.BaseIOModels;

namespace Shared.IOModels.DTOs.PaymentDTOs
{
    public class CreatePaymentOutDTO : BaseOutDTO
    {
        public PaymentDTO Patment { get; set; }
    }
}
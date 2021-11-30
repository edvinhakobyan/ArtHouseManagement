using Shared.IOModels.BaseIOModels;
using System.Collections.Generic;

namespace Shared.IOModels.DTOs.PaymentDTOs
{
    public class GetPaymentOutDTO : BaseOutDTO
    {
        public List<PaymentDTO> Payments { get; set; }
    }
}
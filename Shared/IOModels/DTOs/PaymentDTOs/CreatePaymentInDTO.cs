using Shared.IOModels.BaseIOModels;
using System;

namespace Shared.IOModels.DTOs.PaymentDTOs
{
    public class CreatePaymentInDTO : BaseInDTO
    {
        public int StudentId { get; set; }
        public int GroupId { get; set; }
        public string Name { get; set; }
        public float Value { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
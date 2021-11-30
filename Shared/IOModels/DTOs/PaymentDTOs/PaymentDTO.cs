using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.IOModels.DTOs.PaymentDTOs
{
    public class PaymentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Value { get; set; }
        public int StudentGroupId { get; set; }
    }
}

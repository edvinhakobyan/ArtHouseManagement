using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces.IBLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.IOModels.DTOs.PaymentDTOs;

namespace ArtHoseWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentBL _paymentBL;
        public PaymentController(IPaymentBL paymentBL)
        {
            _paymentBL = paymentBL;
        }

        [HttpPost("CreatePayment")]
        public  Task<CreatePaymentOutDTO> CreatePaymentAsync(CreatePaymentInDTO inModel)
        {
            return _paymentBL.CreatePaymentAsync(inModel);
        }

        [HttpPost("DeletePayment")]
        public Task<DeletePaymentOutDTO> DeletePaymentAsync(DeletePaymentInDTO inModel)
        {
            return _paymentBL.DeletePaymentAsync(inModel);
        }

        [HttpPost("GetPayments")]
        public Task<GetPaymentOutDTO> GetPaymentsAsync(GetPaymentInDTO InModel)
        {
            return _paymentBL.GetPaymentsAsync(InModel);
        }

        [HttpPost("UpdatePayment")]
        public Task<UpdatePaymentOutDTO> UpdatePaymentAsync(UpdatePaymentInDTO inModel)
        {
            return _paymentBL.UpdatePaymentAsync(inModel);
        }
    }
}

using Shared.IOModels.DTOs.PaymentDTOs;
using System.Threading.Tasks;

namespace Core.Interfaces.IBLL
{
    public interface IPaymentBL
    {
        Task<CreatePaymentOutDTO> CreatePaymentAsync(CreatePaymentInDTO inModel);
        Task<DeletePaymentOutDTO> DeletePaymentAsync(DeletePaymentInDTO inModel);
        Task<UpdatePaymentOutDTO> UpdatePaymentAsync(UpdatePaymentInDTO inModel);
        Task<GetPaymentOutDTO> GetPaymentsAsync(GetPaymentInDTO InModel);

    }
}

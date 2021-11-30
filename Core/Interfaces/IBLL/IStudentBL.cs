using System.Threading.Tasks;
using Shared.IOModels.DTOs.StudentDTOs;

namespace Core.Interfaces.IBLL
{
    public interface IStudentBL
    {
        Task<CreateStudentOutDTO> CreateStudentAsync(CreateStudentInDTO inModel);
        Task<DeleteStudentOutDTO> DeleteStudentAsync(DeleteStudentInDTO inModel);
        Task<UpdateStudentOutDTO> UpdateStudentAsync(UpdateStudentInDTO inModel);
        Task<GetStudentOutDTO> GetStudentsAsync(GetStudentInDTO InModel);
    }
}

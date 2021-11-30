using System.Threading.Tasks;
using Shared.IOModels.DTOs.TeacherDTOs;

namespace Core.Interfaces.IBLL
{
    public interface ITeacherBL
    {
        Task<CreateTeacherOutDTO> CreateTeacherAsync(CreateTeacherInDTO inModel);
        Task<DeleteTeacherOutDTO> DeleteTeacherAsync(DeleteTeacherInDTO inModel);
        Task<UpdateTeacherOutDTO> UpdateTeacherAsync(UpdateTeacherInDTO inModel);
        Task<GetTeacherOutDTO> GetTeachersAsync(GetTeacherInDTO InModel);
    }
}

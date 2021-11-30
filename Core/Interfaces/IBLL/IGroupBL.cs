using System.Threading.Tasks;
using Shared.IOModels.DTOs.GroupDTOs;
using Shared.IOModels.DTOs.StudentGroupDTOs;

namespace Core.Interfaces.IBLL
{
    public interface IGroupBL 
    {
        Task<CreateGroupOutDTO> CreateGroupAsync(CreateGroupInDTO inModel);
        Task<DeleteGroupOutDTO> DeleteGroupAsync(DeleteGroupInDTO inModel);
        Task<UpdateGroupOutDTO> UpdateGroupAsync(UpdateGroupInDTO inModel);
        Task<GetGroupOutDTO> GetGroupsAsync(GetGroupInDTO InModel);
        Task<AddStudentInGroupOutDTO> AddStudentInGroupAsync(AddStudentInGroupInDTO InModel);
    }
}

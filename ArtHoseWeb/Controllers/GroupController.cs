using Core.Interfaces.IBLL;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shared.IOModels.DTOs.GroupDTOs;
using Shared.IOModels.DTOs.StudentGroupDTOs;

namespace ArtHoseWeb.Controllers
{
    [Route("api/Group")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IGroupBL _groupBL;
        public GroupController(IGroupBL groupBL)
        {
            _groupBL = groupBL;
        }

        [HttpPost("CreateGroup")]
        public Task<CreateGroupOutDTO> CreateGroupAsync(CreateGroupInDTO inModel)
        {
            return _groupBL.CreateGroupAsync(inModel);
        }

        [HttpPost("DeleteGroup")]
        public Task<DeleteGroupOutDTO> DeleteGroupAsync(DeleteGroupInDTO inModel)
        {
            return _groupBL.DeleteGroupAsync(inModel);
        }

        [HttpPost("GetGroups")]
        public Task<GetGroupOutDTO> GetGroupsAsync(GetGroupInDTO InModel)
        {
            return _groupBL.GetGroupsAsync(InModel);
        }

        [HttpPost("UpdateGroup")]
        public Task<UpdateGroupOutDTO> UpdateGroupAsync(UpdateGroupInDTO inModel)
        {
            return _groupBL.UpdateGroupAsync(inModel);
        }

        [HttpPost("AddStudentInGroup")]
        public Task<AddStudentInGroupOutDTO> AddStudentInGroupAsync(AddStudentInGroupInDTO InModel)
        {
            return _groupBL.AddStudentInGroupAsync(InModel);
        }


        }
}

using Core.Interfaces.IBLL;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shared.IOModels.DTOs.TeacherDTOs;

namespace ArtHoseWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherBL _teacherBL;

        public TeacherController(ITeacherBL teacherBL)
        {
            _teacherBL = teacherBL;
        }

        [HttpPost("CreateTeacher")]
        public Task<CreateTeacherOutDTO> CreateTeacherAsync(CreateTeacherInDTO inModel)
        {
            return _teacherBL.CreateTeacherAsync(inModel);
        }

        [HttpPost("DeleteTeacher")]
        public Task<DeleteTeacherOutDTO> DeleteTeacherAsync(DeleteTeacherInDTO inModel)
        {
            return _teacherBL.DeleteTeacherAsync(inModel);
        }

        [HttpPost("GetTeachers")]
        public Task<GetTeacherOutDTO> GetTeachersAsync(GetTeacherInDTO InModel)
        {
            return _teacherBL.GetTeachersAsync(InModel);
        }

        [HttpPost("UpdateTeacher")]
        public Task<UpdateTeacherOutDTO> UpdateTeacherAsync(UpdateTeacherInDTO inModel)
        {
            return _teacherBL.UpdateTeacherAsync(inModel);
        }
    }
}

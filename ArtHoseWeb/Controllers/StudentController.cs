using Core.Interfaces.IBLL;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shared.IOModels.DTOs.StudentDTOs;

namespace ArtHoseWeb.Controllers
{
    [Route("api/Student")]
    public class StudentController : Controller
    {
        IStudentBL _studentBL;

        public StudentController(IStudentBL studentBL)
        {
            _studentBL = studentBL;
        }

        [HttpPost("CreateStudent")]
        public Task<CreateStudentOutDTO> CreateStudentAsync([FromBody] CreateStudentInDTO inModel)
        {
            return _studentBL.CreateStudentAsync(inModel);
        }

        [HttpPost("DeleteStudent")]
        public Task<DeleteStudentOutDTO> DeleteStudentAsync([FromBody] DeleteStudentInDTO inModel)
        {
            return _studentBL.DeleteStudentAsync(inModel);
        }

        [HttpPost("GetStudents")]
        public Task<GetStudentOutDTO> GetStudentsAsync([FromBody] GetStudentInDTO InModel)
        {
            return _studentBL.GetStudentsAsync(InModel);
        }

        [HttpPost("UpdateStudent")]
        public Task<UpdateStudentOutDTO> UpdateStudentAsync([FromBody] UpdateStudentInDTO inModel)
        {
            return _studentBL.UpdateStudentAsync(inModel);
        }
    }
}

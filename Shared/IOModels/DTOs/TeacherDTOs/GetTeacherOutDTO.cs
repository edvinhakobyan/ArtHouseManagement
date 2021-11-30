using Shared.IOModels.BaseIOModels;
using System.Collections.Generic;

namespace Shared.IOModels.DTOs.TeacherDTOs
{
    public class GetTeacherOutDTO : BaseOutDTO
    {
        public IEnumerable<TeacherDTO> Teachers { get; set; }
    }
}
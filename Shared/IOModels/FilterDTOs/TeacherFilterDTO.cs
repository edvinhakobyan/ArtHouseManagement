using Shared.IOModels.BaseIOModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.IOModels.FilterDTOs
{
    public class TeacherFilterDTO : FilterBaseDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public int? GroupId { get; set; }
    }
}

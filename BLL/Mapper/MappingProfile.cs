using AutoMapper;
using Core.Models;
using Shared.IOModels.DTOs.ExpenseDTOs;
using Shared.IOModels.DTOs.GroupDTOs;
using Shared.IOModels.DTOs.PaymentDTOs;
using Shared.IOModels.DTOs.StudentDTOs;
using Shared.IOModels.DTOs.StudentGroupDTOs;
using Shared.IOModels.DTOs.TeacherDTOs;

namespace BLL.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Student, StudentDTO>();
            CreateMap<StudentDTO, Student>();

            CreateMap<Group, GroupDTO>();
            CreateMap<GroupDTO, Group>();

            CreateMap<Teacher, TeacherDTO>();
            CreateMap<TeacherDTO, Teacher>();

            CreateMap<ExpenseDTO, Expense>();
            CreateMap<Expense, ExpenseDTO>();

            CreateMap<Payment, PaymentDTO>();
            CreateMap<PaymentDTO, Payment>();

            CreateMap<StudentGroup, StudentGroupDTO>();
            CreateMap<StudentGroupDTO, StudentGroup>();

            CreateMap<CreateGroupInDTO, Group>();
            CreateMap<CreateStudentInDTO, Student>();
            CreateMap<CreateTeacherInDTO, Teacher>();
            CreateMap<CreatePaymentInDTO, Payment>();
            CreateMap<CreateExpenseInDTO, Expense>();
            CreateMap<AddStudentInGroupInDTO, StudentGroup>();


        }
    }
}

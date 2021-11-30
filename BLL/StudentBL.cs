using AutoMapper;
using BLL.Filters;
using Core.Models;
using System.Linq;
using Shared.Enums;
using Core.Interfaces.IBLL;
using System.Threading.Tasks;
using System.Collections.Generic;
using Core.Interfaces.IRepositories;
using GenericRepository.Abstarction;
using Shared.IOModels.DTOs.StudentDTOs;

namespace BLL
{
    public class StudentBL : IStudentBL
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStudentRepository _studentRepository;

        public StudentBL(IMapper mapper,
                         IUnitOfWork unitOfWork,
                         IStudentRepository studentRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _studentRepository = studentRepository;
        }

        public async Task<CreateStudentOutDTO> CreateStudentAsync(CreateStudentInDTO inModel)
        {
            var result = new CreateStudentOutDTO();

            var studentToAdd = _mapper.Map<Student>(inModel);

            _studentRepository.Add(studentToAdd);

            await _unitOfWork.SaveAsync();

            result.Student = _mapper.Map<StudentDTO>(studentToAdd);

            return result;
        }

        public async Task<DeleteStudentOutDTO> DeleteStudentAsync(DeleteStudentInDTO inModel)
        {
            DeleteStudentOutDTO result = new DeleteStudentOutDTO();

            var student = (await _studentRepository.FindAsync(t => t.Id == inModel.StudentId)).FirstOrDefault();

            if (student == null)
            {
                result.AddError(ErrorTypeEnum.Error, CustomErrorCodeEnum.StudentNotFound, $"Student with Id = {inModel.StudentId} not found");

                return result;
            }

            _studentRepository.Remove(student);

            await _unitOfWork.SaveAsync();

            return result;
        }

        public async Task<GetStudentOutDTO> GetStudentsAsync(GetStudentInDTO InModel)
        {
            var result = new GetStudentOutDTO();

            var students = await _studentRepository.FindAsync((StudentFilter)InModel.Filter);

            result.Students = _mapper.Map<List<Student>, List<StudentDTO>>(students);

            return result;
        }

        public async Task<UpdateStudentOutDTO> UpdateStudentAsync(UpdateStudentInDTO inModel)
        {
            var result = new UpdateStudentOutDTO();

            var studentToupdate = (await _studentRepository.FindAsync(s => s.Id == inModel.Student.Id)).FirstOrDefault();

            if(studentToupdate == null)
            {
                result.AddError(ErrorTypeEnum.Error, CustomErrorCodeEnum.StudentNotFound, $"Student with Id = {inModel.Student.Id} not found");

                return result;
            }

            studentToupdate = _mapper.Map<StudentDTO, Student>(inModel.Student);

            _studentRepository.Update(studentToupdate);

            await _unitOfWork.SaveAsync();

            result.Student = _mapper.Map<Student, StudentDTO>(studentToupdate);

            return result;
        }
    }
}

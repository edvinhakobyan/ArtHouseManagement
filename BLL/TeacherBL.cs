using AutoMapper;
using Core.Models;
using System.Linq;
using Shared.Enums;
using Core.Interfaces.IBLL;
using System.Threading.Tasks;
using Core.Interfaces.IRepositories;
using GenericRepository.Abstarction;
using BLL.Filters;
using System.Collections.Generic;
using Shared.IOModels.DTOs.TeacherDTOs;

namespace BLL
{
    public class TeacherBL : ITeacherBL
    {
        protected readonly IMapper _mapper;
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly ITeacherRepository _teacherRepository;


        public TeacherBL(IMapper mapper, 
                         IUnitOfWork unitOfWork, 
                         ITeacherRepository teacherRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _teacherRepository = teacherRepository;
        }

        public async Task<CreateTeacherOutDTO> CreateTeacherAsync(CreateTeacherInDTO inModel)
        {
            var result = new CreateTeacherOutDTO();

            var teacherToAdd = _mapper.Map<Teacher>(inModel);

            _teacherRepository.Add(teacherToAdd);

            await _unitOfWork.SaveAsync();

            result.Teacher = _mapper.Map<TeacherDTO>(teacherToAdd);

            return result;
        }

        public async Task<DeleteTeacherOutDTO> DeleteTeacherAsync(DeleteTeacherInDTO inModel)
        {
            var result = new DeleteTeacherOutDTO();

            var teacherToDelete = (await _teacherRepository.FindAsync(t => t.Id == inModel.TeacherId)).FirstOrDefault();

            if(teacherToDelete == null)
            {
                result.AddError(ErrorTypeEnum.Error, CustomErrorCodeEnum.TeacherNotFound, $"Teacher with Id = {inModel.TeacherId} not found");

                return result;
            }

            _teacherRepository.Remove(teacherToDelete);

            await _unitOfWork.SaveAsync();

            return result;
        }

        public async Task<GetTeacherOutDTO> GetTeachersAsync(GetTeacherInDTO InModel)
        {
            var result = new GetTeacherOutDTO();

            var teachers = await _teacherRepository.FindAsync((TeacherFilter)InModel.Filter);

            result.Teachers = _mapper.Map<List<Teacher>, List<TeacherDTO>>(teachers);

            return result;
        }

        public async Task<UpdateTeacherOutDTO> UpdateTeacherAsync(UpdateTeacherInDTO inModel)
        {
            var result = new UpdateTeacherOutDTO();

            var teacherToUpdate = (await _teacherRepository.FindAsync(t => t.Id == inModel.Teacher.Id)).FirstOrDefault();

            if(teacherToUpdate == null)
            {
                result.AddError(ErrorTypeEnum.Error, CustomErrorCodeEnum.TeacherNotFound, $"Teacher with Id = {inModel.Teacher.Id} not found");

                return result;
            }

            teacherToUpdate = _mapper.Map<Teacher>(inModel.Teacher);

            _teacherRepository.Update(teacherToUpdate);

            result.Teacher = _mapper.Map<TeacherDTO>(teacherToUpdate);

            return result;
        }
    }
}

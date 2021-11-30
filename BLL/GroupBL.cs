using AutoMapper;
using BLL.Filters;
using System.Linq;
using Core.Models;
using Shared.Enums;
using Core.Interfaces.IBLL;
using System.Threading.Tasks;
using System.Collections.Generic;
using Core.Interfaces.IRepositories;
using GenericRepository.Abstarction;
using Shared.IOModels.DTOs.GroupDTOs;
using Shared.IOModels.DTOs.StudentGroupDTOs;

namespace BLL
{
    public class GroupBL : IGroupBL
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IStudentGroupRepository _studentGroupRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GroupBL(IMapper mapper,
                       IUnitOfWork unitOfWork, 
                       IGroupRepository groupRepository,
                       IStudentRepository studentRepository,
                       IStudentGroupRepository studentGroupRepository)
        {
            _studentRepository = studentRepository;
            _groupRepository = groupRepository;
            _studentGroupRepository = studentGroupRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AddStudentInGroupOutDTO> AddStudentInGroupAsync(AddStudentInGroupInDTO InModel)
        {
            var result = new AddStudentInGroupOutDTO();

            var studentInGroupExist = await _studentGroupRepository.AnyAsync(sg => sg.StudentId == InModel.StudentId && sg.GroupId == InModel.GroupId);

            if (studentInGroupExist)
            {
                result.AddError(ErrorTypeEnum.Error, CustomErrorCodeEnum.StudentAlreadyInGroup, $"Student Already In Group");
                return result;
            }

            var studentExist = await _studentRepository.AnyAsync(s => s.Id == InModel.StudentId);

            if (!studentExist)
            {
                result.AddError(ErrorTypeEnum.Error, CustomErrorCodeEnum.StudentNotFound, $"Student with Id = {InModel.StudentId} not found");
                return result;
            }

            var groupexist = await _groupRepository.AnyAsync(g => g.Id == InModel.GroupId);

            if (!groupexist)
            {
                result.AddError(ErrorTypeEnum.Error, CustomErrorCodeEnum.GroupNotFound, $"Group with Id = {InModel.GroupId} not found");
                return result;
            }

            var studentGroup = _mapper.Map<StudentGroup>(InModel);

            _studentGroupRepository.Add(studentGroup);

            await _unitOfWork.SaveAsync();

            result.StudentGroup = _mapper.Map<StudentGroupDTO>(studentGroup);

            return result;
        }

        public async Task<CreateGroupOutDTO> CreateGroupAsync(CreateGroupInDTO inModel)
        {
            var result = new CreateGroupOutDTO();

            var group = _mapper.Map<Group>(inModel);

            _groupRepository.Add(group);

            await _unitOfWork.SaveAsync();

            result.Group = _mapper.Map<Group, GroupDTO>(group);

            return result;
        }

        public async Task<DeleteGroupOutDTO> DeleteGroupAsync(DeleteGroupInDTO inModel)
        {
            DeleteGroupOutDTO result = new DeleteGroupOutDTO();

            var groupToDelete = (await _groupRepository.FindAsync(t => t.Id == inModel.GroupId)).FirstOrDefault();

            if(groupToDelete == null)
            {
                result.AddError(ErrorTypeEnum.Error, CustomErrorCodeEnum.GroupNotFound, $"Group with Id = {inModel.GroupId} not found");

                return result;
            }

            _groupRepository.Remove(groupToDelete);

            await _unitOfWork.SaveAsync();

            return result;
        }

        public async Task<GetGroupOutDTO> GetGroupsAsync(GetGroupInDTO InModel)
        {
            var result = new GetGroupOutDTO();

            var groups = await _groupRepository.FindAsync((GroupFilter)InModel.Filter);

            result.Groups = _mapper.Map<List<GroupDTO>>(groups);

            return result;
        }

        public async Task<UpdateGroupOutDTO> UpdateGroupAsync(UpdateGroupInDTO inModel)
        {
            var result = new UpdateGroupOutDTO();

            var groupToUpdate = (await _groupRepository.FindAsync(g => g.Id == inModel.Group.Id)).FirstOrDefault();

            if(groupToUpdate == null)
            {
                result.AddError(ErrorTypeEnum.Error, CustomErrorCodeEnum.GroupNotFound, $"Group with Id = {inModel.Group.Id} not found");

                return result;
            }

            var group = _mapper.Map<Group>(inModel.Group);

            _groupRepository.Update(group);

            await _unitOfWork.SaveAsync();

            result.Group = _mapper.Map<GroupDTO>(group);

            return result;
        }
    }
}

using AutoMapper;
using BLL.Filters;
using Core.Interfaces.IBLL;
using Core.Interfaces.IRepositories;
using Core.Models;
using GenericRepository.Abstarction;
using Shared.Enums;
using Shared.IOModels.DTOs.PaymentDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL
{
    public class PaymentBL : IPaymentBL
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IStudentGroupRepository _studentGroupRepository;
        private readonly IPaymentRepository _paymentRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PaymentBL(IMapper mapper,
                         IUnitOfWork unitOfWork,
                         IGroupRepository groupRepository,
                         IStudentRepository studentRepository,
                         IPaymentRepository paymentRepository,
                         IStudentGroupRepository studentGroupRepository)
        {
            _studentRepository = studentRepository;
            _groupRepository = groupRepository;
            _studentGroupRepository = studentGroupRepository;
            _paymentRepository = paymentRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CreatePaymentOutDTO> CreatePaymentAsync(CreatePaymentInDTO inModel)
        {
            var result = new CreatePaymentOutDTO();

            var groupExists = await _groupRepository.AnyAsync(g => g.Id == inModel.GroupId);

            if(!groupExists)
            {
                result.AddError(ErrorTypeEnum.Error, CustomErrorCodeEnum.GroupNotFound, $"Group with Id = {inModel.GroupId} not found");
                return result;
            }

            var studentExists = await _studentRepository.AnyAsync(s => s.Id == inModel.StudentId);
            
            if(!studentExists)
            {
                result.AddError(ErrorTypeEnum.Error, CustomErrorCodeEnum.StudentNotFound, $"Student with Id = {inModel.StudentId} not found");
                return result;
            }

            var studentInGroup = (await _studentGroupRepository.FindAsync(sg => sg.GroupId == inModel.GroupId && sg.StudentId == inModel.StudentId)).FirstOrDefault();

            if(studentInGroup == null)
            {
                result.AddError(ErrorTypeEnum.Error,CustomErrorCodeEnum.NoSuchStudentInGroup, $"There is no such student in the group");
                return result;
            }

            var paymentToAdd = _mapper.Map<Payment>(inModel);

            paymentToAdd.StudentGroupId = studentInGroup.Id;

            _paymentRepository.Add(paymentToAdd);

            await _unitOfWork.SaveAsync();

            result.Patment = _mapper.Map<PaymentDTO>(paymentToAdd);

            return result;
        }

        public async Task<DeletePaymentOutDTO> DeletePaymentAsync(DeletePaymentInDTO inModel)
        {
            var result = new DeletePaymentOutDTO();

            var paymentToDelete = (await _paymentRepository.FindAsync(p => p.Id == inModel.PaymentId)).FirstOrDefault();

            if(paymentToDelete == null)
            {
                result.AddError(ErrorTypeEnum.Error,CustomErrorCodeEnum.PaymentNotFound, $"Payment with Id = {inModel.PaymentId} not found");
                return result;
            }

            _paymentRepository.Remove(paymentToDelete);

            await _unitOfWork.SaveAsync();

            return result;
        }

        public async Task<GetPaymentOutDTO> GetPaymentsAsync(GetPaymentInDTO InModel)
        {
            var result = new GetPaymentOutDTO();

            var payments = await _paymentRepository.FindAsync((PaymentFilter)InModel.Filter);

            result.Payments = _mapper.Map<List<Payment>, List<PaymentDTO>>(payments);

            return result;
        }

        public Task<UpdatePaymentOutDTO> UpdatePaymentAsync(UpdatePaymentInDTO inModel)
        {
            throw new NotImplementedException();
        }
    }
}

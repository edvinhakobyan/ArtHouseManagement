using AutoMapper;
using BLL.Filters;
using Core.Interfaces.IBLL;
using Core.Interfaces.IRepositories;
using Core.Models;
using GenericRepository.Abstarction;
using Shared.Enums;
using Shared.IOModels.DTOs.ExpenseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ExpenseBL : IExpenseBL
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IExpenseRepository _expenseRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IStudentGroupRepository _studentGroupRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ExpenseBL(IMapper mapper,
                         IUnitOfWork unitOfWork,
                         IExpenseRepository expenseRepository,
                         IStudentGroupRepository studentGroupRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _expenseRepository = expenseRepository;
            _studentGroupRepository = studentGroupRepository;
        }

        public async Task<CreateExpenseOutDTO> CreateExpenseAsync(CreateExpenseInDTO inModel)
        {
            var result = new CreateExpenseOutDTO();

            var stutentInGroup = (await _studentGroupRepository.FindAsync(sg => sg.GroupId == inModel.GroupId && sg.StudentId == inModel.StudentId)).FirstOrDefault();

            if (stutentInGroup == null) // TODO
            {
                result.AddError(ErrorTypeEnum.Error, CustomErrorCodeEnum.NoSuchStudentInGroup, "");

                return result;
            }

            var expenseToAdd = _mapper.Map<Expense>(inModel);
            expenseToAdd.StudentGroupId = stutentInGroup.Id;

            _expenseRepository.Add(expenseToAdd);

            await _unitOfWork.SaveAsync();

            result.Expense = _mapper.Map<ExpenseDTO>(expenseToAdd);

            return result;
        }

        public async Task<DeleteExpenseOutDTO> DeleteExpenseAsync(DeleteExpenseInDTO inModel)
        {
            var result = new DeleteExpenseOutDTO();

            var expenseToDelete = (await _expenseRepository.FindAsync(e => e.Id == inModel.ExpenseId)).FirstOrDefault();

            if(expenseToDelete == null)
            {
                result.AddError(ErrorTypeEnum.Error,CustomErrorCodeEnum.ExpenseNotFound, $"Expense with Id = {inModel.ExpenseId} not found");

                return result;
            }

            _expenseRepository.Remove(expenseToDelete);

            await _unitOfWork.SaveAsync();

            return result;
        }

        public async Task<GetExpenseOutDTO> GetExpensesAsync(GetExpenseInDTO inModel)
        {
            var result = new GetExpenseOutDTO();

            var expenses = await _expenseRepository.FindAsync((ExpenseFilter)inModel.Filter);

            result.Expenses = _mapper.Map<List<ExpenseDTO>>(expenses);

            return result;

        }

        public Task<UpdateExpenseOutDTO> UpdateExpenseAsync(UpdateExpenseInDTO inModel)
        {
            throw new NotImplementedException();
        }
    }
}

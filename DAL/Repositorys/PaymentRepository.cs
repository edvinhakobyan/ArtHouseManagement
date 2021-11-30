using Core.Models;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces.IRepositories;
using GenericRepository.Implementation;

namespace DAL.Repositorys
{
    public class PaymentRepository : BaseRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}

using Core.Models;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces.IRepositories;
using GenericRepository.Implementation;

namespace DAL.Repositorys
{
    public class GroupRepository : BaseRepository<Group>, IGroupRepository
    {
        public GroupRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}

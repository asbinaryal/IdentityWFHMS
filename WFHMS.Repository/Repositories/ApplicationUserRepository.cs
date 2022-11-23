using WFHMS.Data;
using WFHMS.Data.Entities;
using WFHMS.Repository.Infrastructure;

namespace WFHMS.Repository.Repositories
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        private readonly ApplicationDbContext dbContext;

        public ApplicationUserRepository(ApplicationDbContext dbContext ) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
        public IQueryable<ApplicationUser> GetAllUser(string id)
        {
        return (IQueryable<ApplicationUser>)dbContext.Users.Where(u =>u.departmentId.ToString() == id).ToList();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFHMS.Data.Entities;
using WFHMS.Repository.Infrastructure;

namespace WFHMS.Services.Services
{
    public class ApplicationUserServices : IApplicationUserServices
    {
        private readonly IUnitOfWork unitOfWork;

        public ApplicationUserServices(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IQueryable<ApplicationUser> GetAllByDeptId(string id)
        {
            return unitOfWork.applicationUser.GetAllUser(id);
        }
    }
}

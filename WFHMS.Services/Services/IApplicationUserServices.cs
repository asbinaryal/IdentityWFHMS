using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFHMS.Data.Entities;

namespace WFHMS.Services.Services
{
    public interface IApplicationUserServices
    {
        IQueryable<ApplicationUser> GetAllByDeptId(string id);
    }
}

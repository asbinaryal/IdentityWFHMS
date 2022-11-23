﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFHMS.Data.Entities;
using WFHMS.Repository.Infrastructure;

namespace WFHMS.Repository.Repositories
{
    public interface IDesignationRepository : IRepository<Designation>
    {
       Task< IEnumerable<Designation>> GetAllDesignation();
    }
}

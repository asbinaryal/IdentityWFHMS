﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFHMS.Data;
using WFHMS.Data.Entities;
using WFHMS.Repository.Repositories;

namespace WFHMS.Repository.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        private IEmployeeRepository _employeeRepository;
        private IRepository<Department> _departmentRepository;
        private IDesignationRepository _designationRepository;
        private IRepository<ApplyForWFH> _applyforwfhRepository;
        private IRepository<ApplicationUser> _applicationUser;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEmployeeRepository Employee => _employeeRepository ??= new EmployeeRepository(_dbContext);
        public IRepository<Department> Department => _departmentRepository ??= new Repository<Department>(_dbContext);
        public IDesignationRepository Designation => _designationRepository ??= new DesignationRepository(_dbContext);
        public IRepository<ApplyForWFH> ApplyForWFH => _applyforwfhRepository ??= new Repository<ApplyForWFH>(_dbContext);

        public IApplicationUserRepository applicationUser => (IApplicationUserRepository)(_applicationUser ??= new ApplicationUserRepository(_dbContext));

        public async Task<int> CompleteAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
        public void Dispose()
        { 
            _dbContext.Dispose();
        }
    }
}

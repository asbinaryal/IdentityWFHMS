using WFHMS.Data;
using WFHMS.Repository.Infrastructure;
using WFHMS.Repository.Repositories;
using WFHMS.Services.Services;

namespace WFHMS.Web
{
    public class Services
    {
        public static void RegisterServices(IServiceCollection services)
        {
            #region
            services.AddTransient<HttpClient, HttpClient>();
            services.AddTransient<IDepartmentServices, DepartmentServices>();
            services.AddTransient<IDesignationServices, DesignationServices>();
            services.AddTransient<IApplicationUserServices, ApplicationUserServices>();
            //services.AddTransient<IEmployeeService, EmployeeServices>();
            //services.AddTransient<IApplyForWFHServices, ApplyForWFHServices>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            #endregion
        }
    }
}

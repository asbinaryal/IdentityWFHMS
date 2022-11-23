using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WFHMS.Data;
using WFHMS.Data.Entities;
using WFHMS.Services.Services;

namespace WFHMS.Web.Controllers
{
    public class ManagerController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ApplicationDbContext dbContext;
        private readonly IApplicationUserServices userServices;
        private readonly IApplicationUserServices applicationUser;
        private readonly IHttpContextAccessor httpContextAccessor;

        public ManagerController(RoleManager<IdentityRole> roleManager,
            UserManager<ApplicationUser> userManager, ApplicationDbContext dbContext,IApplicationUserServices userServices,
            IHttpContextAccessor httpContextAccessor,IApplicationUserServices applicationUser)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.dbContext = dbContext;
            this.userServices = userServices;
            this.applicationUser = applicationUser;
            this.httpContextAccessor = httpContextAccessor;
        }


        [HttpGet]
        public IActionResult Member()
        {
            var Id = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);


            var user = applicationUser.GetAllByDeptId(Id);
          //  var memberList = userServices.GetAllByDeptId(deptId);
            //find for members matching  department

            return View();

        }
    }
}

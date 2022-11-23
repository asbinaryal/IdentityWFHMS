using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Differencing;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using WFHMS.Data.Entities;
using WFHMS.Models.ViewModel;
using WFHMS.Repository.Infrastructure;
using WFHMS.Services.Services;

namespace WFHMS.Web.Controllers
{
    public class DepartmentController : BaseController
    {
        private readonly ILogger<DepartmentController> _logger;
        private readonly HttpClient _httpClient;
        public readonly IConfiguration configure;
        public DepartmentController(ILogger<DepartmentController> logger, IConfiguration configure, HttpClient httpClient)
            : base(configure, httpClient)
        {
            _logger = logger;
            this.configure = configure;
            _httpClient = httpClient;
        }
        public async Task<IActionResult> Index()
        {
            var deptdis = await GetAsync<IEnumerable<DepartmentListViewModel>>(Helper.DepartmentGetAll);
            DepartmentListViewModel model = new DepartmentListViewModel();
            model.Department = deptdis;
            return View(model);
        }
        //public JsonResult IsDepartmentNameExist(string Name)
        //{
        //    string query = "select * from Department where DepartmentId = {0}"
        //    return Json();
        //}
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var model = await GetAsync<DepartmentListViewModel>(string.Format(Helper.DepartmentEdits, id));
                if (model != null)
                {
                    return View(model);
                    //Redirect ("Index");
                }
                // ViewBag.Message = "Not Found";
                return View("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Unable to do this Task..Please contat your admin");
                return View("Index");
            }
           
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            try
            {
                var Delt = GetAsync<DepartmentListViewModel>(String.Format(Helper.DepartmentDeletes, id)).Result;
                return View(Delt);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Unable to do this Task..Please contat your admin");
            }
            return View("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Create(DepartmentCreateViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var add = await PostAsync<DepartmentCreateViewModel>(model, Helper.DepartmentGetAll);
                    return RedirectToAction("Index");

                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Unable to save changes..Please contat your admin");
            }
            return View("Create");
        }
        [HttpPost]
        public async Task<IActionResult> Edit(DepartmentListViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var edit = await PutAsync<DepartmentListViewModel>(Helper.DepartmentEdits, model);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Unable to save changes..Please contat your admin");
            }
            return View("Edit");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Department model)
        {
            try
            {
                var del = await DeleteAsync<Department>(string.Format(Helper.DepartmentDeletes, model.Id));
                
                if (del != null)
                {
                    return RedirectToAction("Index");
                }
                //else  check for foreign key constraints
                //{
                //    ModelState.AddModelError("", "Unable to save changes because this department is linked up" +
                //        " with other models..Please contat your admin");
                //}
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Unable to save changes..Please contat your admin");
            }
            return View("Index");
        }
    }
}

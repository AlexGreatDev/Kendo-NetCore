using System;
using System.Threading.Tasks;
using AutoMapper;
using Business.Service.Interfaces;
using Core.Common.DTOs.Employee;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

using Microsoft.AspNetCore.Mvc;

using KendoCRUD.Models.Employee;

namespace KendoCRUD.Controllers
{
   
    public class EmployeeController : Controller
    {
        private readonly IMapper _mapper;

        private readonly IEmployeeService _employeeservice;

        public EmployeeController(IEmployeeService EmployeeEngine, IMapper mapper)
        {
            _employeeservice = EmployeeEngine ?? throw new ArgumentNullException(nameof(EmployeeEngine));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        #region CRUD
        public ActionResult Employee_Read([DataSourceRequest] DataSourceRequest request)
        {
            DataSourceResult result = _employeeservice.GetAllEmployee().ToDataSourceResult(request);
            return Json(result);
        }

        [HttpPost]
        public async Task<ActionResult> Employee_Create([DataSourceRequest] DataSourceRequest request, EmployeeViewModel model)
        {

            if (ModelState.IsValid && model != null)
            {


                if (await _employeeservice.EmployeeIsExists(model.EmployeeFirstName, model.EmployeeLastName))
                {
                    ModelState.AddModelError("EmployeeFirstName", "The Employee name must be unique!");
                    ModelState.AddModelError("EmployeeLastName", "The Employee name must be unique!");
                   
                }

                if (!await _employeeservice.AddEmployee(_mapper.Map<EmployeeViewModel, EmployeeDto>(model)))
                    ModelState.AddModelError("general", "Failed to save team! Please try again!");


            }
            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }
        
        [HttpPost]
        public async Task<ActionResult> Employee_Update([DataSourceRequest] DataSourceRequest request, EmployeeViewModel model)
        {
            if (ModelState.IsValid && model != null)
            {

                if (await _employeeservice.EmployeeIsExists(model.EmployeeID, model.EmployeeFirstName, model.EmployeeLastName))
                {
                    ModelState.AddModelError("EmployeeFirstName", "A Employee with that name already exists!");
                    ModelState.AddModelError("EmployeeLastName", "A Employee with that name already exists!");
                 
                }
                if (!await _employeeservice.UpdateEmployee(_mapper.Map<EmployeeViewModel, EmployeeDto>(model)))
                {
                    ModelState.AddModelError("general", "A Employee with that name already exists!");
                }
            }
            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }
        
        [HttpPost]
        public ActionResult Employee_Destroy([DataSourceRequest] DataSourceRequest request, EmployeeViewModel model)
        {
            
            if (_employeeservice.DeleteEmployeeById(model.EmployeeID))
            {
                ModelState.AddModelError("general", "Failed to delete Employee! Please try again!");
              
            }
          
            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        #endregion



        public IActionResult Index()
        {
            return View();
        }

   

       
       
    }
}

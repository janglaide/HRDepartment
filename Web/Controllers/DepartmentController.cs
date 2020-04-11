using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        IDepartmentService departmentService;
        IEmployeeService employeeService;
        public DepartmentController(IDepartmentService department, IEmployeeService employee)
        {
            departmentService = department;
            employeeService = employee;
        }
        public ActionResult Index()
        {
            IEnumerable<DepartmentDTO> departmentDTOs = departmentService.GetDepartments();
            var mapper = new MapperConfiguration(x => x.CreateMap<DepartmentDTO, DepartmentViewModel>()).CreateMapper();
            var departments = mapper.Map<IEnumerable<DepartmentDTO>, List<DepartmentViewModel>>(departmentDTOs);
            return View(departments);
        }
        public ActionResult DepartmentDescription(int id)
        {
            var departDTO = departmentService.GetDepartmentById(id);
            var mapper = new MapperConfiguration(x => x.CreateMap<DepartmentDTO, DepartmentViewModel>()).CreateMapper();
            var depart = mapper.Map<DepartmentDTO, DepartmentViewModel>(departDTO);
            return View(depart);
        }
        public ActionResult DepartmentEmployees(int id)
        {
            var departEmployeesDTO = employeeService.GetEmployeesByDepartmentId(id);
            var mapper = new MapperConfiguration(x => x.CreateMap<EmployeeDTO, EmployeeViewModel>()).CreateMapper();
            var departEmpl = mapper.Map<IEnumerable<EmployeeDTO>, List<EmployeeViewModel>> (departEmployeesDTO);
            return View(departEmpl);
        }
        protected override void Dispose(bool disposing)
        {
            departmentService.Dispose();
            base.Dispose(disposing);
        }
        [HttpGet]
        public ActionResult AddDepartment()
        {
            var dep = new DepartmentViewModel();
            return View(dep);
        }
        [HttpPost]
        public ActionResult AddDepartment(DepartmentViewModel model)
        {

            var counter = departmentService.GetDepartments().Last();
            var counterId = counter.DepartmentId + 1;


            DepartmentDTO newDep = new DepartmentDTO
            {
                DepartmentId = counterId,
                Name = model.Name,
                Description = model.Description
            };
            departmentService.AddDepartment(newDep);

            return RedirectToAction("Index", "Department");
        }
    }
}
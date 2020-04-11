using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class PositionController : Controller
    {
        private IPositionService positionService;
        private IEmployeeService employeeService;
        public PositionController(IPositionService position, IEmployeeService employee)
        {
            positionService = position;
            employeeService = employee;
        }
        // GET: Position
        public ActionResult Index()
        {
            var positions = positionService.GetPositions();

            var mapper = new MapperConfiguration(x => x.CreateMap<PositionDTO, PositionViewModel>()).CreateMapper();
            var positionsModel = mapper.Map<IEnumerable<PositionDTO>, List<PositionViewModel>>(positions);
            return View(positionsModel);
        }
        public ActionResult BestEmployee(int id)
        {
            var bestEmployee = employeeService.GetBestEmployee(id);
            var mapper = new MapperConfiguration(x => x.CreateMap<EmployeeDTO, EmployeeViewModel>()).CreateMapper();
            var positionsModel = mapper.Map<EmployeeDTO, EmployeeViewModel>(bestEmployee);
            return View(positionsModel);
        }
        public ActionResult Top5Positions()
        {

            return View();
        }
    }
}
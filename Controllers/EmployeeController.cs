﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SkillsMatrix.Models;
using SkillsMatrix.Services;
using SkillsMatrix.Services.Interfaces;

namespace SkillsMatrix.Controllers
{
    public class EmployeeController : Controller
    {
        private IEntityService<Employee, int> _employeeService {get; set;}

        public EmployeeController(IEntityService<Employee, int> employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Employee> employees = _employeeService.GetAll();
            return View(employees);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            Employee employee = _employeeService.GetById(id);
            ViewData["Mode"] = "Read";
            return View("Details", employee);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Employee employee = _employeeService.GetById(id);
            ViewData["Mode"] = "Edit";
            return View("Details", employee);
        }
    }
}


using BussinessModel.Interface;
using CommonModel;
using EmployeePayrollMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace EmployeePayrollMVC.Controllers
{
    public class EmployeeController : Controller
    {
        IEmployeeBL employeeBL;
        public EmployeeController(IEmployeeBL employeeBL)
        {
            this.employeeBL = employeeBL;
        }

        //public IActionResult Index()
        //{
        //    List<EmployeeModel> lstEmployee = new List<EmployeeModel>();
        //    lstEmployee = employeeBL.getEmployeeList().ToList();
        //    return View(lstEmployee);
        //}

        //[HttpGet]
        //public IActionResult Create()
        //{
        //    return View();
        //}


        //[HttpPost]
        public IActionResult Create(EmployeeModel employeemodel)
        {
            if (ModelState.IsValid)
            {
                employeeBL.addEmployee(employeemodel);
                return RedirectToAction("Index");
            }
            return View(employeemodel);
        }

        public JsonResult GetAll()
        {
            List<EmployeeModel> lstEmployee = new List<EmployeeModel>();
            lstEmployee = employeeBL.getEmployeeList().ToList();

            return Json(lstEmployee);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            EmployeeModel employee = employeeBL.getEmployeeById(id);

            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int? id)
        {
            var employee = employeeBL.getEmployeeById(id);
            employeeBL.deleteEmployee(employee);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            EmployeeModel employee = employeeBL.getEmployeeById(id);

            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost]
        public IActionResult Edit(int id, EmployeeModel employee)
        {
            if (id != employee.EmpId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                employeeBL.editEmployee(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }
        
        public IActionResult Custom()
        {
            List<EmployeeModel> lstEmployee = new List<EmployeeModel>();
            lstEmployee = employeeBL.getEmployeeList().ToList();

            return View(lstEmployee);
        }
      

        public JsonResult GetEmployeeById(int EmployeeId)
        {
            EmployeeModel employee = this.employeeBL.getEmployeeById(EmployeeId);

            return Json(employee);
        }

        public JsonResult Createjson(EmployeeModel employeemodel)
        {

            employeeBL.addEmployee(employeemodel);
           
            return Json(employeemodel);
        }
    }

}



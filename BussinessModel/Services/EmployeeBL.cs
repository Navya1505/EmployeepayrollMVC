using BussinessModel.Interface;
using CommonModel;
using RepositoryModel.Interface;
using RepositoryModel.Services;
using System;
using System.Collections.Generic;
using System.Text;
using static BussinessModel.Services.EmployeeBL;

namespace BussinessModel.Services
{

    public class EmployeeBL : IEmployeeBL
    {
        IEmployeeRL employeeRL;
        public EmployeeBL(IEmployeeRL employeeRL)
        {
            this.employeeRL = employeeRL;
        }
        public void addEmployee(EmployeeModel employeemodel)
        {
            try
            {
                this.employeeRL.addEmployee(employeemodel);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public List<EmployeeModel> getEmployeeList()
        {
            try
            {
                return this.employeeRL.getEmployeeList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void deleteEmployee(EmployeeModel employee)
        {
            try
            {
                this.employeeRL.deleteEmployee(employee);
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public void editEmployee(EmployeeModel employeeModel)
        {
            try
            {
                this.employeeRL.editEmployee(employeeModel);
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public EmployeeModel getEmployeeById(int? id)
        {
            try
            {
                return this.employeeRL.getEmployeeById(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

      
    }
}



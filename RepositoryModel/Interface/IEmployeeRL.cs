
using CommonModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryModel.Interface
{
    public interface IEmployeeRL
    {
        public void addEmployee(EmployeeModel employeemodel);
        public List<EmployeeModel> getEmployeeList();
       public  EmployeeModel getEmployeeById(int? id);
       public void deleteEmployee(EmployeeModel employeeModel);
       public void editEmployee(EmployeeModel employeeModel);

    }
}

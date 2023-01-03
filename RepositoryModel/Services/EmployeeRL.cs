using CommonModel;
using Microsoft.Extensions.Configuration;
using RepositoryModel.Interface;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace RepositoryModel.Services
{
    public class EmployeeRL : IEmployeeRL
    {
        private readonly IConfiguration Configuration;
        public EmployeeRL(IConfiguration Configuration)
        {
            this.Configuration = Configuration;
        }
        public void addEmployee(EmployeeModel employeemodel)
        {
            using (SqlConnection con = new SqlConnection(this.Configuration.GetConnectionString("EmployeepayrollDB")))
            {
                {
                    SqlCommand cmd = new SqlCommand("addEmployeeDetails", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Name", employeemodel.Name);
                    cmd.Parameters.AddWithValue("@Profile_img", employeemodel.ProfileImage);
                    cmd.Parameters.AddWithValue("@Gender", employeemodel.Gender);
                    cmd.Parameters.AddWithValue("@Department", employeemodel.Department);
                    cmd.Parameters.AddWithValue("@Salary", employeemodel.Salary);
                    cmd.Parameters.AddWithValue("@StartDate", employeemodel.StartDate);
                    cmd.Parameters.AddWithValue("@Notes", employeemodel.Notes);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }

        public List<EmployeeModel> getEmployeeList()
        {
            List<EmployeeModel> EmpList = new List<EmployeeModel>();
            using (SqlConnection con = new SqlConnection(this.Configuration.GetConnectionString("EmployeepayrollDB")))
            {
                SqlCommand cmd = new SqlCommand("allEmployees", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                //Bind EmpModel generic list using dataRow     
                foreach (DataRow dr in dt.Rows)
                {
                    EmpList.Add(
                        new EmployeeModel
                        {
                            EmpId = Convert.ToInt32(dr["Emp_id"]),
                            Name = Convert.ToString(dr["Name"]),
                            ProfileImage = Convert.ToString(dr["Profile_img"]),
                            Gender = Convert.ToString(dr["Gender"]),
                            Department = Convert.ToString(dr["Department"]),
                            Salary = Convert.ToInt32(dr["Salary"]),
                            StartDate = Convert.ToDateTime(dr["StartDate"]),
                            Notes = Convert.ToString(dr["Notes"])
                        }
                        );
                }
            }
            return EmpList;
        }
        public EmployeeModel getEmployeeById(int? id)
        {
            EmployeeModel employee = new EmployeeModel();

            using (SqlConnection con = new SqlConnection(this.Configuration.GetConnectionString("EmployeepayrollDB")))
            {
                string sqlQuery = "SELECT * FROM employeeDetails WHERE emp_id= " + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    employee.EmpId = Convert.ToInt32(rdr["Emp_id"]);
                    employee.Name = rdr["Name"].ToString();
                    employee.ProfileImage = rdr["Profile_img"].ToString();
                    employee.Gender = rdr["Gender"].ToString();
                    employee.Department = rdr["Department"].ToString();
                    employee.Salary = Convert.ToInt32(rdr["Salary"]);
                   employee.StartDate = Convert.ToDateTime(rdr["Startdate"]);
                    employee.Notes = rdr["Notes"].ToString();
                }
            }
            return employee;
        }

        public void deleteEmployee(EmployeeModel employeemodel)
        {
            using (SqlConnection con = new SqlConnection(this.Configuration.GetConnectionString("EmployeepayrollDB")))
            {
                SqlCommand cmd = new SqlCommand("deleteEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Emp_id", employeemodel.EmpId);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void editEmployee(EmployeeModel employeeModel)
        {
            using (SqlConnection con = new SqlConnection(this.Configuration.GetConnectionString("EmployeepayrollDB")))
            {
                SqlCommand cmd = new SqlCommand("UpdateEmployeeDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Emp_id", employeeModel.EmpId);
                cmd.Parameters.AddWithValue("@Name", employeeModel.Name);
                cmd.Parameters.AddWithValue("@Profile_img", employeeModel.ProfileImage);
                cmd.Parameters.AddWithValue("@Gender", employeeModel.Gender);
                cmd.Parameters.AddWithValue("@Department", employeeModel.Department);
                cmd.Parameters.AddWithValue("@Salary", employeeModel.Salary);
                cmd.Parameters.AddWithValue("@StartDate", employeeModel.StartDate);
                cmd.Parameters.AddWithValue("@Notes", employeeModel.Notes);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }

}
 
       

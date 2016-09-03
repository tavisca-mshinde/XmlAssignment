using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Xml.Linq;

namespace XMLAssignment
{
   public class XMLassignConsole
    {
         
        public static void Main(string[] args)
        {
            DataClasses1DataContext dataClass1DataContext = new DataClasses1DataContext();
            //dat
            DataSet ds = new DataSet();
            ds.ReadXml(@"D:\HotelMgmtSystem\XMLAssignment\xmlDoc\Employee-Company.xml");
            DataTable companyXML = ds.Tables["Company"];
            DataTable departmentXML = ds.Tables["Department"];
            DataTable departmentsXML = ds.Tables["Departments"];
            DataTable employeeXML = ds.Tables["Employee"];
            DataTable employeesXML = ds.Tables["Employees"];
            try
            {
                foreach (DataRow cr in companyXML.Rows)
                {
                    Company company = new Company
                    {
                        Company_Id = ValidationClass.CompanyIdCheck(cr["Company_Id"].ToString()),
                        CompanyName = ValidationClass.StringCheck(cr["CompanyName"].ToString())
                    };
                    dataClass1DataContext.Companies.InsertOnSubmit(company);
                }
                dataClass1DataContext.SubmitChanges();

                foreach (DataRow deptsrow in departmentsXML.Rows)
                {
                    Department1 depts = new Department1
                    {
                        Departments_Id = ValidationClass.DepartmentsIdCheck(deptsrow["Departments_Id"].ToString()),
                        Company_Id = ValidationClass.CompanyIdCheckIndepts(deptsrow["Company_Id"].ToString())
                    };
                    dataClass1DataContext.Department1s.InsertOnSubmit(depts);
                }
                dataClass1DataContext.SubmitChanges();
                foreach (DataRow deptrow in departmentXML.Rows)
                {
                    Department dept = new Department
                    {
                        ID = ValidationClass.DepartmentIdCheck(deptrow["ID"].ToString()),
                        DepartmentName = ValidationClass.DepartmentNameCheck(deptrow["DepartmentName"].ToString()),
                        Departments_Id = ValidationClass.DepartmentsIdCheckIndept(deptrow["Departments_Id"].ToString())
                    };
                    dataClass1DataContext.Departments.InsertOnSubmit(dept);
                }
                dataClass1DataContext.SubmitChanges();
                foreach (DataRow empsrow in employeesXML.Rows)
                {
                    Employee1 emps = new Employee1
                    {
                        Employees_Id = ValidationClass.EmployeesIdCheck(empsrow["Employees_Id"].ToString()),
                        Company_Id = ValidationClass.CompanyIdCheckIndepts(empsrow["Company_Id"].ToString())
                    };
                    dataClass1DataContext.Employee1s.InsertOnSubmit(emps);
                }
                dataClass1DataContext.SubmitChanges();
                foreach (DataRow emprow in employeeXML.Rows)
                {
                    Employee emp = new Employee
                    {
                        ID =ValidationClass.EmployeeIdCheck(emprow["ID"].ToString()),
                        DepartmentID = ValidationClass.DepartmentIdCheckInEmp(emprow["DepartmentId"].ToString()),
                        FirstName = ValidationClass.StringCheck(emprow["FirstName"].ToString()),
                        LastName = ValidationClass.StringCheck(emprow["LastName"].ToString()),
                        Salary = ValidationClass.SalaryInEmp(emprow["Salary"].ToString()),
                        Employees_Id = ValidationClass.EmployeesIdCheckInEmp(emprow["Employees_Id"].ToString())
                    };
                    dataClass1DataContext.Employees.InsertOnSubmit(emp);
                }
                dataClass1DataContext.SubmitChanges();
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

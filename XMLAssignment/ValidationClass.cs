using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Text.RegularExpressions;

namespace XMLAssignment
{
    public class ValidationClass
    {
        static DataClasses1DataContext dataClasses1DataContext = new DataClasses1DataContext();
        //ValidationClass validationClass = new ValidationClass();
        public static Int64 CompanyIdCheck(string number)
        {
            if (ValidationClass.IsDigit(number))
            {

                if (Convert.ToInt64(number) >= 0)
                {
                    Int64 In_Id = Convert.ToInt64(number);
                    // bool b = dataClasses1DataContext.Compnays.Contains(In_Id).ToString()
                    var checkNo =
                        from id in dataClasses1DataContext.Companies where id.Company_Id == In_Id select id.Company_Id;
                    if (checkNo.Count() == 0)
                    {
                        return In_Id;
                    }
                    else
                    {
                        throw new Exception("No already present");
                    }
                    //return Convert.ToInt64(number);
                }
                else
                {
                    throw new Exception(" please enter positive number");
                }
            }
            else
            {
                throw new Exception("Not a number");
            }

        }



        //depatments id

        public static Int64 DepartmentsIdCheck(string number)
        {
            if (ValidationClass.IsDigit(number))
            {

                if (Convert.ToInt64(number) >= 0)
                {
                    Int64 In_Id = Convert.ToInt64(number);
                    // bool b = dataClasses1DataContext.Compnays.Contains(In_Id).ToString()
                    var checkNo =
                        from id in dataClasses1DataContext.Department1s where id.Departments_Id == In_Id select id.Departments_Id;
                    if (checkNo.Count() == 0)
                    {
                        return In_Id;
                    }
                    else
                    {
                        throw new Exception("No already present");
                    }
                    //return Convert.ToInt64(number);
                }
                else
                {
                    throw new Exception(" please enter positive number");
                }
            }
            else
            {
                throw new Exception("Not a number");
            }

        }

        public static bool IsDigit(string number)
        {
            Match match = Regex.Match(number, @"[0-9]+");
            return match.Success;
        }


        //company name
        public static string StringCheck(string companyName)
        {
            Match match = Regex.Match(companyName, @"[A-Za-z]+");
            if (match.Success)
                return companyName;
            else
                throw new Exception("Not valid Name For Company");
        }
        public static Int64 CompanyIdCheckIndepts(string companyId)
        {
            Match match = Regex.Match(companyId, @"[0-9]+");
            if (match.Success)
            {
                Int64 In_Id = Convert.ToInt64(companyId);
                var checkNo =
                       from id in dataClasses1DataContext.Companies where id.Company_Id == In_Id select id.Company_Id;
                if (checkNo.Count() == 1)
                    return In_Id;
                else
                    throw new Exception("It Is Not Present Please Try later");
            }
            else
                throw new Exception("Not valid Id For Company");
        }

        public static Int64 DepartmentIdCheck(string number)
        {
            if (ValidationClass.IsDigit(number))
            {

                if (Convert.ToInt64(number) >= 0)
                {
                    Int64 In_Id = Convert.ToInt64(number);
                    // bool b = dataClasses1DataContext.Compnays.Contains(In_Id).ToString()
                    var checkNo =
                        from id in dataClasses1DataContext.Departments where id.Departments_Id == In_Id select id.Departments_Id;
                    if (checkNo.Count() == 0)
                    {
                        return In_Id;
                    }
                    else
                    {
                        throw new Exception("No already present");
                    }
                    //return Convert.ToInt64(number);
                }
                else
                {
                    throw new Exception(" please enter positive number");
                }
            }
            else
            {
                throw new Exception("Not a number");
            }

        }

        public static string DepartmentNameCheck(string DepartmentName)
        {
            Match match = Regex.Match(DepartmentName, @"[A-Za-z]+");
            if (match.Success)
                return DepartmentName;
            else
                throw new Exception("Not valid Name For Deapartment");
        }


        public static Int64 DepartmentsIdCheckIndept(string number)
        {
            if (ValidationClass.IsDigit(number))
            {

                if (Convert.ToInt64(number) >= 0)
                {
                    Int64 In_Id = Convert.ToInt64(number);
                    // bool b = dataClasses1DataContext.Compnays.Contains(In_Id).ToString()
                    var checkNo =
                        from id in dataClasses1DataContext.Department1s where id.Departments_Id == In_Id select id.Departments_Id;
                    if (checkNo.Count() == 1)
                    {
                        return In_Id;
                    }
                    else
                    {
                        throw new Exception("No already present");
                    }
                    //return Convert.ToInt64(number);
                }
                else
                {
                    throw new Exception(" please enter positive number");
                }
            }
            else
            {
                throw new Exception("Not a number");
            }

        }

        public static Int64 EmployeesIdCheck(string number)
        {
            if (ValidationClass.IsDigit(number))
            {

                if (Convert.ToInt64(number) >= 0)
                {
                    Int64 In_Id = Convert.ToInt64(number);
                    // bool b = dataClasses1DataContext.Compnays.Contains(In_Id).ToString()
                    var checkNo =
                        from id in dataClasses1DataContext.Employee1s where id.Employees_Id == In_Id select id.Employees_Id;
                    if (checkNo.Count() == 0)
                    {
                        return In_Id;
                    }
                    else
                    {
                        throw new Exception("No already present");
                    }
                    //return Convert.ToInt64(number);
                }
                else
                {
                    throw new Exception(" please enter positive number");
                }
            }
            else
            {
                throw new Exception("Not a number");
            }

        }


        public static Int64 EmployeeIdCheck(string number)
        {
            if (ValidationClass.IsDigit(number))
            {

                if (Convert.ToInt64(number) >= 0)
                {
                    Int64 In_Id = Convert.ToInt64(number);
                    // bool b = dataClasses1DataContext.Compnays.Contains(In_Id).ToString()
                    var checkNo =
                        from id in dataClasses1DataContext.Employees where id.Employees_Id == In_Id select id.Employees_Id;
                    if (checkNo.Count() == 0)
                    {
                        return In_Id;
                    }
                    else
                    {
                        throw new Exception("No already present");
                    }
                    //return Convert.ToInt64(number);
                }
                else
                {
                    throw new Exception(" please enter positive number");
                }
            }
            else
            {
                throw new Exception("Not a number");
            }

        }
        public static Int64 DepartmentIdCheckInEmp(string number)
        {
            if (ValidationClass.IsDigit(number))
            {

                if (Convert.ToInt64(number) >= 0)
                {
                    Int64 In_Id = Convert.ToInt64(number);
                    // bool b = dataClasses1DataContext.Compnays.Contains(In_Id).ToString()
                    var checkNo =
                        from id in dataClasses1DataContext.Departments where id.ID == In_Id select id.ID;
                    if (checkNo.Count() == 1)
                    {
                        return In_Id;
                    }
                    else
                    {
                        throw new Exception("please ckeck department Id");
                    }
                    //return Convert.ToInt64(number);
                }
                else
                {
                    throw new Exception(" please enter positive number");
                }
            }
            else
            {
                throw new Exception("Not a number");
            }

        }


        public static Int64 EmployeesIdCheckInEmp(string number)
        {
            if (ValidationClass.IsDigit(number))
            {

                if (Convert.ToInt64(number) >= 0)
                {
                    Int64 In_Id = Convert.ToInt64(number);
                    // bool b = dataClasses1DataContext.Compnays.Contains(In_Id).ToString()
                    var checkNo =
                        from id in dataClasses1DataContext.Employee1s where id.Employees_Id == In_Id select id.Employees_Id;
                    if (checkNo.Count() == 1)
                    {
                        return In_Id;
                    }
                    else
                    {
                        throw new Exception("please check emplyeees Id");
                    }
                    //return Convert.ToInt64(number);
                }
                else
                {
                    throw new Exception(" please enter positive number");
                }
            }
            else
            {
                throw new Exception("Not a number");
            }

        }
        public static Int64 SalaryInEmp(string number)
        {
            if (ValidationClass.IsDigit(number))
            {
                Int64 sal = Convert.ToInt64(number);
                if (sal >= 0)
                    return sal;
                else
                    throw new Exception("Salary cannot be negative");
            }
            else
                throw new Exception("Not valid no");
        }
     }
}

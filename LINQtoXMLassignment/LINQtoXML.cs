using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LINQtoXMLassignment
{
    class LINQtoXML
    {
        static void Main(string[] args)
        {
            DBtoXmlDataContext dbtoXmlDataContext = new DBtoXmlDataContext();
            XDocument xDocs = new XDocument
                (
                    new XDeclaration("0.1", "utf-8", "yes"),
                    new XElement("Companies",
                           from c in dbtoXmlDataContext.Companies
                           select new XElement
                                    (
                                        "Company",
                                        new XElement("CompanyName",c.CompanyName),
                                            new XElement("Employees",
                                                from e in dbtoXmlDataContext.Employees 
                                                select new XElement
                                                            (
                                                        "Employee",
                                                       new XElement("ID",e.ID),
                                                       new XElement("FirstName",e.FirstName),
                                                       new XElement("LastName",e.LastName),
                                                       new XElement("Salary",e.Salary)         
                                                            )
                                                        ),
                                            new XElement("Departments",
                                                  from d in dbtoXmlDataContext.Departments
                                                  select new XElement
                                                            (
                                                        "Department",
                                                        new XElement("ID",d.ID),
                                                        new XElement("DepartmentName",d.DepartmentName)
                                                            )      
                                                        )
                                                           
                                    )
                                    

                                )

                );
            Console.WriteLine(xDocs);
            xDocs.Save(@"D:\companies.xml");
        }
    }
}
 //(
 //                       "Departments",
 //                       from d in dataClasses1DataContext.Departments
 //                       select new XElement
 //                           (
 //                           "Department",
 //                           new XElement("ID", d.ID),
 //                           new XElement("DepartmentName", d.DepartmentName)
 //                           )
 //                   )
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XMLAssignment;


namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        
        [TestMethod]
        public void TestMethod1()
        {
            try
            {
                //val = new ValidationClass();
                long a = ValidationClass.DigitConverter("0");
            }
            catch(Exception e) { string s = e.Message; }
        }
    }
}

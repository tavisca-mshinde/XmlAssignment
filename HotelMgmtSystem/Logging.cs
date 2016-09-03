using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HotelMgmtSystem
{
    public class Logging
    {
        
        public void logmethod(string s)
        {
            StreamWriter filelog = new StreamWriter(@"D:\HotelMgmtSystem\log.txt", true);
            filelog.WriteLine(s);
            filelog.Close();
        }
    }
}

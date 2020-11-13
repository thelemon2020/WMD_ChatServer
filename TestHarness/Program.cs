using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMD_ChatServer;

namespace TestHarness
{
    class Program
    {
        static void Main(string[] args)
        {
            FileHandler fh = new FileHandler();
            Logger.Log(fh.eventLog, "I like ya cut G");
        }
    }
}

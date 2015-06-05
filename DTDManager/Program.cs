using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 

namespace DTDManager
{
    class Program
    {
        static void Main(string[] args)
        {
            DTDDocment.Instance.Load(@"F:\ERP\DNet\CodeGenerate\feather-3.0.dtd");
            Console.WriteLine(DTDDocment.Instance.ToString());
            Console.Read();
        }
    }
}

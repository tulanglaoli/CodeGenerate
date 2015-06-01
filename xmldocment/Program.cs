using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using DotNet.Tools;
using System.IO;
using System.Net;


namespace MyXmlDocment
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DateTime.Now);
            MyXMLManager mxm = new MyXMLManager(@"F:\ERP\PromDMOperator.xml");
            Console.WriteLine(mxm.readXml(@"//Datasets",false));

            foreach (XmlNode xn in mxm.readnodes(@"//Dataset"))
            {
                Console.WriteLine(xn.OuterXml);
            };

            

           
            Console.ReadKey();
        }
    }
}

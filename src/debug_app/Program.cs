using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ifc2dyn;
namespace debug_app
{
    class Program
    {
        static void Main(string[] args)
        {
            IfcDoc test1 = new IfcDoc(@"E:\DataTest\Renga\BridgeEx.ifc");
            string units = test1.LengthUnits();
            var ttt = test1.GetElementsSorted();

            Console.WriteLine(units);

            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTableApp
{
    public class Program
    {
        static void Main()
        {
            var table = new HashDictionary<string, int>();
            table.Add("maria", 5);
            table.Add("gosho", 5);
            table.Add("tosho", 5);
            table.Add("misho", 5);
            Console.WriteLine();
        }
    }
}

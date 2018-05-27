using GrouveeParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrouveeParserConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.Run(async () => await ImportCollection()).Wait();
        }

        static async Task ImportCollection()
        {
            GrouveeCollection grouveeCollection = await grouveeCollection.ImportAsync(@"");

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkBench
{
    public class Comando
    {
        public void EscreverUmaLinha()
        {
            Console.WriteLine();
        }
        public void EscreverUmaLinha(string item)
        {
            Console.WriteLine(item);
        }
        public void EscreverUmaLinha(int item)
        {
            Console.WriteLine(item);
        }
        public void EscreverUmaLinha(double item)
        {
            Console.WriteLine(item);
        }
        public void EscreverUmaLinha(char item)
        {
            Console.WriteLine(item);
        }

    }
}

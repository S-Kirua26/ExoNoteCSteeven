using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Percolation
{
    class Program
    {
        static void Main(string[] args)
        {
            PercolationSimulation perco = new PercolationSimulation(3);
            perco.PercolationValue(3);
        }
    }
}

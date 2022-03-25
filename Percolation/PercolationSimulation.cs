using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Percolation
{
    public struct PclData
    {
        /// <summary>
        /// Moyenne 
        /// </summary>
        public double Mean { get; set; }
        /// <summary>
        /// Ecart-type
        /// </summary>
        public double StandardDeviation { get; set; }

        public double RelativeStd { get; set; }

    }

    public class PercolationSimulation
    {
        private int[,] _grille;
        public PercolationSimulation(int size)
        {
            _grille = new int[6, 6];
        }
        public PclData MeanPercolationValue(int size, int t)
        {
            throw new NotImplementedException();
        }

        public double PercolationValue(int size)
        {          
            for (int i = 0; i <= size; i++)
            {
                for (int j = 0; j <= size; j++)
                {
                    _grille[i,j] = 0;
                    
                }
            }

            Random random = new Random();
            int positionRandom = random.Next(_grille[0,6]);
            Console.WriteLine($"{positionRandom}");
            
            throw new NotImplementedException();
        }
    }
}

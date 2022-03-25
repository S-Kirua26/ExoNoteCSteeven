using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Percolation
{
    public class Percolation
    {
        private readonly bool[,] _open;
        private readonly bool[,] _full;
        private readonly int _size;
        private bool _percolate;
        private List<KeyValuePair<int, int>> _listePosition;


        public Percolation(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(size), size, "Taille de la grille négative ou nulle.");
            }

            _open = new bool[size, size];
            _full = new bool[size, size];
            _size = size;         
            _listePosition = new List<KeyValuePair<int, int>>();
        }

        private bool IsOpen(int i, int j)
        {
            if (i < 0 ||  i >= _size || j < 0 || j >= _size)
            {
                return false;
            }
            Console.WriteLine($"{_open[i, j]}");
            return _open[i, j];   
        }

        private bool IsFull(int i, int j)
        {
            if (i < 0 || i >= _size || j < 0 || j >= _size)
            {
                return false;
            }
            Console.WriteLine($"{_full[i, j]}");
            return _full[i, j];
        }

        public bool Percolate()
        {
            for (int i = 0; i < _size; i++)
            {
                if (!IsFull(_size, i))
                {                  
                    return false;
                }               
            }
            Console.WriteLine("Percolation réussi");
            return true;

        }

        private List<KeyValuePair<int, int>> CloseNeighbors(int i, int j)
        {

            if (i - 1 >= 0) // vérification de la bordure gauche du tableau
            {
                _listePosition.Add(new KeyValuePair <int, int>(i - 1, j));
            }

            if (i + 1 < _size) // vérification de la bordure droite du tableau
            {
                _listePosition.Add(new KeyValuePair<int, int>(i + 1, j));
            }

            if (j - 1 >= 0) // vérification de la bordure haute du tableau
            { 
                _listePosition.Add(new KeyValuePair<int, int>(i, j - 1));
            }
            
            if (j + 1 < _size) // vérification de la bordure basse du tableau
            {
                _listePosition.Add(new KeyValuePair<int, int>(i, j + 1));
            }

            return _listePosition;
        }

        private void Open(int i, int j)
        {
            throw new NotImplementedException();
        }
    }
}

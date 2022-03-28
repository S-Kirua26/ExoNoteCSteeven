using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompteBancaire.BusinessLogic
{
	class Operation
    {
		public string Sortie { get; set; }

		public Operation(string sortie)
		{
			Sortie = sortie;
		}

		public string ResultatOperation(Dictionary<int, double>, List<Transa>)
        {
			return "KO";
        }
	}
}

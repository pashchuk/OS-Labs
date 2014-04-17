using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OS3
{
	class Program
	{
		static void Main(string[] args)
		{
			List<int> asds = new List<int>();
			foreach (var asd in (from a in asds where a%10==0 select a))
			{
				Console.WriteLine("asd");
			}
		}
	}
}

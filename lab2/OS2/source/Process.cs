using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS2.source
{
	class Process
	{
		private MemoryManagedUnit unit;
		private int[] memory;
		public int ExpirationTime { get; set; }
		public int PageCount { get { return memory.Length; } }
		public void Init(int pageCount)
		{
			memory = new int[pageCount];
			for (int i = 0; i < pageCount; i++)
				memory[i] = unit.GetEmpthyPage();
		}
		public void Kill()
		{
			foreach (var i in memory)
				unit.GetPageById(i).ClearPage();
		}
	}
}

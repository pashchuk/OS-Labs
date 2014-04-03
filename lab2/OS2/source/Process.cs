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
		public void Start()
		{
			//Random rnd = new Random();
			//int pageCount = rnd.Next(1, 10);
			memory = new int[AppSetting.Default.VirtualPageCountMax];
		}
		public void Kill()
		{
			foreach (var i in memory)
				unit.GetPageById(i).ClearPage();
		}
	}
}

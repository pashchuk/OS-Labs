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
		private delegate void Working(Process proc);
		public event Working Work;
		public int ExpirationTime { get; set; }
		public int PageCount { get { return memory.Length; } }
		public void Start()
		{
			Random rnd = new Random();
			int pageCount = rnd.Next(1, AppSetting.Default.VirtualPageCountMax);
			memory = new int[pageCount];
			Work(this);
		}
		public void Kill()
		{
			foreach (var i in memory)
				unit.GetPageById(i).ClearPage();
		}
		public void ReadData()
		{
			Random rnd = new Random();
			int index = rnd.Next(1, AppSetting.Default.VirtualPageCountMax) - 1;
			unit.ReadDataById(memory[index]).GetData();
		}
	}
}

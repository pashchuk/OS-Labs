using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS2.source
{
	class Process
	{
		public int PID { get; set; }
		public readonly MemoryManagedUnit unit;
		private int[] memory;
		public delegate void Working(Process proc);
		public  Working Work;
		public int ExpirationTime { get; set; }
		public int PageCount { get { return memory.Length; } }
		public Process(MemoryManagedUnit unit)
		{
			this.unit = unit;
		}
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

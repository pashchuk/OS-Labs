using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS2.source
{
	class Process
	{
		#region Public Fields
		public bool IsSleep { get { return isSleep; } }
		public int PID { get; set; }
		public readonly MemoryManagedUnit unit;
		public delegate void Working(Process proc);
		public Working Work;
		public int ExpirationTime { get; set; }
		public int PageCount { get { return memory.Length; } }
		#endregion

		#region Private Fields
		private readonly int[] memory;
		private int elapsedTime = 0;
		private bool isSleep;
		private readonly Random rnd = new Random();
		#endregion
		
		
		public Process(MemoryManagedUnit unit)
		{
			this.unit = unit;
			int pageCount = rnd.Next(1, AppSetting.Default.VirtualMemory);
			memory = new int[pageCount];
		}

		public void Run()
		{
			int currTime = elapsedTime, workTime = rnd.Next(1, AppSetting.Default.ReadDataTimeLimit), tempTime = elapsedTime;
			while (++currTime%100 == 0)
			{
				if(currTime==ExpirationTime)
					Kill();
				if (currTime - tempTime == workTime)
				{
					ReadData();
					tempTime = currTime;
					workTime = rnd.Next(1, AppSetting.Default.ReadDataTimeLimit);
				}
			}
		}
		public bool Sleep()
		{
			if (IsSleep)
				return false;
			isSleep = true;
			return true;
		}
		public void Kill()
		{
			foreach (var i in memory)
				unit.GetPageById(i).ClearPage();
		}
		private void ReadData()
		{
			int index = rnd.Next(1, AppSetting.Default.VirtualMemory) - 1;
			unit.ReadDataById(memory[index]).GetData();
		}
	}
}

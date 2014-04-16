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
		public int PID { get; set; }
		public readonly MemoryManagedUnit unit;
		public delegate void Working(Process proc);
		public Working Work;
		public int ExpirationTime { get; set; }
		public int PageCount { get { return memory.Length; } }
		#endregion

		#region Private Fields
		private readonly int[] memory;
		private int[] workCollection;
		private int elapsedTime = 0;
		private readonly Random rnd = new Random();
		#endregion
		
		
		public Process(MemoryManagedUnit unit)
		{
			this.unit = unit;
			int pageCount = rnd.Next(1, AppSetting.Default.VirtualPagePerProcess);
			memory = new int[pageCount];
		}

		public void Run()
		{
			int currTime = elapsedTime, workTime = rnd.Next(1, AppSetting.Default.ReadDataTimeLimit), tempTime = elapsedTime;
			while (++currTime%100 == 0)
			{
				if(currTime%50==0)
					ChangeWorkCollection();
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
		public void Kill()
		{
			foreach (var i in memory)
				unit.GetPageById(i).ClearPage();
		}

		private void ChangeWorkCollection()
		{
			workCollection = new int[rnd.Next(1, AppSetting.Default.WorkCollection)];
			for (int i = 0; i < workCollection.Length; i++)
				workCollection[i] = memory[rnd.Next(1, memory.Length - 1)];
		}
		private void ReadData()
		{
			int index = rnd.Next(1, 10);
			if (index <= 9)
				unit.ReadDataById(workCollection[rnd.Next(1, workCollection.Length) - 1]).GetData();
			else
				unit.ReadDataById(memory[rnd.Next(1, memory.Length) - 1]).GetData();
			AppSetting.Default.log.Text += String.Format("Data was readed by {0} process", PID);
		}
	}
}

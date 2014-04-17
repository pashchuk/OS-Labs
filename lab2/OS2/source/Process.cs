using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OS2.source
{
	class Process
	{
		#region Public Fields

		public int ElapsedTime
		{
			get { return elapsedTime; }
			set
			{
				if(value>=ExpirationTime)
					Kill();
			}
		}
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
		private int elapsedTime;
		private readonly Random rnd;
		#endregion
		
		
		public Process(MemoryManagedUnit unit)
		{
			rnd = new Random();
			this.unit = unit;
			int pageCount = rnd.Next(1, AppSetting.Default.VirtualPagePerProcess);
			memory = unit.GetAdressMemory(pageCount);
			elapsedTime = 0;
			ChangeWorkCollection();
		}
		public void Kill()
		{
			foreach (var i in memory)
				unit.GetPageById(i).ClearPage();
		}

		public void ChangeWorkCollection()
		{
			workCollection = new int[rnd.Next(1, AppSetting.Default.WorkCollection)];
			for (int i = 0; i < workCollection.Length; i++)
				workCollection[i] = memory[rnd.Next(1, memory.Length) - 1];
		}
		public void ReadData()
		{
			int index = rnd.Next(1, 10);

			if (index <= 9)
				unit.ReadDataById(workCollection[rnd.Next(1, workCollection.Length) - 1]).GetData();
			else
				unit.ReadDataById(memory[rnd.Next(1, memory.Length) - 1]).GetData();
			AppSetting.Default.log.Text += String.Format("Data was readed by {0} process\r\n", PID);
		}
	}
}

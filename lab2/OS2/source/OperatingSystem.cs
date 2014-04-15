using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OS2.source
{
	class OperatingSystem
	{
		Random rnd = new Random();
		private MemoryManagedUnit memoryUnit;
		//public MemoryManagedUnit MemoryUnit { get { return memoryUnit; } }
		private List<Process> proc;
		public OperatingSystem()
		{
			proc = new List<Process>();
			memoryUnit= new MemoryManagedUnit();
			int currTime = 0, generateTime = rnd.Next(1, AppSetting.Default.GenerateProcessTimeLimit),
				tempTime = 0, pidCounter = 1;
			while (++currTime < AppSetting.Default.SimulationTimeLimit)
			{
				if (currTime - tempTime == generateTime)
				{
					Process process = new Process(memoryUnit) { PID = pidCounter++ };
					proc.Add(process);
					process.Work += WorkFunc;
					process.Start();
					tempTime = currTime;
				}
			}
		}
		public void WorkFunc(Process proc)
		{
			proc.ExpirationTime = rnd.Next(1, AppSetting.Default.ProcessExpirationTimeLimit);
			int currTime = 0, workTime = rnd.Next(1, AppSetting.Default.ReadDataTimeLimit), tempTime = 0;
			while (++currTime < proc.ExpirationTime)
			{
				if(currTime-tempTime==workTime)
				{
					proc.ReadData();
					tempTime = currTime;
					workTime = rnd.Next(1, AppSetting.Default.ReadDataTimeLimit);
				}
			}
		}
		
	}
}

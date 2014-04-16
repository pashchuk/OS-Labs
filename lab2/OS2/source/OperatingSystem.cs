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
			
		}

		public void BeginSimulation()
		{
			int currTime = 0,
				generateProcesTime = rnd.Next(1, AppSetting.Default.GenerateProcessTimeLimit),
				tempTime = 0, pidCounter = 1, quantumTime = 50,
				readDataTime = rnd.Next(1, AppSetting.Default.ReadDataTimeLimit);
			Process currentProcess;
			while (++currTime < AppSetting.Default.SimulationTimeLimit)
			{
				if (currTime - tempTime == generateProcesTime)
				{
					Process process = new Process(memoryUnit) {PID = pidCounter++};
					process.ExpirationTime = rnd.Next(1, AppSetting.Default.ProcessExpirationTimeLimit);
					proc.Add(process);
					process.Work += WorkFunc;
					tempTime = currTime;
				}
				

			}
		}
		public void WorkFunc(Process proc)
		{
			proc.ExpirationTime = rnd.Next(1, AppSetting.Default.ProcessExpirationTimeLimit);
			
		}
		
	}
}

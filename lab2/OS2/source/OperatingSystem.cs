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
		Random rnd;
		private MemoryManagedUnit memoryUnit;
		//public MemoryManagedUnit MemoryUnit { get { return memoryUnit; } }
		private List<Process> proc;
		public OperatingSystem()
		{
			rnd = new Random();
			proc = new List<Process>();
			memoryUnit= new MemoryManagedUnit();
			
		}
		public void BeginSimulation()
		{
			int currTime = 0, readDataTempTime = 0, tempElapsedTime = 0,
				generateProcessTempTime = 0, pidCounter = 1,
				readDataTime = rnd.Next(1, AppSetting.Default.ReadDataTimeLimit),
				generateProcessTime = rnd.Next(1, AppSetting.Default.GenerateProcessTimeLimit);
			proc.Add(new Process(memoryUnit)
			{
				PID = pidCounter++ ,
				ExpirationTime = int.MaxValue
			});
			Process currentProcess = proc[0];
			while (++currTime != AppSetting.Default.SimulationTimeLimit)
			{
				if(currentProcess!=null)
				{
					tempElapsedTime++;
					if (currTime%100 == 0)
					{
						currentProcess = proc[rnd.Next(1, proc.Count) - 1];
						AppSetting.Default.log.Text += String.Format("Current PageFold : {0}\r\n", AppSetting.Default.PageFoldCounter);
						AppSetting.Default.AllPageFold += AppSetting.Default.PageFoldCounter;
						AppSetting.Default.PageFoldCounter = 0;
					}
					if (currTime%50 == 0)
						currentProcess.ChangeWorkCollection();
					if (currTime - readDataTempTime == readDataTime)
					{
						currentProcess.ReadData();
						readDataTempTime = currTime;
						readDataTime = rnd.Next(1, AppSetting.Default.ReadDataTimeLimit);
						currentProcess.ElapsedTime += tempElapsedTime;
						tempElapsedTime = 0;
					}
				}
				if (currTime - generateProcessTempTime == generateProcessTime)
				{
					Process process = new Process(memoryUnit) { PID = pidCounter++ };
					process.ExpirationTime = rnd.Next(1, AppSetting.Default.ProcessExpirationTimeLimit);
					proc.Add(process);
					generateProcessTempTime = currTime;
					generateProcessTime = rnd.Next(1, AppSetting.Default.GenerateProcessTimeLimit);
				}
			}
			AppSetting.Default.AllPageFold += AppSetting.Default.PageFoldCounter;
			AppSetting.Default.log.Text += string.Format("\r\n\r\nAll PageFold: {0}", AppSetting.Default.AllPageFold);
		}
	}
}

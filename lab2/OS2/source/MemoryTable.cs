using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS2.source
{
	class MemoryManagedUnit
	{
		private VirtualPage[] virtualMemory;
		private PhysicPage[] ram;
		public int VirtualPageCount { get { return virtualMemory.Length; } }
		public int PhysicPageCount { get { return ram.Length; } }
		public MemoryManagedUnit(int VirtualMemoryLength, int PhysicMemoryLength)
		{
			virtualMemory = new VirtualPage[VirtualMemoryLength];
			ram = new PhysicPage[PhysicMemoryLength];
			Init();
		}
		private void Init()
		{
			for (int i = 0; i < PhysicPageCount; i++)
				ram[i] = new PhysicPage(i);
			for (int i = 0; i < VirtualPageCount; i++)
				virtualMemory[i] = new VirtualPage() { Index = i };
		}
		public VirtualPage getEmpthyPage()
		{

		}
	}
}

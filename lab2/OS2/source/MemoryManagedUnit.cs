using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS2.source
{
	class MemoryManagedUnit
	{
		private int cursor
		{
			get { return cursor; }
			set
			{
				if (value >= PhysicPageCount)
					cursor = 0;
				else cursor = value;
			}
		}
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
		public int GetEmpthyPage()
		{
			foreach (var i in virtualMemory)
				if (!i.Exist)
					return i.Index;
			return -1;
		}
		public VirtualPage GetPageById(int id)
		{
			return virtualMemory[id];
		}
		public PhysicPage ReadDataById(int id)
		{
			if (virtualMemory[id].Exist)
				return virtualMemory[id].PageMemory;
			else return GetPhysicPage();
		}
		private PhysicPage GetPhysicPage()
		{
			while(cursor<PhysicPageCount)
			{
				if (ram[cursor].ParentPage == null)
				{
					return ram[cursor++];
					break;
				}
				else if (!ram[cursor].ParentPage.Modified)
				{
					return ram[cursor++];
					break;
				}
				else ram[cursor++].ParentPage.Modified = false;
			}
			return null;
		}
	}
}

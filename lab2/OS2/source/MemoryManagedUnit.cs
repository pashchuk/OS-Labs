using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS2.source
{
	class MemoryManagedUnit
	{
		private int cursor;
		public int Cursor
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
		public MemoryManagedUnit()
		{
			virtualMemory = new VirtualPage[AppSetting.Default.VirtualMemory];
			ram = new PhysicPage[AppSetting.Default.PhysicMemory];
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
			if (!virtualMemory[id].Exist)
				virtualMemory[id].PageMemory = GetPhysicPage();
			return virtualMemory[id].PageMemory;
		}
		private PhysicPage GetPhysicPage()
		{
			while(Cursor<PhysicPageCount)
			{
				if (ram[Cursor].ParentPage == null)
					return ram[Cursor++];
				else if (!ram[Cursor].ParentPage.Modified)
					return ram[Cursor++];
				else ram[Cursor++].ParentPage.Modified = false;
			}
			return null;
		}
	}
}

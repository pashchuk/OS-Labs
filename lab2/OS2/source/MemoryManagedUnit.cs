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
			get
			{
				if (cursor == PhysicPageCount)
					cursor = 0;
				return cursor;
			}
			set
			{
				if (value == PhysicPageCount)
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

		public int[] GetAdressMemory(int countOfPages)
		{
			int succesfulPages = 0;
			int[] memory = new int[countOfPages];
			foreach (var virtualPage in virtualMemory.Where(virtualPage => !virtualPage.Exist && succesfulPages < countOfPages))
				memory[succesfulPages++] = virtualPage.Index;
			foreach (var virtualPage in virtualMemory.Where(virtualPage => virtualPage.Exist && !virtualPage.Modified && succesfulPages<countOfPages))
			{ 
				memory[succesfulPages++] = virtualPage.Index;
				virtualPage.ClearPage();
			}
			foreach (var virtualPage in virtualMemory.Where(virtualPage => virtualPage.Exist && virtualPage.Modified && succesfulPages < countOfPages))
			{
				memory[succesfulPages++] = virtualPage.Index;
				virtualPage.ClearPage();
			}
			return memory;
		}
		private PhysicPage GetPhysicPage()
		{
			AppSetting.Default.PageFoldCounter++;
			while(Cursor<PhysicPageCount)
			{
				if (ram[Cursor].ParentPage == null)
					return ram[cursor++];
				else if (!ram[Cursor].ParentPage.Modified)
					return ram[cursor++];
				else ram[Cursor++].ParentPage.Modified = false;
			}
			return null;
		}
	}
}

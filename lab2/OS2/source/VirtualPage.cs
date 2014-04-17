using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OS2.source
{
	class VirtualPage
	{
		public int Index { get; set; }
		public bool Exist{ get; private set; }
		public bool Modified { get; set; }
		public bool Read { get; private set; }
		private PhysicPage page;
		public PhysicPage PageMemory
		{
			get
			{
				Modified = true;
				Read = true;
				return page;
			}
			set
			{
				Exist = true;
				page = value;
				page.ParentPage = this;
			}
		}
		public void ClearPage()
		{
			Exist = false;
			Modified = false;
			Read = false;
		}
	}
}

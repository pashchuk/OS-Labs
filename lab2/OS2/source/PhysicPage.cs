using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OS2.source
{
	class PhysicPage
	{
		private VirtualPage parentPage;
		private int index;
		public VirtualPage ParentPage
		{
			get { return parentPage; }
			set { parentPage = value; }
		}
		public int Index { get; set; }
		public PhysicPage(int Index)
		{
			this.index = Index;
		}
		public bool GetData()
		{
			parentPage.Modified = true;
			return parentPage == null ? false : true;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
			return parentPage == null ? false : true;
		}
	}
}

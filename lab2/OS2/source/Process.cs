using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS2.source
{
	class Process
	{
		private VirtualPage[] memory;
		public int ExpirationTime { get; set; }
		public int PageCount { get { return memory.Length; } }
		public void Init(int pageCount)
		{
			memory = new VirtualPage[pageCount];
		}
	}
}

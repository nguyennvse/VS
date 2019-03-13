using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VS_Business.Model
{
	class CustomerListModel 
	{
		public string typename { get; set; }
		public string name { get; set; }
		public string company { get; set; }
		public string tax { get; set; }
		public string phone { get; set; }
		public string email { get; set; }
		public string fax { get; set; }
		public int type { get; set; }
		public int id { get; set; }
		public CustomerListModel()
		{
			
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VS_Business.Model
{
    class BDOListModel
    {
		public int id { get; set; }
		public string goodcode { get; set; }
		public string name { get; set; }
		public int quantity { get; set; }
		public BDOListModel()
		{

		}

		public BDOListModel(int id, string goodcode, string name, int quantity)
		{
			this.id = id;
			this.goodcode = goodcode;
			this.name = name;
			this.quantity = quantity;
		}
	}
}

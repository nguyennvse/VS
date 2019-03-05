using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VS_Business.Model
{
	class PriceListDetailModel
	{
		public string name { get; set; }
		public int price { get; set; }
		public string code { get; set; }
		public PriceListDetailModel()
		{

		}

		public PriceListDetailModel(string name, int price,string code)
		{
			this.name = name;
			this.price = price;
			this.code = code;
		}
	}
}

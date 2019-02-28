using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VS_Business.Model
{
	class CustomerCBBModel
	{
		string Text { get; set; }
		int Value { get; set; }
		public CustomerCBBModel(string Text, int Value)
		{
			this.Text = Text;
			this.Value = Value;
		}
	}
}

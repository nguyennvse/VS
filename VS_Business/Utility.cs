using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VS_Business
{
	class Utility
	{
		public static void loadCustomerCBB(ComboBox cbb)
		{
			cbb.DisplayMember = "Text";
			cbb.ValueMember = "Value";
			using (VB_BusinessEntities db = new VB_BusinessEntities())
			{
				var cusList = (from c in db.PersonalInfoes where c.Type == 0 select c).ToList();
				foreach (var cus in cusList)
				{
					cbb.Items.Add(new { Text = cus.Name, Value = cus.ID });
				}
			}
			cbb.SelectedIndex = 1;
		}
	}
}

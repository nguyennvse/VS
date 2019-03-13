using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VS_Business
{
	public partial class Menu : Form
	{
		public Menu()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Accounts empForm = new Accounts();
			loadForm(empForm);
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Customer cusForm = new Customer();
			loadForm(cusForm);
		}

		private void autherizeEmp()
		{

		}

		private void button3_Click(object sender, EventArgs e)
		{
			Goods goodForm = new Goods();
			loadForm(goodForm);
		}

		private void button4_Click(object sender, EventArgs e)
		{
			BuyGood buyGoodForm = new BuyGood();
			loadForm(buyGoodForm);
		}

		private string numberWithComma(int value)
		{
			string result = Regex.Replace(value.ToString(), @"/\B(?=(\d{3})+(?!\d))/g", ",");
			return result;
		}

		private void button5_Click(object sender, EventArgs e)
		{
			PriceLists priceListForm = new PriceLists();
			loadForm(priceListForm);
		}

		private void setSizeFitForm(Control form)
		{
			if (this.WindowState != FormWindowState.Maximized)
			{
				this.Width = 330 + form.Width;
				this.Height = form.Height + 70;
				this.panelLoadForm.Width =  form.Width- 10;
				this.panelLoadForm.Height = form.Height - 10;
			}
			else
			{
				form.Width = this.Width - 330;
				form.Height = this.Height - 70;
			}
		}

		private void loadForm(Form form)
		{
			panelLoadForm.Controls.Clear();
			setSizeFitForm(form);
			form.TopLevel = false;
			form.AutoScroll = true;
			form.FormBorderStyle = FormBorderStyle.None;
			form.Anchor = (AnchorStyles.Bottom | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Left);
			panelLoadForm.Controls.Add(form);
			form.Show();
		}
	}
}

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
			panelLoadForm.Controls.Clear();
			Accounts empForm = new Accounts();
			empForm.TopLevel = false;
			empForm.AutoScroll = true;
			empForm.FormBorderStyle = FormBorderStyle.None;
			setSizeFitForm(empForm);
			panelLoadForm.Controls.Add(empForm);
			empForm.Show();
			//Hide();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			panelLoadForm.Controls.Clear();
			Customer cusForm = new Customer();
			cusForm.TopLevel = false;
			cusForm.AutoScroll = true;
			cusForm.FormBorderStyle = FormBorderStyle.None;
			panelLoadForm.Size = cusForm.Size;
			panelLoadForm.Controls.Add(cusForm);
			setSizeFitForm(cusForm);
			cusForm.Show();
		}

		private void autherizeEmp()
		{

		}

		private void button3_Click(object sender, EventArgs e)
		{
			panelLoadForm.Controls.Clear();
			Goods goodForm = new Goods();
			goodForm.TopLevel = false;
			goodForm.AutoScroll = true;
			goodForm.FormBorderStyle = FormBorderStyle.None;
			panelLoadForm.Controls.Add(goodForm);
			setSizeFitForm(goodForm);
			goodForm.Show();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			panelLoadForm.Controls.Clear();
			BuyGood buyGoodForm = new BuyGood();
			buyGoodForm.TopLevel = false;
			buyGoodForm.AutoScroll = true;
			buyGoodForm.FormBorderStyle = FormBorderStyle.None;
			panelLoadForm.Controls.Add(buyGoodForm);
			setSizeFitForm(buyGoodForm);
			buyGoodForm.Show();
		}

		private string numberWithComma(int value)
		{
			string result = Regex.Replace(value.ToString(), @"/\B(?=(\d{3})+(?!\d))/g", ",");
			return result;
		}

		private void button5_Click(object sender, EventArgs e)
		{
			panelLoadForm.Controls.Clear();
			PriceLists priceListForm = new PriceLists();
			priceListForm.TopLevel = false;
			priceListForm.AutoScroll = true;
			priceListForm.FormBorderStyle = FormBorderStyle.None;
			panelLoadForm.Size = priceListForm.Size;
			panelLoadForm.Controls.Add(priceListForm);
			setSizeFitForm(priceListForm);
			priceListForm.Show();
		}

		private void setSizeFitForm(Control form)
		{
			this.panelLoadForm.Size = form.Size;
			this.Width = 330 + form.Width;
			this.Height = this.panelLoadForm.Height + 70;
		}
	}
}

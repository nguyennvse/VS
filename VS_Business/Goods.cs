using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VS_Business.Model;

namespace VS_Business
{
	public partial class Goods : Form
	{
		GoodModel currentGood = new GoodModel();
		public Goods()
		{
			InitializeComponent();
			loadDGVData();
		}

		private void editGood(int id, string name, string unit, int price, string code)
		{
			try
			{
				using (VB_BusinessEntities db = new VB_BusinessEntities())
				{
					Good editGood = (from u in db.Goods where u.ID == id select u).Single();
					editGood.Name = name;
					editGood.Price = price;
					editGood.Unit = unit;
					editGood.Code = code;
					db.SaveChanges();
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.StackTrace);
			}
		}

		private void deleteGood(int id)
		{
			using (VB_BusinessEntities db = new VB_BusinessEntities())
			{
				Good delGood = (from u in db.Goods where u.ID == id select u).Single();
				delGood.isDelete = 1;
				db.SaveChanges();
			}
		}

		private void addGood(string name, string unit, int price, string code)
		{
			try
			{
				using (VB_BusinessEntities db = new VB_BusinessEntities())
				{
					Good addGood = new Good();
					addGood.Name = name;
					addGood.Unit = unit;
					addGood.Price = price;
					addGood.Code = code;
					db.Goods.Add(addGood);
					db.SaveChanges();
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.StackTrace);
			}

		}

		private void searchGood(string name)
		{
			try
			{
				using (VB_BusinessEntities db = new VB_BusinessEntities())
				{
					var listGoods = (from u in db.Goods
													 where u.Name.Contains(name) && u.isDelete ==0
													 select u).ToList();
					dgvGoods.DataSource = listGoods;
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.StackTrace);
			}
		}

		private void Goods_Load(object sender, EventArgs e)
		{

		}


		private void viewDetail()
		{
			txtName.Text = currentGood.name;
			txtUnit.Text = currentGood.unit;
			txtPrice.Text = currentGood.price.ToString();
			txtGoodCode.Text = currentGood.code;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Menu m = new Menu();
			m.Show();
			Hide();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			try
			{
				editGood(currentGood.id, txtName.Text, txtUnit.Text, int.Parse(txtPrice.Text), txtGoodCode.Text);
				searchGood("");
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.StackTrace);
			}
		}

		private void btnSearch_Click(object sender, EventArgs e)
		{
			searchGood(txtSearch.Text);
		}


		private void dgvGoods_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			DataGridViewRow row = dgvGoods.Rows[e.RowIndex];
			try
			{
				if (dgvGoods.Columns[e.ColumnIndex].Name.Equals("Delete"))
				{
					deleteGood(int.Parse(row.Cells["ID"].Value.ToString()));
					searchGood("");
				}
				else
				{
					currentGood.code = row.Cells["codecl"].Value.ToString();
					currentGood.id = int.Parse(row.Cells["ID"].Value.ToString());
					currentGood.name = row.Cells["namecl"].Value.ToString();
					currentGood.unit = row.Cells["unitcl"].Value.ToString();
					currentGood.price = int.Parse(row.Cells["pricecl"].Value.ToString());
					viewDetail();
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.StackTrace);
			}
		}

		private void button3_Click_1(object sender, EventArgs e)
		{
			
		}

		private void dgvGoods_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		private void loadDGVData()
		{
			try
			{
				using (VB_BusinessEntities db = new VB_BusinessEntities())
				{
					var listGood = (from g in db.Goods where g.isDelete == 0 select g).ToList();
					dgvGoods.Columns.Clear();
					if (listGood.Count > 0)
					{
						var list = new BindingList<Good>(listGood);
						var source = new BindingSource(list, null);
						dgvGoods.DataSource = source;
						setting();
					}
					else
					{
						dgvGoods.DataSource = null;
					}
				}
			}
			catch (Exception ex)
			{
				Console.Write(ex.StackTrace);
			}
		}

		private void setting()
		{
			dgvGoods.RowTemplate.Height = 30;
			DataGridViewTextBoxColumn column5 = new DataGridViewTextBoxColumn();
			column5.Name = "codecl";
			column5.HeaderText = "Mã";
			column5.DataPropertyName = "code";
			dgvGoods.Columns.Add(column5);

			DataGridViewTextBoxColumn column1 = new DataGridViewTextBoxColumn();
			column1.Name = "namecl";
			column1.HeaderText = "Tên sản phẩm";
			column1.DataPropertyName = "name";
			dgvGoods.Columns.Add(column1);

			DataGridViewTextBoxColumn column2 = new DataGridViewTextBoxColumn();
			column2.Name = "unitcl";
			column2.HeaderText = "Đơn Vị Tính";
			column2.DataPropertyName = "unit";
			dgvGoods.Columns.Add(column2);

			DataGridViewTextBoxColumn column3 = new DataGridViewTextBoxColumn();
			column3.Name = "pricecl";
			column3.HeaderText = "Giá mua";
			column3.DataPropertyName = "price";
			dgvGoods.Columns.Add(column3);

			DataGridViewImageColumn column4 = new DataGridViewImageColumn();
			column4.Name = "Delete";
			column4.HeaderText = "Xóa";
			column4.Width = 40;
			column4.Image = Properties.Resources.icons8_trash_can_32;
			dgvGoods.Columns.Add(column4);

			DataGridViewButtonColumn column6 = new DataGridViewButtonColumn();
			column6.Name = "ID";
			column6.Visible = false;
			column6.DataPropertyName = "ID";
			dgvGoods.Columns.Add(column6);

			this.dgvGoods.Columns["ID"].Visible = false;
			this.dgvGoods.Columns["code"].Visible = false;
			this.dgvGoods.Columns["name"].Visible = false;
			this.dgvGoods.Columns["unit"].Visible = false;
			this.dgvGoods.Columns["price"].Visible = false;
			this.dgvGoods.Columns["isDelete"].Visible = false;
		}

		private void button1_Click_1(object sender, EventArgs e)
		{
			addGood(txtName.Text, txtUnit.Text, int.Parse(txtPrice.Text), txtGoodCode.Text);
			searchGood("");
		}
	}
}

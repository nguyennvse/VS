using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using VS_Business.Model;

namespace VS_Business
{
	public partial class Customer : Form
	{
		PersonModel currentPerson = new PersonModel();
		public Customer()
		{
			InitializeComponent();
		}

		private void Customer_Load(object sender, EventArgs e)
		{
			loadDGVdata();
			cbbType.Items.Add(new {Name = "Khách Hàng",Value="1" });
			cbbType.Items.Add(new { Name = "Nhà Phân Phối", Value = "0" });
			cbbType.DisplayMember = "Name";
			cbbType.ValueMember = "Value";
			cbbType.SelectedIndex = 0;
		}

		private void editCus(int id, string name, string company, string mst, string phone, string email, string fax)
		{
			try
			{
				using (VB_BusinessEntities db = new VB_BusinessEntities())
				{
					PersonalInfo cus = (from u in db.PersonalInfoes where u.ID == id select u).Single();
					cus.Name = name;
					cus.Company = company;
					cus.MST = mst;
					cus.Phone = phone;
					cus.Email = email;
					cus.Fax = fax;
					cus.Type = int.Parse(Utility.getCbbValue(cbbType));
					db.SaveChanges();
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.StackTrace);
			}
		}

		private void deleteCus(int id)
		{
			using (VB_BusinessEntities db = new VB_BusinessEntities())
			{
				PersonalInfo cus = (from u in db.PersonalInfoes where u.ID == id select u).Single();
				cus.isDelete = 1;
				db.SaveChanges();
				loadDGVdata();
			}
		}

		private void addCustomer(string name, string company, string mst, string phone, string email, string fax)
		{
			try
			{
				using (VB_BusinessEntities db = new VB_BusinessEntities())
				{
					PersonalInfo cus = new PersonalInfo();
					cus.Name = name;
					cus.Company = company;
					cus.MST = mst;
					cus.Phone = phone;
					cus.Email = email;
					cus.Fax = fax;
					cus.Type = int.Parse(Utility.getCbbValue(cbbType));
					db.PersonalInfoes.Add(cus);
					db.SaveChanges();
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.StackTrace);
			}

		}

		private void searchCus(string username)
		{
			try
			{
				using (VB_BusinessEntities db = new VB_BusinessEntities())
				{
					var listCus = (from u in db.PersonalInfoes where u.Name.Contains(username) && u.isDelete == 0 select u).ToList();
					dgvCustomer.DataSource = listCus;
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.StackTrace);
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			searchCus(txtSearch.Text);
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Menu m = new Menu();
			m.Show();
			Hide();
		}

		private void dgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				DataGridViewRow row = dgvCustomer.Rows[e.RowIndex];
				currentPerson.Name = row.Cells[0].Value.ToString();
				currentPerson.Company = row.Cells[1].Value.ToString();
				currentPerson.TaxNumber = row.Cells[2].Value.ToString();
				currentPerson.Phone = row.Cells[3].Value.ToString();
				currentPerson.Email = row.Cells[4].Value.ToString();
				currentPerson.FaxNumber = row.Cells[5].Value.ToString();
				currentPerson.id = int.Parse(row.Cells[7].Value.ToString());
				if (dgvCustomer.Columns[e.ColumnIndex].Name.Equals("Delete"))
				{
					deleteCus(currentPerson.id);
				}
				else
				{
					viewDetail();
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.StackTrace);
			}
		}

		private void viewDetail()
		{
			txtName.Text = currentPerson.Name;
			txtCompany.Text = currentPerson.Company;
			txtEmail.Text = currentPerson.Email;
			txtFax.Text = currentPerson.FaxNumber.ToString();
			txtPhone.Text = currentPerson.Phone.ToString();
			txtTax.Text = currentPerson.TaxNumber.ToString();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			editCus(currentPerson.id, txtName.Text, txtCompany.Text, txtFax.Text, txtPhone.Text, currentPerson.Email, currentPerson.FaxNumber);
			searchCus("");
		}

		private void button4_Click(object sender, EventArgs e)
		{
			addCustomer(txtName.Text, txtCompany.Text, txtFax.Text,txtPhone.Text, txtEmail.Text, txtFax.Text);
			searchCus("");
		}

		private void loadDGVdata()
		{
			try
			{
				using (VB_BusinessEntities db = new VB_BusinessEntities())
				{
					var listPeople = (from p in db.PersonalInfoes where p.isDelete == 0 select p).ToList();
					dgvCustomer.Columns.Clear();
					if (listPeople.Count > 0)
					{
						List<CustomerListModel> listmodel = new List<CustomerListModel>();
						foreach (var person in listPeople)
						{
							CustomerListModel model = new CustomerListModel();
							model.company = person.Company;
							model.email = person.Email;
							model.fax = person.Fax;
							model.id = person.ID;
							model.name = person.Name;
							model.phone = person.Phone;
							model.tax = person.MST;
							model.type = (int)person.Type;
							if (model.type == 1)
							{
								model.typename = "Khách hàng";
							}
							else
							{
								model.typename = "Nhà Phân Phối";
							}
							listmodel.Add(model);
						}
						var list = new BindingList<CustomerListModel>(listmodel);
						dgvCustomer.DataSource = list;
						setting();
					}
					else
					{
						dgvCustomer.DataSource = null;
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
			dgvCustomer.RowTemplate.Height = 30;
			DataGridViewTextBoxColumn column1 = new DataGridViewTextBoxColumn();
			column1.Name = "namecl";
			column1.HeaderText = "Tên";
			column1.DataPropertyName = "name";
			dgvCustomer.Columns.Add(column1);

			DataGridViewTextBoxColumn column2 = new DataGridViewTextBoxColumn();
			column2.Name = "companycl";
			column2.HeaderText = "Công ty";
			column2.DataPropertyName = "company";
			dgvCustomer.Columns.Add(column2);

			DataGridViewTextBoxColumn column3 = new DataGridViewTextBoxColumn();
			column3.Name = "mstcl";
			column3.HeaderText = "Mã Số Thuế";
			column3.DataPropertyName = "tax";
			dgvCustomer.Columns.Add(column3);

			DataGridViewTextBoxColumn column4 = new DataGridViewTextBoxColumn();
			column4.Name = "phonecl";
			column4.HeaderText = "Số Điện Thoại";
			column4.DataPropertyName = "phone";
			dgvCustomer.Columns.Add(column4);

			DataGridViewTextBoxColumn column7 = new DataGridViewTextBoxColumn();
			column7.Name = "emailcl";
			column7.HeaderText = "Email";
			column7.DataPropertyName = "email";
			dgvCustomer.Columns.Add(column7);

			DataGridViewTextBoxColumn column8 = new DataGridViewTextBoxColumn();
			column8.Name = "faxcl";
			column8.HeaderText = "FAX";
			column8.DataPropertyName = "fax";
			dgvCustomer.Columns.Add(column8);

			DataGridViewTextBoxColumn column9 = new DataGridViewTextBoxColumn();
			column9.Name = "typename";
			column9.HeaderText = "Loại";
			column9.DataPropertyName = "typename";
			dgvCustomer.Columns.Add(column9);

			DataGridViewImageColumn column5 = new DataGridViewImageColumn();
			column5.Name = "Delete";
			column5.HeaderText = "Xóa";
			column5.Width = 40;
			column5.Image = Properties.Resources.icons8_trash_can_32;
			dgvCustomer.Columns.Add(column5);

			DataGridViewTextBoxColumn column6 = new DataGridViewTextBoxColumn();
			column6.Name = "IDcl";
			column6.Visible = false;
			column6.DataPropertyName = "ID";
			dgvCustomer.Columns.Add(column6);
		}
	}
}

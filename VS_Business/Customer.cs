using System;
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

		}

		private void editCus(int id, string name, string company, int mst, int phone, string email, int fax)
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

		private void addCustomer(string name, string company, int mst, int phone, string email, int fax)
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
					cus.Type = 0;
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
				currentPerson.TaxNumber = int.Parse(row.Cells[2].Value.ToString());
				currentPerson.Phone = int.Parse(row.Cells[3].Value.ToString());
				currentPerson.Email = row.Cells[4].Value.ToString();
				currentPerson.FaxNumber = int.Parse(row.Cells[5].Value.ToString());
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
			editCus(currentPerson.id, txtName.Text, txtCompany.Text, int.Parse(txtFax.Text), int.Parse(txtPhone.Text), currentPerson.Email, currentPerson.FaxNumber);
			searchCus("");
		}

		private void button4_Click(object sender, EventArgs e)
		{
			addCustomer(txtName.Text, txtCompany.Text, int.Parse(txtFax.Text), int.Parse(txtPhone.Text), txtEmail.Text, int.Parse(txtFax.Text));
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
						var list = new BindingList<PersonalInfo>(listPeople);
						var source = new BindingSource(list, null);
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
			column3.DataPropertyName = "mst";
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

			DataGridViewButtonColumn column5 = new DataGridViewButtonColumn();
			column5.Name = "Delete";
			column5.HeaderText = "Xóa";
			dgvCustomer.Columns.Add(column5);

			DataGridViewTextBoxColumn column6 = new DataGridViewTextBoxColumn();
			column6.Name = "IDcl";
			column6.Visible = false;
			column6.DataPropertyName = "ID";
			dgvCustomer.Columns.Add(column6);
		}
	}
}

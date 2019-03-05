using System;
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
			// TODO: This line of code loads data into the 'vB_BusinessPersonalDataSet.PersonalInfo' table. You can move, or remove it, as needed.
			this.personalInfoTableAdapter.Fill(this.vB_BusinessPersonalDataSet.PersonalInfo);
			// TODO: This line of code loads data into the 'vB_BusinessPersonalInfoDataSet.PersonalInfo' table. You can move, or remove it, as needed.
			//this.PersonalInfoTableAdapter.Fill(this.vB_BusinessPersonalInfoDataSet.Personal_Info);


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

        private void deleteCus(string name)
        {
            using (VB_BusinessEntities db = new VB_BusinessEntities())
            {
                PersonalInfo cus = (from u in db.PersonalInfoes where u.Name == name select u).Single();
                db.PersonalInfoes.Remove(cus);
                db.SaveChanges();
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
                    var listCus = (from u in db.PersonalInfoes where u.Name.Contains(username) select u).ToList();
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
                currentPerson.FaxNumber = int.Parse(row.Cells[4].Value.ToString());
                currentPerson.Email = row.Cells[5].Value.ToString();
                currentPerson.id = int.Parse(row.Cells[7].Value.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }

            viewDetail();
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
    }
}

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
    public partial class Accounts : Form
    {
        AccountModel currentAcc = new AccountModel("","","",0);
        public Accounts()
        {
            InitializeComponent();
        }

        private void Employee_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'vB_BusinessDataSet.Account' table. You can move, or remove it, as needed.
            this.accountTableAdapter.Fill(this.vB_BusinessDataSet.Account);
            RoleModel role1 = new RoleModel("Giám Đốc",0);
            RoleModel role2 = new RoleModel("Quản lý", 1);
            RoleModel role3 = new RoleModel("Nhân Viên", 2);
            cbRole.Items.Add(role1);
            cbRole.Items.Add(role2);
            cbRole.Items.Add(role3);
            cbRole.SelectedIndex = 2;
            cbRole.DisplayMember = "name";
            cbRole.ValueMember = "value";
        }

      

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            addEmployee(txtUsername.Text,txtPassword.Text, cbRole.Text);
            searchEmp("");
            clearForm();
        }

        private void editEmployee(string usernameUpdate,string password, string role,string id)
        {
            try
            {
                using (VB_BusinessEntities db = new VB_BusinessEntities())
                {
                    Account acc = (from u in db.Accounts where u.username == id select u).Single();
                    acc.username = usernameUpdate;
                    acc.password = password;
                    acc.Role = role;
                    db.SaveChanges();
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        private void deleteEmployee(int id)
        {
            try
            {
                using (VB_BusinessEntities db = new VB_BusinessEntities())
                {
                    Account acc = (from u in db.Accounts where u.ID == id select u).Single();
                    db.Accounts.Remove(acc);
                    db.SaveChanges();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            
        }

        private void addEmployee(string username, string password, string role)
        {
            try
            {
                using (VB_BusinessEntities db = new VB_BusinessEntities())
                {
                    Account acc = new Account();
                    acc.username = username;
                    acc.password = password;
                    acc.Role = role;
                    db.Accounts.Add(acc);
                    db.SaveChanges();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
           
        }

        private void searchEmp(string username)
        {
            try
            {
                using (VB_BusinessEntities db = new VB_BusinessEntities())
                {
                    var listAcc = (from u in db.Accounts where u.username.Contains(username) select u).ToList();
                    dtgEmployee.DataSource = listAcc;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            searchEmp(txtSearch.Text);
        }
        
        private void viewDetail()
        {
            txtUsername.Text = currentAcc.username;
            txtPassword.Text = currentAcc.password;
            cbRole.SelectedIndex = cbRole.FindStringExact(currentAcc.role);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Menu m = new Menu();
            Hide();
            m.Show();
        }

        private void dtgEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dtgEmployee.Rows[e.RowIndex];
            currentAcc.username = row.Cells[0].Value.ToString();
            currentAcc.password = row.Cells[1].Value.ToString();
            currentAcc.role = row.Cells[2].Value.ToString();
            currentAcc.id = int.Parse(row.Cells[4].Value.ToString());
            DataGridViewColumn col = dtgEmployee.Columns[e.ColumnIndex];
            if (col.Name.Equals("Delete"))
            {
                deleteEmployee(currentAcc.id);
                searchEmp("");
            }
            else
            {
                viewDetail();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            editEmployee(txtUsername.Text,txtPassword.Text, cbRole.Text, currentAcc.username);
            searchEmp("");
        }

        private void clearForm()
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            cbRole.SelectedIndex = 0;
        }
        
    }
}

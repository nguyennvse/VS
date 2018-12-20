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
            cbRole.ValueMember = "roleid";
        }

      

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dtgEmployee.Rows[e.RowIndex];
            string username = row.Cells[0].Value.ToString();
            string password = row.Cells[2].Value.ToString();
            int role = int.Parse(row.Cells[3].Value.ToString());
            DataGridViewColumn col = dtgEmployee.Columns[e.ColumnIndex];
            switch (col.Name)
            {
                case "edit":
                    editEmployee(username,password, role);
                    break;
                case "delete":
                    deleteEmployee(username);
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            addEmployee(txtUsername.Text,txtPassword.Text,int.Parse(cbRole.SelectedValue.ToString()));
        }

        private void editEmployee(string username,string password, int role)
        {
            using (VB_BusinessEntities3 db = new VB_BusinessEntities3())
            {
                Account acc = (from u in db.Accounts where u.username == username select u).Single();
                acc.username = username;
                acc.password = password;
                acc.Role = role;
                db.SaveChanges();
            }
        }

        private void deleteEmployee(string username)
        {
            using (VB_BusinessEntities3 db = new VB_BusinessEntities3())
            {
                Account acc = (from u in db.Accounts where u.username == username select u).Single();
                db.Accounts.Remove(acc);
                db.SaveChanges();
            }
        }

        private void addEmployee(string username, string password, int role)
        {
            using (VB_BusinessEntities3 db = new VB_BusinessEntities3())
            {
                Account acc = new Account();
                acc.username = username;
                acc.password = password;
                acc.Role = role;
                db.Accounts.Add(acc);
                db.SaveChanges();
            }
        }

        private void searchEmp(string username)
        {
            using (VB_BusinessEntities3 db = new VB_BusinessEntities3())
            {
                var listAcc = (from u in db.Accounts where u.username.Contains(username) select u).ToList();
                dtgEmployee.DataSource = listAcc;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            searchEmp(txtSearch.Text);
        }
    }
}

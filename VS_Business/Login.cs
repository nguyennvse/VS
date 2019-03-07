using System;
using System.Linq;
using System.Windows.Forms;
namespace VS_Business
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void logInBtn_Click(object sender, EventArgs e)
        {
            
            using (VB_BusinessEntities db = new VB_BusinessEntities())
            {
                string username = txtUserName.Text;
                string password = txtPassword.Text;
                var result = (from a in db.Accounts
															where a.username == username && a.password==password && a.isDelete == 0
															select a).FirstOrDefault<Account>();
                if(result != null)
                {
                    Menu menu = new Menu();
                    menu.Show();
                    Hide();
                }
            }                
        }
    }
}

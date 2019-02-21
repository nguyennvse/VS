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
        }

        private void editGood(int id, string name, string unit, int price,string code)
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
                db.Goods.Remove(delGood);
                db.SaveChanges();
            }
        }

        private void addGood(string name, string unit, int price,string code)
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
                    var listGoods = (from u in db.Goods where u.Name.Contains(name) select u).ToList();
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
            // TODO: This line of code loads data into the 'vB_BusinessGoods.Goods' table. You can move, or remove it, as needed.
            this.goodsTableAdapter.Fill(this.vB_BusinessGoods.Goods);
            // TODO: This line of code loads data into the 'vB_BusinessGoods.Goods' table. You can move, or remove it, as needed.
            this.goodsTableAdapter.Fill(this.vB_BusinessGoods.Goods);

        }


        private void viewDetail()
        {
            txtName.Text = currentGood.name;
            txtUnit.Text = currentGood.unit;
            txtPrice.Text = currentGood.price.ToString();
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
                if (e.ColumnIndex != 5)
                {

                    currentGood.id = int.Parse(row.Cells[0].Value.ToString());
                    currentGood.name = row.Cells[1].Value.ToString();
                    currentGood.unit = row.Cells[2].Value.ToString();
                    currentGood.price = int.Parse(row.Cells[3].Value.ToString());
                    viewDetail();
                }
                else
                {
                    deleteGood(int.Parse(row.Cells[0].Value.ToString()));
                    searchGood("");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            addGood(txtName.Text, txtUnit.Text, int.Parse(txtPrice.Text),txtGoodCode.Text);
            searchGood("");
        }

        private void dgvGoods_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

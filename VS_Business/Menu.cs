﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
            empForm.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Customer cusForm = new Customer();
            cusForm.Show();
            Hide();
        }

        private void autherizeEmp()
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Goods goodForm = new Goods();
            Hide();
            goodForm.Show();
        }
    }
}

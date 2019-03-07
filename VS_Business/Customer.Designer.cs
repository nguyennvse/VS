namespace VS_Business
{
    partial class Customer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			this.dgvCustomer = new System.Windows.Forms.DataGridView();
			this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
			this.txtSearch = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.txtName = new System.Windows.Forms.TextBox();
			this.txtCompany = new System.Windows.Forms.TextBox();
			this.txtTax = new System.Windows.Forms.TextBox();
			this.txtPhone = new System.Windows.Forms.TextBox();
			this.txtFax = new System.Windows.Forms.TextBox();
			this.txtEmail = new System.Windows.Forms.TextBox();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dgvCustomer)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
			this.SuspendLayout();
			// 
			// dgvCustomer
			// 
			this.dgvCustomer.AllowUserToAddRows = false;
			this.dgvCustomer.AllowUserToDeleteRows = false;
			this.dgvCustomer.AutoGenerateColumns = false;
			this.dgvCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvCustomer.DataSource = this.bindingSource1;
			this.dgvCustomer.Location = new System.Drawing.Point(27, 71);
			this.dgvCustomer.Name = "dgvCustomer";
			this.dgvCustomer.ReadOnly = true;
			this.dgvCustomer.Size = new System.Drawing.Size(741, 391);
			this.dgvCustomer.TabIndex = 0;
			this.dgvCustomer.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCustomer_CellClick);
			// 
			// bindingSource1
			// 
			this.bindingSource1.DataMember = "PersonalInfo";
			// 
			// txtSearch
			// 
			this.txtSearch.Location = new System.Drawing.Point(27, 31);
			this.txtSearch.Name = "txtSearch";
			this.txtSearch.Size = new System.Drawing.Size(626, 20);
			this.txtSearch.TabIndex = 1;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(659, 24);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(99, 35);
			this.button1.TabIndex = 2;
			this.button1.Text = "Tìm Kiếm";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(814, 39);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(36, 20);
			this.label1.TabIndex = 3;
			this.label1.Text = "Tên";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(814, 81);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(63, 20);
			this.label2.TabIndex = 4;
			this.label2.Text = "Công ty";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(815, 122);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(88, 20);
			this.label3.TabIndex = 5;
			this.label3.Text = "Mã số thuế";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(814, 168);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(102, 20);
			this.label4.TabIndex = 6;
			this.label4.Text = "Số điện thoại";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(814, 210);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(59, 20);
			this.label5.TabIndex = 7;
			this.label5.Text = "Số Fax";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(816, 249);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(48, 20);
			this.label6.TabIndex = 8;
			this.label6.Text = "Email";
			// 
			// txtName
			// 
			this.txtName.Location = new System.Drawing.Point(942, 39);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(201, 20);
			this.txtName.TabIndex = 9;
			this.txtName.Text = " ";
			// 
			// txtCompany
			// 
			this.txtCompany.Location = new System.Drawing.Point(942, 81);
			this.txtCompany.Name = "txtCompany";
			this.txtCompany.Size = new System.Drawing.Size(201, 20);
			this.txtCompany.TabIndex = 10;
			// 
			// txtTax
			// 
			this.txtTax.Location = new System.Drawing.Point(942, 123);
			this.txtTax.Name = "txtTax";
			this.txtTax.Size = new System.Drawing.Size(201, 20);
			this.txtTax.TabIndex = 11;
			// 
			// txtPhone
			// 
			this.txtPhone.Location = new System.Drawing.Point(942, 168);
			this.txtPhone.Name = "txtPhone";
			this.txtPhone.Size = new System.Drawing.Size(201, 20);
			this.txtPhone.TabIndex = 12;
			// 
			// txtFax
			// 
			this.txtFax.Location = new System.Drawing.Point(942, 210);
			this.txtFax.Name = "txtFax";
			this.txtFax.Size = new System.Drawing.Size(201, 20);
			this.txtFax.TabIndex = 13;
			// 
			// txtEmail
			// 
			this.txtEmail.Location = new System.Drawing.Point(943, 253);
			this.txtEmail.Name = "txtEmail";
			this.txtEmail.Size = new System.Drawing.Size(200, 20);
			this.txtEmail.TabIndex = 14;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(802, 313);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(101, 35);
			this.button2.TabIndex = 15;
			this.button2.Text = "Trở về Menu";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(924, 313);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(101, 35);
			this.button3.TabIndex = 16;
			this.button3.Text = "Sửa";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(1042, 313);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(101, 35);
			this.button4.TabIndex = 17;
			this.button4.Text = "Thêm mới";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// Customer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1203, 493);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.txtEmail);
			this.Controls.Add(this.txtFax);
			this.Controls.Add(this.txtPhone);
			this.Controls.Add(this.txtTax);
			this.Controls.Add(this.txtCompany);
			this.Controls.Add(this.txtName);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.txtSearch);
			this.Controls.Add(this.dgvCustomer);
			this.Name = "Customer";
			this.Text = "Customer";
			this.Load += new System.EventHandler(this.Customer_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgvCustomer)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCustomer;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.BindingSource personalInfoBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn companyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mSTDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn phoneDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn faxDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtCompany;
        private System.Windows.Forms.TextBox txtTax;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtFax;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
		private System.Windows.Forms.BindingSource bindingSource1;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
	}
}
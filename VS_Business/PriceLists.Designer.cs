namespace VS_Business
{
	partial class PriceLists
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
			this.label1 = new System.Windows.Forms.Label();
			this.cbbCustomer = new System.Windows.Forms.ComboBox();
			this.dgvPriceListDetail = new System.Windows.Forms.DataGridView();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtPrice = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.cbbGood = new System.Windows.Forms.ComboBox();
			((System.ComponentModel.ISupportInitialize)(this.dgvPriceListDetail)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(12, 29);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(169, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "Bảng giá của khách hàng";
			// 
			// cbbCustomer
			// 
			this.cbbCustomer.FormattingEnabled = true;
			this.cbbCustomer.Location = new System.Drawing.Point(203, 29);
			this.cbbCustomer.Name = "cbbCustomer";
			this.cbbCustomer.Size = new System.Drawing.Size(193, 21);
			this.cbbCustomer.TabIndex = 1;
			this.cbbCustomer.SelectedIndexChanged += new System.EventHandler(this.cbbCustomer_SelectedIndexChanged);
			this.cbbCustomer.SelectedValueChanged += new System.EventHandler(this.cbbCustomer_SelectedValueChanged);
			// 
			// dgvPriceListDetail
			// 
			this.dgvPriceListDetail.AllowUserToAddRows = false;
			this.dgvPriceListDetail.AllowUserToDeleteRows = false;
			this.dgvPriceListDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvPriceListDetail.Location = new System.Drawing.Point(15, 65);
			this.dgvPriceListDetail.Name = "dgvPriceListDetail";
			this.dgvPriceListDetail.ReadOnly = true;
			this.dgvPriceListDetail.Size = new System.Drawing.Size(619, 353);
			this.dgvPriceListDetail.TabIndex = 2;
			this.dgvPriceListDetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPriceListDetail_CellClick);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(656, 65);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(73, 17);
			this.label2.TabIndex = 3;
			this.label2.Text = "Sản Phẩm";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(656, 104);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(58, 17);
			this.label3.TabIndex = 5;
			this.label3.Text = "Giá bán";
			// 
			// txtPrice
			// 
			this.txtPrice.Location = new System.Drawing.Point(758, 101);
			this.txtPrice.Name = "txtPrice";
			this.txtPrice.Size = new System.Drawing.Size(135, 20);
			this.txtPrice.TabIndex = 6;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(659, 147);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(64, 23);
			this.button1.TabIndex = 7;
			this.button1.Text = "Trở về";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(729, 147);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(91, 23);
			this.button2.TabIndex = 8;
			this.button2.Text = "Thêm mới";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(826, 147);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(67, 23);
			this.button3.TabIndex = 9;
			this.button3.Text = "Sửa";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button4
			// 
			this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button4.Location = new System.Drawing.Point(669, 355);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(212, 63);
			this.button4.TabIndex = 10;
			this.button4.Text = "In Hóa Đơn Bán Hàng Theo Bảng Giá";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// cbbGood
			// 
			this.cbbGood.FormattingEnabled = true;
			this.cbbGood.Location = new System.Drawing.Point(760, 61);
			this.cbbGood.Name = "cbbGood";
			this.cbbGood.Size = new System.Drawing.Size(133, 21);
			this.cbbGood.TabIndex = 11;
			// 
			// PriceLists
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(912, 439);
			this.Controls.Add(this.cbbGood);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.txtPrice);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.dgvPriceListDetail);
			this.Controls.Add(this.cbbCustomer);
			this.Controls.Add(this.label1);
			this.Name = "PriceLists";
			this.Text = "PriceLists";
			((System.ComponentModel.ISupportInitialize)(this.dgvPriceListDetail)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cbbCustomer;
		private System.Windows.Forms.DataGridView dgvPriceListDetail;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtPrice;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.ComboBox cbbGood;
	}
}
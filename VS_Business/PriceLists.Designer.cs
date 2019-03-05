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
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
			// 
			// dataGridView1
			// 
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(15, 65);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.Size = new System.Drawing.Size(517, 353);
			this.dataGridView1.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(551, 65);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(96, 17);
			this.label2.TabIndex = 3;
			this.label2.Text = "Mã Sản Phẩm";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(653, 65);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(135, 20);
			this.textBox1.TabIndex = 4;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(551, 104);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(58, 17);
			this.label3.TabIndex = 5;
			this.label3.Text = "Giá bán";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(653, 101);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(135, 20);
			this.textBox2.TabIndex = 6;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(554, 147);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(64, 23);
			this.button1.TabIndex = 7;
			this.button1.Text = "Trở về";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(624, 147);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(91, 23);
			this.button2.TabIndex = 8;
			this.button2.Text = "Thêm mới";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(721, 147);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(67, 23);
			this.button3.TabIndex = 9;
			this.button3.Text = "Sửa";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button4
			// 
			this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button4.Location = new System.Drawing.Point(554, 355);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(234, 63);
			this.button4.TabIndex = 10;
			this.button4.Text = "In Hóa Đơn Bán Hàng Theo Bảng Giá";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// PriceLists
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.cbbCustomer);
			this.Controls.Add(this.label1);
			this.Name = "PriceLists";
			this.Text = "PriceLists";
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cbbCustomer;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
	}
}
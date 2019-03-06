namespace VS_Business
{
    partial class BuyGood
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
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.dgvBOD = new System.Windows.Forms.DataGridView();
			this.label4 = new System.Windows.Forms.Label();
			this.txtQuantity = new System.Windows.Forms.TextBox();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.cbbCus = new System.Windows.Forms.ComboBox();
			this.cbbGood = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.button6 = new System.Windows.Forms.Button();
			this.dtpBO = new System.Windows.Forms.DateTimePicker();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dgvBOD)).BeginInit();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button1.Location = new System.Drawing.Point(542, 279);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(157, 33);
			this.button1.TabIndex = 0;
			this.button1.Text = "Xuất file excel mẫu";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button2.Location = new System.Drawing.Point(705, 279);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(148, 33);
			this.button2.TabIndex = 2;
			this.button2.Text = "Nhập đơn hàng";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// dgvBOD
			// 
			this.dgvBOD.AllowUserToAddRows = false;
			this.dgvBOD.AllowUserToDeleteRows = false;
			this.dgvBOD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvBOD.Location = new System.Drawing.Point(12, 12);
			this.dgvBOD.Name = "dgvBOD";
			this.dgvBOD.ReadOnly = true;
			this.dgvBOD.Size = new System.Drawing.Size(492, 347);
			this.dgvBOD.TabIndex = 3;
			this.dgvBOD.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBOD_CellClick);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(542, 134);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(69, 17);
			this.label4.TabIndex = 9;
			this.label4.Text = "Số Lượng";
			// 
			// txtQuantity
			// 
			this.txtQuantity.Location = new System.Drawing.Point(674, 134);
			this.txtQuantity.Name = "txtQuantity";
			this.txtQuantity.Size = new System.Drawing.Size(152, 20);
			this.txtQuantity.TabIndex = 10;
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(648, 172);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(92, 33);
			this.button3.TabIndex = 11;
			this.button3.Text = "Thêm";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(763, 172);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(90, 33);
			this.button4.TabIndex = 12;
			this.button4.Text = "Sửa";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// button5
			// 
			this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button5.Location = new System.Drawing.Point(577, 327);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(238, 39);
			this.button5.TabIndex = 13;
			this.button5.Text = "Xuất đơn đi chợ";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(542, 67);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(84, 17);
			this.label5.TabIndex = 14;
			this.label5.Text = "Khách hàng";
			// 
			// cbbCus
			// 
			this.cbbCus.FormattingEnabled = true;
			this.cbbCus.Location = new System.Drawing.Point(675, 66);
			this.cbbCus.Name = "cbbCus";
			this.cbbCus.Size = new System.Drawing.Size(151, 21);
			this.cbbCus.TabIndex = 15;
			this.cbbCus.SelectedValueChanged += new System.EventHandler(this.cbbCus_SelectedValueChanged);
			// 
			// cbbGood
			// 
			this.cbbGood.FormattingEnabled = true;
			this.cbbGood.Location = new System.Drawing.Point(674, 100);
			this.cbbGood.Name = "cbbGood";
			this.cbbGood.Size = new System.Drawing.Size(152, 21);
			this.cbbGood.TabIndex = 16;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(542, 101);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(73, 17);
			this.label2.TabIndex = 17;
			this.label2.Text = "Sản Phẩm";
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(536, 172);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(92, 33);
			this.button6.TabIndex = 18;
			this.button6.Text = "Trở về";
			this.button6.UseVisualStyleBackColor = true;
			this.button6.Click += new System.EventHandler(this.button6_Click);
			// 
			// dtpBO
			// 
			this.dtpBO.Location = new System.Drawing.Point(674, 30);
			this.dtpBO.Name = "dtpBO";
			this.dtpBO.Size = new System.Drawing.Size(151, 20);
			this.dtpBO.TabIndex = 8;
			this.dtpBO.ValueChanged += new System.EventHandler(this.dtpBO_ValueChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(541, 33);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(105, 17);
			this.label1.TabIndex = 1;
			this.label1.Text = "Đơn hàng ngày";
			// 
			// BuyGood
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(878, 384);
			this.Controls.Add(this.button6);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.cbbGood);
			this.Controls.Add(this.cbbCus);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.button5);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.txtQuantity);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.dtpBO);
			this.Controls.Add(this.dgvBOD);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button1);
			this.Name = "BuyGood";
			this.Text = "BuyGood";
			((System.ComponentModel.ISupportInitialize)(this.dgvBOD)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dgvBOD;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox cbbCus;
		private System.Windows.Forms.ComboBox cbbGood;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.DateTimePicker dtpBO;
		private System.Windows.Forms.Label label1;
	}
}
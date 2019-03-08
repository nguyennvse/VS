namespace VS_Business
{
    partial class Goods
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Goods));
			this.txtSearch = new System.Windows.Forms.TextBox();
			this.dgvGoods = new System.Windows.Forms.DataGridView();
			this.btnSearch = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.txtName = new System.Windows.Forms.TextBox();
			this.txtUnit = new System.Windows.Forms.TextBox();
			this.txtPrice = new System.Windows.Forms.TextBox();
			this.txtCode = new System.Windows.Forms.Label();
			this.txtGoodCode = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dgvGoods)).BeginInit();
			this.SuspendLayout();
			// 
			// txtSearch
			// 
			this.txtSearch.Location = new System.Drawing.Point(23, 25);
			this.txtSearch.Name = "txtSearch";
			this.txtSearch.Size = new System.Drawing.Size(368, 20);
			this.txtSearch.TabIndex = 0;
			// 
			// dgvGoods
			// 
			this.dgvGoods.AllowUserToAddRows = false;
			this.dgvGoods.AllowUserToDeleteRows = false;
			this.dgvGoods.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvGoods.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvGoods.Location = new System.Drawing.Point(23, 68);
			this.dgvGoods.Name = "dgvGoods";
			this.dgvGoods.ReadOnly = true;
			this.dgvGoods.Size = new System.Drawing.Size(508, 310);
			this.dgvGoods.TabIndex = 1;
			this.dgvGoods.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGoods_CellClick);
			this.dgvGoods.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGoods_CellContentClick);
			// 
			// btnSearch
			// 
			this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
			this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnSearch.Location = new System.Drawing.Point(397, 17);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(134, 35);
			this.btnSearch.TabIndex = 2;
			this.btnSearch.Text = "Tìm kiếm";
			this.btnSearch.UseVisualStyleBackColor = true;
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(548, 102);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(33, 17);
			this.label1.TabIndex = 3;
			this.label1.Text = "Tên";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(548, 139);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(48, 17);
			this.label2.TabIndex = 4;
			this.label2.Text = "Đơn vị";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(548, 177);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(30, 17);
			this.label3.TabIndex = 5;
			this.label3.Text = "Giá";
			// 
			// button2
			// 
			this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
			this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button2.Location = new System.Drawing.Point(551, 222);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(125, 35);
			this.button2.TabIndex = 7;
			this.button2.Text = "Sửa";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// txtName
			// 
			this.txtName.Location = new System.Drawing.Point(615, 99);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(159, 20);
			this.txtName.TabIndex = 9;
			// 
			// txtUnit
			// 
			this.txtUnit.Location = new System.Drawing.Point(615, 136);
			this.txtUnit.Name = "txtUnit";
			this.txtUnit.Size = new System.Drawing.Size(159, 20);
			this.txtUnit.TabIndex = 10;
			// 
			// txtPrice
			// 
			this.txtPrice.Location = new System.Drawing.Point(615, 174);
			this.txtPrice.Name = "txtPrice";
			this.txtPrice.Size = new System.Drawing.Size(159, 20);
			this.txtPrice.TabIndex = 11;
			// 
			// txtCode
			// 
			this.txtCode.AutoSize = true;
			this.txtCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtCode.Location = new System.Drawing.Point(548, 68);
			this.txtCode.Name = "txtCode";
			this.txtCode.Size = new System.Drawing.Size(27, 17);
			this.txtCode.TabIndex = 12;
			this.txtCode.Text = "Mã";
			// 
			// txtGoodCode
			// 
			this.txtGoodCode.Location = new System.Drawing.Point(615, 65);
			this.txtGoodCode.Name = "txtGoodCode";
			this.txtGoodCode.Size = new System.Drawing.Size(159, 20);
			this.txtGoodCode.TabIndex = 13;
			// 
			// button1
			// 
			this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
			this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button1.Location = new System.Drawing.Point(682, 222);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(125, 35);
			this.button1.TabIndex = 14;
			this.button1.Text = "Thêm mới";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click_1);
			// 
			// Goods
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(829, 401);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.txtGoodCode);
			this.Controls.Add(this.txtCode);
			this.Controls.Add(this.txtPrice);
			this.Controls.Add(this.txtUnit);
			this.Controls.Add(this.txtName);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnSearch);
			this.Controls.Add(this.dgvGoods);
			this.Controls.Add(this.txtSearch);
			this.Name = "Goods";
			this.Text = "Goods";
			this.Load += new System.EventHandler(this.Goods_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgvGoods)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dgvGoods;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtUnit;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label txtCode;
        private System.Windows.Forms.TextBox txtGoodCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn;
		private System.Windows.Forms.Button button1;
	}
}
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
	public partial class PriceLists : Form
	{
		PriceListDetailModel currentpldm = new PriceListDetailModel();
		PriceList currentPL = new PriceList();

		public PriceLists()
		{
			InitializeComponent();
			Utility.loadCustomerCBB(cbbCustomer);
			Utility.loadGoodsCBB(cbbGood);
			currentPL = getCusTomerPriceList();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Menu menuform = new Menu();
			menuform.Show();
			Hide();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			try
			{
				dynamic selectedCustomer = cbbCustomer.SelectedItem;
				int ID = int.Parse(selectedCustomer.Value.ToString());
				dynamic cbb = cbbGood.SelectedItem;
				string goodcode = cbb.Value.ToString();
				using (VB_BusinessEntities db = new VB_BusinessEntities())
				{
					if (currentPL == null)
					{
						PriceList pl = new PriceList();
						pl.CustomerID = ID;
						db.PriceLists.Add(pl);
						db.SaveChanges();
						currentPL = getCusTomerPriceList();
					}
					PriceListDetail findPLD = (from p in db.PriceListDetails
																		 where p.GoodCode == goodcode
																		 where p.PriceListID == currentPL.ID
																		 select p).SingleOrDefault();
					if (goodcode != null && findPLD == null)
					{
						PriceListDetail pld = new PriceListDetail();
						pld.PriceListID = currentPL.ID;
						pld.GoodCode = cbb.Value;
						pld.Price = int.Parse(txtPrice.Text);
						db.PriceListDetails.Add(pld);
						db.SaveChanges();
					}

				}
				bindDataToDGV();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.StackTrace);
			}

		}

		private void button3_Click(object sender, EventArgs e)
		{
			try
			{
				if (currentPL != null)
				{
					dynamic cbb = cbbGood.SelectedItem;
					string goodcode = cbb.Value.ToString();
					if (goodcode != null)
					{
						using (VB_BusinessEntities db = new VB_BusinessEntities())
						{
							PriceListDetail findPLD = (from p in db.PriceListDetails
																				 where p.GoodCode == goodcode && p.PriceListID == currentPL.ID
																				 select p).SingleOrDefault();
							if (findPLD != null && txtPrice.Text != null)
							{
								findPLD.Price = int.Parse(txtPrice.Text);
								db.SaveChanges();
							}
						}
					}
				}
				bindDataToDGV();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.StackTrace);
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			var dtp = this.dtpPrint.Value;
			var dayPrint = new DateTime(dtp.Year, dtp.Month, dtp.Day);
			dynamic cbbCus = cbbCustomer.SelectedItem;
			int cusID = int.Parse(cbbCus.Value.ToString());
			var Renderer = new IronPdf.HtmlToPdf();
			var HtmlTemplate = @"
<html !Doctype>
<head>
  <style>
    .cus_info {
      width: 100%;
    }

    .cus_info>div {
	  float:left;
      width: 50%;
    }

    body {
      size: 8.27in 11.69in; 
    margin: .5in .5in .5in .5in; 
    }

    .title {
      font-weight: bold;
      text-align: center;
    }
    
    .bg-blue{
      background-color:aquamarine;
    }

    .good_tb {
      width: 100%;
      border-collapse: collapse;
    }

    .good_tb tr td{
      border:1px solid black;
    }
	
		.clear{
		clear: both;
		}

		.txt-c{
		text-align:center;
		}

		.txt-l{
		text-align:left;
		}

		.txt-r{
		text-align:right;
		}

		.footer{
				width:100%;
		}

    .footer div p{
      float:left;
      width:50%;
      text-align: center;
    }
  </style>
</head>

<body>
  <section class=""cus_info"">
	<div>
	<p><b> TRỨNG VIỆT SẠCH</b ></p>
	<p><i> ĐT: 0971.153.153 - 098.22.00.789 </i></p>
	</div>
	<div class=""txt-c"">
	<p><b> Số:19.03.05 </b></p>
	</div>
	</section>
	<div class=""clear""></div>
				 <p class=""title"">PHIẾU GIAO HÀNG</p>
  <p class=""title"">Ngày:03-05-2019</p>
  <p><b>KHÁCH HÀNG: [customerCompany]</b></p>
  <section>
    <table class=""good_tb"">
      <tr class=""bg-blue"">
        <td>STT</td>
        <td>TÊN HÀNG</td>
        <td>ĐVT</td>
        <td>SL</td>
        <td>ĐƠN GIÁ</td>
        <td>THÀNH TIỀN</td>
        <td>GHI CHÚ</td>
      </tr>
      [dataTable]
		<tr>
		<td></td>
		<td>Tổng cộng</td>
		<td></td>
		<td class='txt-r'>[totalQuantity]</td>
		<td></td>
		<td class='txt-r'>[totalBill]</td>
		<td></td>
		</tr>
    </table>
  </section>
  <section class=""footer"">
	<p><b>Ghi chú: 252BC Lê Thánh Tôn, Phường Bến Thành, Quận 1 </b></p>
		 <div>
			<p><b> BÊN GIAO HÀNG<br/><br/><br/><br/><br/> Vương Thị Thắm</b></p>
			<p><b> BÊN NHẬN HÀNG<br/><br/><br/><br/><br/>[customerName]</b></p>
		</div>
	</section>
</body>
</html>
		";
			try
			{
				using (VB_BusinessEntities db = new VB_BusinessEntities())
				{
					var listBuyOrderDetail = (from bod in db.BuyOrderDetails
																		join bo in db.BuyOrders on bod.OrderID equals bo.ID
																		join good in db.Goods on bod.GoodCode equals good.Code
																		join person in db.PersonalInfoes on bo.CustomerID equals person.ID
																		join pl in db.PriceLists on cusID equals pl.CustomerID
																		join pld in db.PriceListDetails on pl.ID equals pld.PriceListID
																		where bo.CustomerID == cusID
																		where bod.GoodCode == pld.GoodCode
																		where bo.Day == dayPrint
																		select new { bod, good, person, pld }).ToList();
					var listBDO = new List<dynamic>();
					var data = "";
					int totalQuantity = 0;
					int totalBill = 0;
					if (listBuyOrderDetail.Count > 0)
					{
						for (int i = 0; i < listBuyOrderDetail.Count; i++)
						{
							dynamic bdo = new System.Dynamic.ExpandoObject();
							bdo.code = listBuyOrderDetail[i].bod.GoodCode;
							bdo.customername = listBuyOrderDetail[i].person.Name;
							bdo.goodname = listBuyOrderDetail[i].good.Name;
							bdo.unit = listBuyOrderDetail[i].good.Unit;
							bdo.quantity = listBuyOrderDetail[i].bod.Quantity;
							totalQuantity += (int)listBuyOrderDetail[i].bod.Quantity;
							bdo.price = listBuyOrderDetail[i].pld.Price;
							bdo.total = listBuyOrderDetail[i].pld.Price * listBuyOrderDetail[i].bod.Quantity;
							totalBill += (int)(listBuyOrderDetail[i].good.Price * listBuyOrderDetail[i].bod.Quantity);
							if (listBDO.Count > 0)
							{
								int findGood = listBDO.FindIndex(good => good.code == listBuyOrderDetail[i].bod.GoodCode);
								if (findGood != -1)
								{
									listBDO[findGood].quantity += listBuyOrderDetail[i].bod.Quantity;
								}
								else
								{
									listBDO.Add(bdo);
								}
							}
							else
							{
								listBDO.Add(bdo);
							}

						}
						for (int i = 0; i < listBDO.Count; i++)
						{
							data +=
								"<tr>"
								+ "<td class='txt-c'>" + (i + 1) + "</td>"
								+ "<td>" + listBDO[i].goodname + "</td>"
								+ "<td>" + listBDO[i].unit + "</td>"
								+ "<td class='txt-r'>" + String.Format("{0:n0}", listBDO[i].quantity) + "</td>"
								+ "<td class='txt-r'>" + String.Format("{0:n0}", listBDO[i].price) + "</td>"
								+ "<td class='txt-r'>" + String.Format("{0:n0}", listBDO[i].price * listBDO[i].quantity) + "</td>"
								+ "<td></td>"
								+ "</tr>";
						}
						HtmlTemplate = HtmlTemplate.Replace("[dataTable]", data);
						HtmlTemplate = HtmlTemplate.Replace("[customerCompany]", listBuyOrderDetail[0].person.Company);
						HtmlTemplate = HtmlTemplate.Replace("[customerName]", listBuyOrderDetail[0].person.Name);
						HtmlTemplate = HtmlTemplate.Replace("[totalQuantity]", String.Format("{0:n0}", totalQuantity));
						HtmlTemplate = HtmlTemplate.Replace("[totalBill]", String.Format("{0:n0}", totalBill));
						var PDF = Renderer.RenderHtmlAsPdf(HtmlTemplate, @"D:\");
						var OutputPath = @"D:\don_hang_" + listBuyOrderDetail[0].person.Name + ".pdf";
						PDF.SaveAs(OutputPath);
						System.Diagnostics.Process.Start(OutputPath);
					}

				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.StackTrace);
			}
		}

		private void cbbCustomer_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				currentPL = getCusTomerPriceList();
				bindDataToDGV();
			}
			catch (Exception ex)
			{
				Console.Write(ex.StackTrace);
			}

		}

		private PriceList getCusTomerPriceList()
		{
			try
			{
				dynamic cbb = cbbCustomer.SelectedItem;
				int? cusID = int.Parse(cbb.Value.ToString());
				if (cbb != null)
				{
					using (VB_BusinessEntities db = new VB_BusinessEntities())
					{
						var pl = (from u in db.PriceLists where u.CustomerID == cusID select u).SingleOrDefault();
						if (pl == null)
						{
							PriceList newpl = new PriceList();
							newpl.CustomerID = cusID;
							db.PriceLists.Add(newpl);
							db.SaveChanges();
							return newpl;
						}
						else
						{
							return pl;
						}
					}
				}
				return null;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.StackTrace);
				return null;
			}
		}

		private List<PriceListDetailModel> getCustomerPrilistDetail()
		{
			try
			{
				if (currentPL != null)
				{
					List<PriceListDetailModel> result = new List<PriceListDetailModel>();
					using (VB_BusinessEntities db = new VB_BusinessEntities())
					{
						var listPD = (from p in db.PriceListDetails
													join g in db.Goods
													on p.GoodCode equals g.Code
													where p.PriceListID == currentPL.ID
													select new { p, g }).ToList();
						if (listPD != null)
						{
							foreach (var pd in listPD)
							{
								PriceListDetailModel pldm = new PriceListDetailModel(pd.g.Name, (int)pd.p.Price, pd.p.GoodCode, pd.p.ID);
								result.Add(pldm);
							}
							return result;
						}
					}
				}
				return null;
			}
			catch (Exception ex)
			{
				Console.Write(ex.StackTrace);
				return null;
			}
		}

		private void setting()
		{
			dgvPriceListDetail.RowTemplate.Height = 30;
			DataGridViewTextBoxColumn column1 = new DataGridViewTextBoxColumn();
			column1.Name = "namecl";
			column1.HeaderText = "Tên sản phẩm";
			column1.DataPropertyName = "name";
			dgvPriceListDetail.Columns.Add(column1);

			DataGridViewTextBoxColumn column2 = new DataGridViewTextBoxColumn();
			column2.Name = "pricecl";
			column2.HeaderText = "Giá";
			column2.DataPropertyName = "price";
			dgvPriceListDetail.Columns.Add(column2);

			DataGridViewImageColumn column3 = new DataGridViewImageColumn();
			column3.Name = "Delete";
			column3.HeaderText = "Xóa";
			column3.Width = 40;
			column3.Image = Properties.Resources.icons8_trash_can_32;
			dgvPriceListDetail.Columns.Add(column3);

			this.dgvPriceListDetail.Columns["ID"].Visible = false;
			this.dgvPriceListDetail.Columns["name"].Visible = false;
			this.dgvPriceListDetail.Columns["price"].Visible = false;
			this.dgvPriceListDetail.Columns["code"].Visible = false;
			this.dgvPriceListDetail.Columns["namecl"].Width = 300;
			this.dgvPriceListDetail.Columns["pricecl"].Width = 150;

			this.dtpPrint.Format = DateTimePickerFormat.Custom;
			this.dtpPrint.CustomFormat = "dd/MM/yyyy";
		}

		private void dgvPriceListDetail_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				DataGridViewRow row = dgvPriceListDetail.Rows[e.RowIndex];
				if (e.ColumnIndex != 0)
				{
					currentpldm.name = row.Cells[1].Value.ToString();
					currentpldm.price = int.Parse(row.Cells[2].Value.ToString());
					currentpldm.code = row.Cells[3].Value.ToString();
					currentpldm.id = int.Parse(row.Cells[4].Value.ToString());
					viewDetail();
				}
				else
				{
					deletePriceListDetail(int.Parse(row.Cells[4].Value.ToString()));
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.StackTrace);
			}
		}

		private void viewDetail()
		{
			int index = cbbGood.FindStringExact(currentpldm.name);
			cbbGood.SelectedIndex = index;
			txtPrice.Text = currentpldm.price.ToString();
		}

		private void editPriceListDetail()
		{
			if (currentPL != null)
			{
				try
				{
					using (VB_BusinessEntities db = new VB_BusinessEntities())
					{
						PriceListDetail plm = (from p in db.PriceListDetails
																	 where p.PriceListID == currentPL.ID
																	 select p).SingleOrDefault();
						if (plm != null && txtPrice.Text != null)
						{
							plm.Price = int.Parse(txtPrice.Text.ToString());
							db.SaveChanges();
							getCustomerPrilistDetail();
						}
					}
				}
				catch (Exception ex)
				{
					Console.Write(ex.StackTrace);
				}
			}
		}

		private void deletePriceListDetail(int ID)
		{
			try
			{
				using (VB_BusinessEntities db = new VB_BusinessEntities())
				{
					PriceListDetail plm = (from p in db.PriceListDetails
																 where p.ID == ID
																 select p).SingleOrDefault();
					if (plm != null)
					{
						db.PriceListDetails.Remove(plm);
						db.SaveChanges();
						getCustomerPrilistDetail();
					}
				}
			}
			catch (Exception ex)
			{
				Console.Write(ex.StackTrace);
			}
		}

		private void bindDataToDGV()
		{
			var list = new BindingList<PriceListDetailModel>(getCustomerPrilistDetail());
			dgvPriceListDetail.Columns.Clear();
			if (list != null && list.Count > 0)
			{
				var source = new BindingSource(list, null);
				dgvPriceListDetail.DataSource = source;
				setting();
			}
			else
			{
				dgvPriceListDetail.DataSource = null;
			}
		}
	}
}

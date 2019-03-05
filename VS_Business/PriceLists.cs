using System;
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
	public partial class PriceLists : Form
	{
		public PriceLists()
		{
			InitializeComponent();
			Utility.loadCustomerCBB(cbbCustomer);
		}

		private void button1_Click(object sender, EventArgs e)
		{

		}

		private void button2_Click(object sender, EventArgs e)
		{

		}

		private void button3_Click(object sender, EventArgs e)
		{

		}

		private void button4_Click(object sender, EventArgs e)
		{
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
											  join good in db.Goods
											  on bod.GoodCode equals good.Code
											  join person in db.PersonalInfoes
											  on bod.CustomerID equals person.ID
											  where bod.CustomerID == 1
											  select new { bod, good, person }).ToList();
					var listBDO = new List<dynamic>();
					var data = "";
					int totalQuantity = 0;
					int totalBill = 0;
					for (int i = 0; i < listBuyOrderDetail.Count; i++)
					{
						dynamic bdo = new System.Dynamic.ExpandoObject();
						bdo.code = listBuyOrderDetail[i].bod.GoodCode;
						bdo.customername = listBuyOrderDetail[i].person.Name;
						bdo.goodname = listBuyOrderDetail[i].good.Name;
						bdo.unit = listBuyOrderDetail[i].good.Unit;
						bdo.quantity = listBuyOrderDetail[i].bod.Quantity;
						totalQuantity += (int)listBuyOrderDetail[i].bod.Quantity;
						bdo.price = listBuyOrderDetail[i].good.Price;
						bdo.total = listBuyOrderDetail[i].good.Price * listBuyOrderDetail[i].bod.Quantity;
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
			catch (Exception ex)
			{
				Console.WriteLine(ex.StackTrace);
			}
		}
	}
}

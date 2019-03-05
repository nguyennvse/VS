using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Application = Microsoft.Office.Interop.Excel.Application;

namespace VS_Business
{
	public partial class BuyGood : Form
	{

		public BuyGood()
		{
			InitializeComponent();
			Utility.loadCustomerCBB(cbbCus);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				using (VB_BusinessEntities db = new VB_BusinessEntities())
				{
					var listGoods = (from u in db.Goods select u).ToList();
					//var listCus = (from u in db.Personal_Info where u.Type == 1  select u).ToList();
					Application xlApp = new Application();
					Workbook xlWorkBook;
					Worksheet xlWorkSheet;
					object misValue = System.Reflection.Missing.Value;
					xlWorkBook = xlApp.Workbooks.Add(misValue);
					xlWorkSheet = (Worksheet)xlWorkBook.Worksheets.get_Item(1);
					xlWorkSheet.Cells[1, 1] = "Mã Sản Phẩm";
					xlWorkSheet.Cells[1, 2] = "Tên";
					xlWorkSheet.Cells[1, 3] = "Số lượng";
					for (int i = 0; i < listGoods.Count; i++)
					{
						xlWorkSheet.Cells[i + 2, 1] = listGoods[i].Code;
						xlWorkSheet.Cells[i + 2, 2] = listGoods[i].Name;
					}

					//for (int i = 0; i < listCus.Count; i++)
					//{
					//	xlWorkSheet.Cells[1, i+4] = listCus[i].Name + "-" + listCus[i].ID;
					//}
					xlWorkBook.SaveAs("D:\\don_hang_mau.xlsx", XlFileFormat.xlOpenXMLWorkbook, misValue,
					   misValue, misValue, misValue, XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);

					xlWorkBook.Close(true, misValue, misValue);
					xlApp.Quit();

					Marshal.ReleaseComObject(xlWorkSheet);
					Marshal.ReleaseComObject(xlWorkBook);
					Marshal.ReleaseComObject(xlApp);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.StackTrace);
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			BuyOrder todayBO = createBuyOrder();
			var fileContent = string.Empty;
			var filePath = string.Empty;

			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				openFileDialog.InitialDirectory = "d:\\";
				openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
				openFileDialog.FilterIndex = 2;
				openFileDialog.RestoreDirectory = true;

				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					filePath = openFileDialog.FileName;

					dynamic model = cbbCus.SelectedItem;
					if (todayBO != null && model != null)
					{
						Application xlApp;
						Workbook xlWorkBook;
						Worksheet xlWorkSheet;
						Range range;
						xlApp = new Application();
						xlWorkBook = xlApp.Workbooks.Open(filePath, 0, true, 5, "", "", true, XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
						xlWorkSheet = (Worksheet)xlWorkBook.Worksheets.get_Item(1);
						range = xlWorkSheet.UsedRange;
						for (int i = 2; i <= range.Rows.Count - 1; i++)
						{
							string code = (string)(range.Cells[i, 1] as Range).Value;
							string name = (string)(range.Cells[i, 2] as Range).Value;
							int price = (int)(range.Cells[i, 3] as Range).Value;
							int quantity = (int)(range.Cells[i, 4] as Range).Value;
							createBuyOrderDetail(code, name, quantity, price, todayBO.ID, model.Value);
						}
						xlWorkBook.Close(true, null, null);
						xlApp.Quit();
						Marshal.ReleaseComObject(xlWorkSheet);
						Marshal.ReleaseComObject(xlWorkBook);
						Marshal.ReleaseComObject(xlApp);
					}
				}
			}
		}

		private BuyOrder createBuyOrder()
		{
			try
			{
				using (VB_BusinessEntities db = new VB_BusinessEntities())
				{
					DateTime today = DateTime.Today;
					var todayBuyOrder = (from u in db.BuyOrders where u.Day == today select u).SingleOrDefault();
					if (todayBuyOrder == null)
					{
						BuyOrder bo = new BuyOrder();
						bo.Day = today;
						bo.Total = 0;
						db.BuyOrders.Add(bo);
						db.SaveChanges();
						return bo;
					}
					else
					{
						return todayBuyOrder;
					}
				}
			}
			catch (Exception ex)
			{
				Console.Write(ex.StackTrace);
				return null;
			}
		}

		private void createBuyOrderDetail(string goodCode, string goodName, int quantity, int price, int orderID, int cusID)
		{
			try
			{
				using (VB_BusinessEntities db = new VB_BusinessEntities())
				{
					BuyOrderDetail buyOrderDetail = new BuyOrderDetail();
					buyOrderDetail.GoodCode = goodCode;
					buyOrderDetail.Quantity = quantity;
					buyOrderDetail.ID = orderID;
					buyOrderDetail.CustomerID = cusID;
					db.BuyOrderDetails.Add(buyOrderDetail);
					db.SaveChanges();
				}
			}
			catch (Exception ex)
			{
				Console.Write(ex.StackTrace);
			}
			
		}

		

		private void button5_Click(object sender, EventArgs e)
		{
			try
			{
				BuyOrder todayBO = createBuyOrder();
				using (VB_BusinessEntities db = new VB_BusinessEntities())
				{
					var listGoods = (from u in db.Goods select u).ToList();
					var listBuyOrderDetail = (from bod in db.BuyOrderDetails
											  join good in db.Goods
											  on bod.GoodCode equals good.Code
											  join person in db.PersonalInfoes
											  on bod.CustomerID equals person.ID
											  where bod.OrderID == todayBO.ID
											  select new { bod, good, person }).ToList();
					object[,] exportData = new object[listGoods.Count + 1, listBuyOrderDetail.Count];
					exportData[0, 0] = "Mã Sản Phẩm";
					exportData[0, 1] = "Tên";
					exportData[0, 2] = "Giá";
					exportData[0, 3] = "Số lượng";
					exportData[0, 4] = "Tổng";
					var listGood = new List<dynamic>();
					var listCus = new List<dynamic>();
					var cusGoodMapping = new List<dynamic>();
					var listBOD = new List<dynamic>();
					for (int i = 0; i < listBuyOrderDetail.Count; i++)
					{
						dynamic g = new System.Dynamic.ExpandoObject();
						g.quantity = listBuyOrderDetail[i].bod.Quantity;
						g.code = listBuyOrderDetail[i].bod.GoodCode;
						g.name = listBuyOrderDetail[i].good.Name;
						g.price = listBuyOrderDetail[i].good.Price;
						if (listGood.Count > 0)
						{
							int findGood = listGood.FindIndex(good => good.code == listBuyOrderDetail[i].bod.GoodCode);
							if (findGood > -1)
							{
								listGood[findGood].quantity += listBuyOrderDetail[i].bod.Quantity;
							}
							else
							{
								listGood.Add(g);
							}
						}
						else
						{
							listGood.Add(g);
						}

						dynamic c = new System.Dynamic.ExpandoObject();
						c.id = listBuyOrderDetail[i].bod.CustomerID;
						c.name = listBuyOrderDetail[i].person.Name;
						c.goodcode = listBuyOrderDetail[i].bod.GoodCode;
						c.quantity = listBuyOrderDetail[i].bod.Quantity;
						if (listCus.Count  != -1)
						{
							int findCus = listCus.FindIndex(cus => cus.id == listBuyOrderDetail[i].bod.CustomerID);
							if (findCus == -1)
							{
								listCus.Add(c);
							}
						}
						else
						{
							listCus.Add(c);
						}

						dynamic b = new System.Dynamic.ExpandoObject();
						b.goodcode = listBuyOrderDetail[i].bod.GoodCode;
						b.quantity = listBuyOrderDetail[i].bod.Quantity;
						b.customerid = listBuyOrderDetail[i].bod.CustomerID;
						if (listBOD.Count > 0)
						{
							int findBOD = listBOD.FindIndex(bod => bod.goodcode == listBuyOrderDetail[i].bod.GoodCode && bod.customerid == listBuyOrderDetail[i].bod.CustomerID);
							if (findBOD == -1)
							{
								listBOD.Add(b);
							}
							else
							{
								listBOD[findBOD].quantity += listBuyOrderDetail[i].bod.Quantity;
							}
						}
						else
						{
							listBOD.Add(b);
						}
					}


					Application xlApp = new Application();
					Workbook xlWorkBook;
					Worksheet xlWorkSheet;
					object misValue = System.Reflection.Missing.Value;
					xlWorkBook = xlApp.Workbooks.Add(misValue);
					xlWorkSheet = (Worksheet)xlWorkBook.Worksheets.get_Item(1);
					xlWorkSheet.Cells[1, 1] = "Mã Sản Phẩm";
					xlWorkSheet.Cells[1, 2] = "Tên";
					xlWorkSheet.Cells[1, 3] = "Giá";
					xlWorkSheet.Cells[1, 4] = "Số lượng";
					xlWorkSheet.Cells[1, 5] = "Tổng";
					for (int i = 0; i < listCus.Count; i++)
					{
						xlWorkSheet.Cells[1, i + 6] = listCus[i].name;
						dynamic cgm = new System.Dynamic.ExpandoObject();
						cgm.id = listCus[i].id;
						cgm.index = i + 6;
						cusGoodMapping.Add(cgm);
					}
					
					for (int i = 0; i < listGood.Count; i++)
					{
						xlWorkSheet.Cells[i + 2, 1] = listGood[i].code;
						xlWorkSheet.Cells[i + 2, 2] = listGood[i].name;
						xlWorkSheet.Cells[i + 2, 3] = listGood[i].price;
						xlWorkSheet.Cells[i + 2, 4] = listGood[i].quantity;
						xlWorkSheet.Cells[i + 2, 5] = listGood[i].quantity * listGood[i].price;
						foreach(dynamic bod in listBOD)
						{
							if(bod.goodcode == listGood[i].code)
							{
								foreach (dynamic cgm in cusGoodMapping)
								{
									if(cgm.id == bod.customerid)
									{
										xlWorkSheet.Cells[i + 2, cgm.index] = bod.quantity;
									}
								}
							}
						}
					}
					xlWorkBook.SaveAs("D:\\don_hang.xlsx", XlFileFormat.xlOpenXMLWorkbook, misValue,
					   misValue, misValue, misValue, XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
					xlWorkBook.Close(true, misValue, misValue);
					xlApp.Quit();

					Marshal.ReleaseComObject(xlWorkSheet);
					Marshal.ReleaseComObject(xlWorkBook);
					Marshal.ReleaseComObject(xlApp);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.StackTrace);
			}
		}
	}
}

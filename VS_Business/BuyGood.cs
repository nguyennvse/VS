﻿using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using VS_Business.Model;
using Application = Microsoft.Office.Interop.Excel.Application;

namespace VS_Business
{
	public partial class BuyGood : Form
	{
		BuyOrder currentBO = new BuyOrder();
		BuyOrderDetail currentBOD = new BuyOrderDetail();

		public BuyGood()
		{
			InitializeComponent();
			Utility.loadCustomerCBB(cbbCus);
			Utility.loadGoodsCBB(cbbGood);
			this.dtpBO.Format = DateTimePickerFormat.Custom;
			this.dtpBO.CustomFormat = "dd/MM/yyyy";
			currentBO = getCurrentCustomerBuyOrder();
			loadDGVData();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				using (VB_BusinessEntities db = new VB_BusinessEntities())
				{
					var listGoods = (from u in db.Goods where u.isDelete == 0 select u).ToList();
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
						xlWorkSheet.Cells[i + 2, 3] = 0;
					}
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

			var fileContent = string.Empty;
			var filePath = string.Empty;

			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				BuyOrder cusBO = getCurrentCustomerBuyOrder(true);
				openFileDialog.InitialDirectory = "D:\\";
				openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
				openFileDialog.FilterIndex = 2;
				openFileDialog.RestoreDirectory = true;
				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					filePath = openFileDialog.FileName;
					if (cusBO != null)
					{
						cusBO = getCurrentCustomerBuyOrder();
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
							int quantity = (int)(range.Cells[i, 3]).Value;
							if (quantity > 0)
							{
								createBuyOrderDetail(code, quantity, cusBO.ID);
							}
							
						}
						xlWorkBook.Close(true, null, null);
						xlApp.Quit();
						Marshal.ReleaseComObject(xlWorkSheet);
						Marshal.ReleaseComObject(xlWorkBook);
						Marshal.ReleaseComObject(xlApp);
					}
				}
			}
			loadDGVData();
		}

		private void createBuyOrderDetail(string goodCode, int quantity, int orderID)
		{
			try
			{
				using (VB_BusinessEntities db = new VB_BusinessEntities())
				{
					BuyOrderDetail findBOD = (from bod in db.BuyOrderDetails
																		where bod.OrderID == orderID
																		where bod.GoodCode == goodCode
																		select bod).SingleOrDefault();
					if (findBOD != null)
					{
						findBOD.Quantity += quantity;
					}
					else
					{
						BuyOrderDetail buyOrderDetail = new BuyOrderDetail();
						buyOrderDetail.GoodCode = goodCode;
						buyOrderDetail.Quantity = quantity;
						buyOrderDetail.OrderID = orderID;
						buyOrderDetail.isDelete = 0;
						db.BuyOrderDetails.Add(buyOrderDetail);
					}
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
				
				using (VB_BusinessEntities db = new VB_BusinessEntities())
				{
					DateTime today = new DateTime(DateTime.Now.Year,DateTime.Now.Month,DateTime.Now.Day);
					List<BuyOrder> listTodayBO = (from bo in db.BuyOrders where bo.Day == today select bo).ToList(); ;
					Application xlApp = new Application();
					Workbook xlWorkBook;
					Worksheet xlWorkSheet;
					object misValue = System.Reflection.Missing.Value;
					xlWorkBook = xlApp.Workbooks.Add(misValue);
					xlWorkSheet = (Worksheet)xlWorkBook.Worksheets.get_Item(1);
					xlWorkSheet.Cells[1, 1] = "Mã Sản Phẩm";
					xlWorkSheet.Cells[1, 2] = "Tên";
					xlWorkSheet.Cells[1, 3] = "Số lượng";
					var listGood = new List<dynamic>();
					var listCus = new List<dynamic>();
					var cusGoodMapping = new List<dynamic>();
					var listBOD = new List<dynamic>();
					foreach (BuyOrder todayBO in listTodayBO)
					{
						var listBuyOrderDetail = (from bod in db.BuyOrderDetails
																			join good in db.Goods on bod.GoodCode equals good.Code
																			join bo in db.BuyOrders on bod.OrderID equals bo.ID
																			join person in db.PersonalInfoes on bo.CustomerID equals person.ID
																			where bod.OrderID == todayBO.ID
																			select new { bod, good, person, bo }).ToList();
						
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
							c.id = listBuyOrderDetail[i].bo.CustomerID;
							c.name = listBuyOrderDetail[i].person.Name;
							c.goodcode = listBuyOrderDetail[i].bod.GoodCode;
							c.quantity = listBuyOrderDetail[i].bod.Quantity;
							if (listCus.Count != -1)
							{
								int findCus = listCus.FindIndex(cus => cus.id == listBuyOrderDetail[i].bo.CustomerID);
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
							b.customerid = listBuyOrderDetail[i].bo.CustomerID;
							if (listBOD.Count > 0)
							{
								int findBOD = listBOD.FindIndex(bod => bod.goodcode == listBuyOrderDetail[i].bod.GoodCode && bod.customerid == listBuyOrderDetail[i].bo.CustomerID);
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
					}
					for (int i = 0; i < listCus.Count; i++)
					{
						xlWorkSheet.Cells[1, i + 4] = listCus[i].name;
						dynamic cgm = new System.Dynamic.ExpandoObject();
						cgm.id = listCus[i].id;
						cgm.index = i + 4;
						cusGoodMapping.Add(cgm);
					}

					for (int i = 0; i < listGood.Count; i++)
					{
						xlWorkSheet.Cells[i + 2, 1] = listGood[i].code;
						xlWorkSheet.Cells[i + 2, 2] = listGood[i].name;
						xlWorkSheet.Cells[i + 2, 3] = listGood[i].quantity;
						foreach (dynamic bod in listBOD)
						{
							if (bod.goodcode == listGood[i].code)
							{
								foreach (dynamic cgm in cusGoodMapping)
								{
									if (cgm.id == bod.customerid)
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

		private void button6_Click(object sender, EventArgs e)
		{
			Menu menuform = new Menu();
			menuform.Show();
			Hide();
		}

		private void loadDGVData()
		{
			try
			{
				var dtp = this.dtpBO.Value;
				int cusID = int.Parse(Utility.getCbbValue(cbbCus));
				DateTime bodDay = new DateTime(this.dtpBO.Value.Year, this.dtpBO.Value.Month, this.dtpBO.Value.Day);
				using (VB_BusinessEntities db = new VB_BusinessEntities())
				{
					var listBDO = (from bdo in db.BuyOrderDetails
												 join bo in db.BuyOrders on bdo.OrderID equals bo.ID
												 join g in db.Goods on bdo.GoodCode equals g.Code
												 where bo.CustomerID == cusID
												 where bo.Day == bodDay
												 select new { bdo, g }).ToList();
					if (listBDO.Count > 0)
					{
						List<BDOListModel> result = new List<BDOListModel>();
						dgvBOD.Columns.Clear();
						foreach (var bod in listBDO)
						{
							BDOListModel bdoModel = new BDOListModel();
							bdoModel.id = bod.bdo.ID;
							bdoModel.name = bod.g.Name;
							bdoModel.quantity = (int)bod.bdo.Quantity;
							bdoModel.goodcode = bod.bdo.GoodCode;
							result.Add(bdoModel);

						}
						var list = new BindingList<BDOListModel>(result);
						var source = new BindingSource(list, null);
						dgvBOD.DataSource = list;
						setting();
					}
					else
					{
						dgvBOD.DataSource = null;
					}
				}

			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.StackTrace);
			}
		}

		private BuyOrder getCurrentCustomerBuyOrder(bool needCreateNew = false)
		{
			try
			{
				int cusID = int.Parse(Utility.getCbbValue(cbbCus));
				DateTime bodDay = new DateTime(this.dtpBO.Value.Year, this.dtpBO.Value.Month, this.dtpBO.Value.Day);
				using (VB_BusinessEntities db = new VB_BusinessEntities())
				{
					BuyOrder findbo = (from bo in db.BuyOrders
														 where bo.CustomerID == cusID
														 where bo.Day == bodDay
														 select bo).SingleOrDefault();
					if (findbo != null)
					{
						return findbo;
					}

					if (findbo == null && needCreateNew == true)
					{
						BuyOrder newBO = new BuyOrder();
						newBO.Day = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
						newBO.CustomerID = cusID;
						newBO.isDelete = 0;
						BuyOrder newBOa = db.BuyOrders.Add(newBO);
						db.SaveChanges();
						return newBO;
					}
				}
				return null;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
				return null;
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			try
			{
				if(currentBO == null)
				{
					currentBO = getCurrentCustomerBuyOrder(true);
				}
				createBuyOrderDetail(Utility.getCbbValue(cbbGood), int.Parse(txtQuantity.Text), currentBO.ID);
				loadDGVData();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}

		}

		private void button4_Click(object sender, EventArgs e)
		{
			editBOD();
			loadDGVData();
		}

		private void setting()
		{
			dgvBOD.RowTemplate.Height = 30;
			DataGridViewTextBoxColumn column1 = new DataGridViewTextBoxColumn();
			column1.Name = "namecl";
			column1.HeaderText = "Tên sản phẩm";
			column1.DataPropertyName = "name";
			dgvBOD.Columns.Add(column1);

			DataGridViewTextBoxColumn column2 = new DataGridViewTextBoxColumn();
			column2.Name = "quantitycl";
			column2.HeaderText = "Số lượng";
			column2.DataPropertyName = "quantity";
			dgvBOD.Columns.Add(column2);

			DataGridViewImageColumn column3 = new DataGridViewImageColumn();
			column3.Name = "Delete";
			column3.HeaderText = "Xóa";
			column3.Width = 40;
			column3.Image = Properties.Resources.icons8_trash_can_32;
			dgvBOD.Columns.Add(column3);

			this.dgvBOD.Columns["id"].Visible = false;
			this.dgvBOD.Columns["name"].Visible = false;
			this.dgvBOD.Columns["goodcode"].Visible = false;
			this.dgvBOD.Columns["quantity"].Visible = false;
			this.dgvBOD.Columns["namecl"].Width = 200;
			this.dgvBOD.Columns["quantitycl"].Width = 100;

			this.dtpBO.Format = DateTimePickerFormat.Custom;
			this.dtpBO.CustomFormat = "dd/MM/yyyy";
		}

		private void cbbCus_SelectedValueChanged(object sender, EventArgs e)
		{
			loadDGVData();
			currentBO = getCurrentCustomerBuyOrder();
		}

		private void dtpBO_ValueChanged(object sender, EventArgs e)
		{
			loadDGVData();
			currentBO = getCurrentCustomerBuyOrder();
		}

		private void dgvBOD_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				DataGridViewRow row = dgvBOD.Rows[e.RowIndex];
				if (e.ColumnIndex != 6)
				{
					currentBOD.ID = int.Parse(row.Cells[0].Value.ToString());
					currentBOD.Quantity = int.Parse(row.Cells[5].Value.ToString());
					currentBOD.GoodCode = row.Cells[3].Value.ToString();
					viewDetail(row.Cells[5].Value.ToString(), row.Cells[4].Value.ToString());
				}
				else
				{
					deleteBOD(int.Parse(row.Cells[0].Value.ToString()));
					loadDGVData();
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.StackTrace);
			}
		}

		private void deleteBOD(int id)
		{
			try
			{
				using (VB_BusinessEntities db = new VB_BusinessEntities())
				{
					BuyOrderDetail findBOD = (from bod in db.BuyOrderDetails
																		where bod.ID == id
																		select bod).SingleOrDefault();
					db.BuyOrderDetails.Remove(findBOD);
					db.SaveChanges();
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.StackTrace);
			}
		}

		private void viewDetail(string quantity, string goodname)
		{
			int findGoodIndex = cbbGood.FindStringExact(goodname);
			cbbGood.SelectedIndex = findGoodIndex;
			txtQuantity.Text = quantity;
		}

		private void editBOD()
		{
			try
			{
				using (VB_BusinessEntities db = new VB_BusinessEntities())
				{
					BuyOrderDetail findBOD = (from bod in db.BuyOrderDetails
																		where bod.ID == currentBOD.ID
																		select bod).SingleOrDefault();
					if (txtQuantity.Text != null)
					{
						findBOD.Quantity = int.Parse(txtQuantity.Text);
						db.SaveChanges();
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.StackTrace);
			}
		}
	}
}

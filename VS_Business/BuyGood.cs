using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Application = Microsoft.Office.Interop.Excel.Application;

namespace VS_Business
{
    public partial class BuyGood : Form
    {
        public BuyGood()
        {
            InitializeComponent();
            createBuyOrder();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (VB_BusinessEntities db = new VB_BusinessEntities())
                {
                    var listGoods = (from u in db.Goods select u).ToList();
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
                    for (int i = 0; i < listGoods.Count; i++)
                    {
                        xlWorkSheet.Cells[i + 2, 1] = listGoods[i].Code;
                        xlWorkSheet.Cells[i + 2, 2] = listGoods[i].Name;
                        xlWorkSheet.Cells[i + 2, 3] = listGoods[i].Price;
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

        private void button2_Click(object sender, EventArgs e)
        {

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
                    BuyOrder todayBO = createBuyOrder();
                    if (todayBO != null)
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
                            createBuyOrderDetail(code, name, quantity, price,todayBO.ID);
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
                    var todayBuyOrder = (from u in db.BuyOrders where u.Day == today select u).Single();
                    if (todayBuyOrder != null)
                    {
                        BuyOrder bo = new BuyOrder();
                        bo.Day = today;
                        bo.Total = 0;
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

        private void createBuyOrderDetail(string goodCode, string goodName, int quantity, int price, int orderID)
        {
            try
            {
                using (VB_BusinessEntities db = new VB_BusinessEntities())
                {
                    BuyOrderDetail buyOrderDetail = new BuyOrderDetail();
                    buyOrderDetail.GoodCode = goodCode;
                    buyOrderDetail.GoodName = goodName;
                    buyOrderDetail.Quantity = quantity;
                    buyOrderDetail.Total = price * quantity;
                    buyOrderDetail.ID = orderID;
                    db.BuyOrderDetails.Add(buyOrderDetail);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.StackTrace);
            }
        }
    }
}

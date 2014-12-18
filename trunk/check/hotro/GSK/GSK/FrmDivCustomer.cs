using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace GSK
{
    public partial class FrmDivCustomer : Form
    {
        string ConStr = @"Data Source=111.222.3.240\MSSQL2k12; Initial Catalog=CP_exportcustomer; User ID=helpdesk; password=helpdesk;";
        string FilePathDMS;
        string FilePathDMSReport;
        public FrmDivCustomer()
        {
            InitializeComponent();
        }

        private void BtnFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog MoThoai = new OpenFileDialog();
            MoThoai.Filter = "Excel 2007|*.xlsx";
            MoThoai.Title = "Chèn file Excel 2007";
            if (MoThoai.ShowDialog() == DialogResult.OK)
            {
                FilePathDMS = MoThoai.FileName;
                this.TxtfileExcelDMS.Text = System.IO.Path.GetFileName(MoThoai.FileName);
            }
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            SqlExecuteNonQuery(@"TRUNCATE TABLE DMS;TRUNCATE TABLE DMS_Report;", 10000);
            #region Insert score
            DataTable dtToInsertDMS = new DataTable();
            DataTable dtToInsertDMSReport = new DataTable();
            try
            {
                dtToInsertDMS = ReadDataFromExcelFile(FilePathDMS);
                dtToInsertDMSReport = ReadDataFromExcelFile(FilePathDMSReport);
            }
            catch { }

            if (dtToInsertDMS.Rows.Count != 0)
            {

                using (SqlConnection cn = new SqlConnection(ConStr))
                {
                    cn.Open();
                    using (SqlBulkCopy copy = new SqlBulkCopy(cn))
                    {
                        copy.ColumnMappings.Add(0, 0);
                        copy.ColumnMappings.Add(1, 1);
                        copy.ColumnMappings.Add(2, 2);
                        copy.ColumnMappings.Add(3, 3);
                        copy.ColumnMappings.Add(4, 4);
                        copy.ColumnMappings.Add(5, 5);
                        copy.ColumnMappings.Add(6, 6);
                        copy.ColumnMappings.Add(7, 7);
                        copy.ColumnMappings.Add(8, 8);
                        copy.ColumnMappings.Add(9, 9);
                        copy.ColumnMappings.Add(10, 10);
                        copy.ColumnMappings.Add(11, 11);
                        copy.ColumnMappings.Add(12, 12);
                        copy.DestinationTableName = "DMS";
                        copy.WriteToServer(dtToInsertDMS);
                    }
                }
            }
            if (dtToInsertDMSReport.Rows.Count != 0)
            {

                using (SqlConnection cn = new SqlConnection(ConStr))
                {
                    cn.Open();
                    using (SqlBulkCopy copy = new SqlBulkCopy(cn))
                    {
                        copy.ColumnMappings.Add(0, 0);
                        copy.ColumnMappings.Add(1, 1);
                        copy.ColumnMappings.Add(2, 2);
                        copy.ColumnMappings.Add(3, 3);
                        copy.ColumnMappings.Add(4, 4);
                        copy.ColumnMappings.Add(5, 5);
                        copy.ColumnMappings.Add(6, 6);
                        copy.ColumnMappings.Add(7, 7);
                        copy.ColumnMappings.Add(8, 8);
                        copy.ColumnMappings.Add(9, 9);
                        copy.ColumnMappings.Add(10, 10);
                        copy.ColumnMappings.Add(11, 11);
                        copy.ColumnMappings.Add(12, 12);
                        copy.ColumnMappings.Add(13, 13);
                        copy.ColumnMappings.Add(14, 14);
                        copy.ColumnMappings.Add(15, 15);
                        copy.ColumnMappings.Add(16, 16);
                        copy.ColumnMappings.Add(17, 17);
                        copy.ColumnMappings.Add(18, 18);
                        copy.ColumnMappings.Add(19, 19);
                        copy.ColumnMappings.Add(20, 20);
                        copy.ColumnMappings.Add(21, 21);
                        copy.ColumnMappings.Add(22, 22);
                        copy.ColumnMappings.Add(23, 23);
                        copy.DestinationTableName = "DMS_Report";
                        copy.WriteToServer(dtToInsertDMSReport);
                    }
                }
            }
            #endregion
            String FilePathSave  = "DSKH_DMS_" + DateTime.Now.ToString("MMddyyyyhhmmssf.ff");
            DataTable TableTongQuat = SqlDatatableTimeout(@"SELECT ROW_NUMBER() OVER(ORDER BY d2.Name Asc) AS Row,d2.[Route Code],d2.[Description],d2.[Sales Man Code],d2.Name,d2.[Cust Code],d2.Name1,d2.[Chain Code],d2.Add1
                                                                FROM DMS_Report d
                                                            LEFT JOIN DMS d2
                                                            ON d.[Cust Code] = d2.[Cust Code] 
                                                            WHERE LOWER(d2.[Description]) NOT LIKE '%kh%'
                                                            AND LOWER([Status]) = 'y'", 10000);
            DataTable TableSLKH = SqlDatatableTimeout(@"SELECT d2.[Sales Man Code],d2.Name,COUNT(*) AS 'SLKH'
                                                            FROM DMS_Report d
                                                        LEFT JOIN DMS d2
                                                        ON d.[Cust Code] = d2.[Cust Code] 
                                                        WHERE LOWER(d2.[Description]) NOT LIKE '%kh%'
                                                        AND LOWER([Status]) = 'y'
                                                        GROUP BY d2.[Sales Man Code],d2.Name", 10000);
            String path = Application.StartupPath + FilePathSave + ".xlsx";

            using (ExcelPackage package = new ExcelPackage())
            {
                ExcelWorksheet ws = package.Workbook.Worksheets.Add("Tông quát");

                ws.Cells["A1"].Value = "STT";
                ws.Cells["B1"].Value = "Mã Tuyến BH";
                ws.Cells["C1"].Value = "Tên Tuyến BH";
                ws.Cells["D1"].Value = "Mã NVBH";
                ws.Cells["E1"].Value = "Tên NVBH";
                ws.Cells["F1"].Value = "Mã KH";
                ws.Cells["G1"].Value = "Tên KH";
                ws.Cells["H1"].Value = "Tên KH chỉnh sửa";
                ws.Cells["I1"].Value = "Kênh BH";
                ws.Cells["J1"].Value = "Kênh mới";
                ws.Cells["K1"].Value = "Địa chỉ";
                ws.Cells["L1:O1"].Value = "Địa chỉ chỉnh sửa";
                ws.Cells["L1:O1"].Merge = true;
                ws.Cells["L1:O1"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                ws.Cells["L2"].Value = "Số nhà";
                ws.Cells["M2"].Value = "Tên đường";
                ws.Cells["N2"].Value = "Phường/Xã";
                ws.Cells["O2"].Value = "Quận/Huyện";
                for (int i = 0; i < TableTongQuat.Rows.Count; i++)
                {
                    ws.Cells["A" +  (i+3).ToString()].Value = TableTongQuat.Rows[i][0];
                    ws.Cells["B" + (i + 3).ToString()].Value = TableTongQuat.Rows[i][1];
                    ws.Cells["C" + (i + 3).ToString()].Value = TableTongQuat.Rows[i][2];
                    ws.Cells["D" + (i + 3).ToString()].Value = TableTongQuat.Rows[i][3];
                    ws.Cells["E" + (i + 3).ToString()].Value = TableTongQuat.Rows[i][4];
                    ws.Cells["F" + (i + 3).ToString()].Value = TableTongQuat.Rows[i][5];
                    ws.Cells["G" + (i + 3).ToString()].Value = TableTongQuat.Rows[i][6];
                    ws.Cells["I" + (i + 3).ToString()].Value = TableTongQuat.Rows[i][7];
                    ws.Cells["K" + (i + 3).ToString()].Value = TableTongQuat.Rows[i][8];
                }
                ws.Cells["A1:O" + (TableTongQuat.Rows.Count + 2).ToString()].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                ws.Cells["A1:O" + (TableTongQuat.Rows.Count + 2).ToString()].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                ws.Cells["A1:O" + (TableTongQuat.Rows.Count + 2).ToString()].Style.Border.Bottom.Style = ExcelBorderStyle.Thin; 
                ws.Cells["A1:O" + (TableTongQuat.Rows.Count + 2).ToString()].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                ws.Cells["A1:O" + (TableTongQuat.Rows.Count + 2).ToString()].AutoFitColumns();
           
                ws = package.Workbook.Worksheets.Add("SLSK");

               ws.Cells["A1"].Value = "Mã NVBH";
               ws.Cells["B1"].Value = "Tên NVBH";
                ws.Cells["C1"].Value = "Số lượng KH";
                for (int i = 0; i < TableSLKH.Rows.Count; i++)
                {
                    ws.Cells["A" + (i + 3).ToString()].Value = TableSLKH.Rows[i][0];
                    ws.Cells["B" + (i + 3).ToString()].Value = TableSLKH.Rows[i][1];
                    ws.Cells["C" + (i + 3).ToString()].Value = TableSLKH.Rows[i][2];
                }
                ws.Cells["A1:O" + (TableSLKH.Rows.Count + 2).ToString()].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                ws.Cells["A1:O" + (TableSLKH.Rows.Count + 2).ToString()].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                ws.Cells["A1:O" + (TableSLKH.Rows.Count + 2).ToString()].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                ws.Cells["A1:O" + (TableSLKH.Rows.Count + 2).ToString()].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                ws.Cells["A1:O" + (TableSLKH.Rows.Count + 2).ToString()].AutoFitColumns();
           
                for (int i = 0; i < TableSLKH.Rows.Count; i++)
                {
                    if(i+1<10)
                        ws = package.Workbook.Worksheets.Add("ChiTiet-0" + (i+1));
                    else
                        ws = package.Workbook.Worksheets.Add("ChiTiet-" + (i + 1));
                    ws.Cells["A1"].Value = "STT";
                    ws.Cells["B1"].Value = "Mã Tuyến BH";
                    ws.Cells["C1"].Value = "Tên Tuyến BH";
                    ws.Cells["D1"].Value = "Mã NVBH";
                    ws.Cells["E1"].Value = "Tên NVBH";
                    ws.Cells["F1"].Value = "Mã KH";
                    ws.Cells["G1"].Value = "Tên KH";
                    ws.Cells["H1"].Value = "Tên KH chỉnh sửa";
                    ws.Cells["I1"].Value = "Kênh BH";
                    ws.Cells["J1"].Value = "Kênh mới";
                    ws.Cells["K1"].Value = "Địa chỉ";
                    ws.Cells["L1:O1"].Value = "Địa chỉ chỉnh sửa";
                    ws.Cells["L1:O1"].Merge = true;
                    ws.Cells["L1:O1"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    ws.Cells["L2"].Value = "Số nhà";
                    ws.Cells["M2"].Value = "Tên đường";
                    ws.Cells["N2"].Value = "Phường/Xã";
                    ws.Cells["O2"].Value = "Quận/Huyện";
                    DataTable TableTongQuatChiTiet = SqlDatatableTimeout(@"SELECT ROW_NUMBER() OVER(ORDER BY d2.Name Asc) AS Row,d2.[Route Code],d2.[Description],d2.[Sales Man Code],d2.Name,d2.[Cust Code],d2.Name1,d2.[Chain Code],d2.Add1
                                                                FROM DMS_Report d
                                                            LEFT JOIN DMS d2
                                                            ON d.[Cust Code] = d2.[Cust Code] 
                                                            WHERE LOWER(d2.[Description]) NOT LIKE '%kh%'
                                                            AND LOWER([Status]) = 'y' AND d2.[Sales Man Code] = '" + TableSLKH.Rows[i][0].ToString() + "'", 10000);
                    for (int j = 0; j < TableTongQuatChiTiet.Rows.Count; j++)
                    {
                        ws.Cells["A" + (j + 3).ToString()].Value = TableTongQuatChiTiet.Rows[j][0];
                        ws.Cells["B" + (j + 3).ToString()].Value = TableTongQuatChiTiet.Rows[j][1];
                        ws.Cells["C" + (j + 3).ToString()].Value = TableTongQuatChiTiet.Rows[j][2];
                        ws.Cells["D" + (j + 3).ToString()].Value = TableTongQuatChiTiet.Rows[j][3];
                        ws.Cells["E" + (j + 3).ToString()].Value = TableTongQuatChiTiet.Rows[j][4];
                        ws.Cells["F" + (j + 3).ToString()].Value = TableTongQuatChiTiet.Rows[j][5];
                        ws.Cells["G" + (j + 3).ToString()].Value = TableTongQuatChiTiet.Rows[j][6];
                        ws.Cells["j" + (j + 3).ToString()].Value = TableTongQuatChiTiet.Rows[j][7];
                        ws.Cells["K" + (j + 3).ToString()].Value = TableTongQuatChiTiet.Rows[j][8];
                    }
                    ws.Cells["A1:O" + (TableTongQuatChiTiet.Rows.Count + 2).ToString()].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    ws.Cells["A1:O" + (TableTongQuatChiTiet.Rows.Count + 2).ToString()].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    ws.Cells["A1:O" + (TableTongQuatChiTiet.Rows.Count + 2).ToString()].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    ws.Cells["A1:O" + (TableTongQuatChiTiet.Rows.Count + 2).ToString()].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    ws.Cells["A1:O" + (TableTongQuatChiTiet.Rows.Count + 2).ToString()].AutoFitColumns();
                }

                //newFile.Create();
                //newFile.MoveTo(@"C:/testSheet.xlsx");
                //package.SaveAs(newFile);
                package.SaveAs(new System.IO.FileInfo(path));
             

               
            }
            MessageBox.Show("Đã cập nhật dữ liệu thành công");
        }
        public DataTable SqlDatatableTimeout(string selectsql, int timeout)
        {
            SqlConnection Conn = (SqlConnection)null;

            Conn = new SqlConnection(ConStr);
            DataSet dataset = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();

            adapter.SelectCommand = new SqlCommand(selectsql, Conn);
            adapter.SelectCommand.CommandTimeout = timeout;
            Conn.Open();
            adapter.Fill(dataset);
            DataTable table = dataset.Tables[0];
            if (Conn != null)
                Conn.Close();
            return table;
        }


        public  void SqlExecuteNonQuery(string queryString, int timeout)
        {
            SqlConnection Conn = (SqlConnection)null;


            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.CommandTimeout = timeout;
                command.Connection.Open();
                command.ExecuteNonQuery();
                command.Connection.Close();
            }
        }

        private DataTable ReadDataFromExcelFile(string G5sFilePath)
        {
            //Excel 03
            string G5sconStr =
                "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0}; Extended Properties='Excel 8.0; IMEX=1;ImportMixedTypes=Text'";

            //Excel 07
            if (G5sFilePath.Substring(G5sFilePath.LastIndexOf(".")) == ".xlsx")
                G5sconStr =
                    "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0}; Extended Properties='Excel 8.0; IMEX=1;ImportMixedTypes=Text'";


            G5sconStr = String.Format(G5sconStr, G5sFilePath);
            OleDbConnection connExcel = new OleDbConnection(G5sconStr);
            OleDbCommand cmdExcel = new OleDbCommand();
            OleDbDataAdapter oda = new OleDbDataAdapter();
            DataTable dt = new DataTable();
            cmdExcel.Connection = connExcel;

            //Get the name of First Sheet
            connExcel.Open();
            DataTable dtExcelSchema;
            dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            string G5sSheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
            connExcel.Close();

            //Read Data from First Sheet
            connExcel.Open();
            cmdExcel.CommandText = "SELECT * From [" + G5sSheetName + "]";
            oda.SelectCommand = cmdExcel;
            oda.Fill(dt);
            connExcel.Close();
            return dt;

        }
     
        private void BtnDMSReprot_Click(object sender, EventArgs e)
        {
            OpenFileDialog MoThoai = new OpenFileDialog();
            MoThoai.Filter = "Excel 2007|*.xlsx";
            MoThoai.Title = "Chèn file Excel 2007";
            if (MoThoai.ShowDialog() == DialogResult.OK)
            {
                FilePathDMSReport = MoThoai.FileName;
                this.TxtfileExcelDMSReport.Text = System.IO.Path.GetFileName(MoThoai.FileName);
            }
        }
    }
}

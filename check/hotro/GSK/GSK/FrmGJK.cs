using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GSK
{
    public partial class FrmGJK : Form
    {
        protected string _url;
        string html = "";
        static string FilePath;
        bool login = false;
        static int rows = 2;
        public FrmGJK()
        {
            InitializeComponent();
            GetWebpage("http://118.69.32.45:1111/Default.aspx");
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
           
            HtmlElement ElTxtUserName = this.webBrowserGJK.Document.Body.Document.GetElementById("L5sUsrNm");
            HtmlElement ELTxtPass = this.webBrowserGJK.Document.Body.Document.GetElementById("L5sPwrd");
            HtmlElement ELBtnLogin = this.webBrowserGJK.Document.Body.Document.GetElementById("L5sOK");
            ElTxtUserName.InnerText = TxtUserName.Text;
            ELTxtPass.InnerText = TxtPass.Text;
            ELBtnLogin.InvokeMember("click");
            if (this.webBrowserGJK.ReadyState == WebBrowserReadyState.Complete)
            {
                GetWebpage("http://118.69.32.45:1111/Product/ProductManagement.aspx");
                login = true;
            }
  
            //Uri uri = new Uri("");
            //webBrowserGJK.Url = uri;
         
        }
        private DataTable ReadDataFromExcelFile(string G5sFilePath)
        {
            //Excel 03
            string G5sconStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0}; Extended Properties='Excel 8.0; IMEX=1;ImportMixedTypes=Text'";

            //Excel 07
            if (G5sFilePath.Substring(G5sFilePath.LastIndexOf(".")) == ".xlsx")
                G5sconStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0}; Extended Properties='Excel 8.0; IMEX=1;ImportMixedTypes=Text'";
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

        private void BtnFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog MoThoai = new OpenFileDialog();
            MoThoai.Filter = "Excel 2007|*.xlsx";
            MoThoai.Title = "Chen Hinh";
            if (MoThoai.ShowDialog() == DialogResult.OK)
            {
                FilePath = MoThoai.FileName;
                this.TxtfileExcel.Text = System.IO.Path.GetFileName(MoThoai.FileName);
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (TxtfileExcel.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng chọn file");
                return;
            }
           
         
      
        }
        

        public string GetWebpage(string url)
        {
            _url = url;
            // WebBrowser is an ActiveX control that must be run in a
            // single-threaded apartment so create a thread to create the
            // control and generate the thumbnail
            Thread thread = new Thread(new ThreadStart(GetWebPageWorker));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();
            string s = html;
            return s;
        }

        protected void GetWebPageWorker()
        {
          
                //  browser.ClientSize = new Size(_width, _height);
                webBrowserGJK.ScrollBarsEnabled = false;
                webBrowserGJK.ScriptErrorsSuppressed = true;
                webBrowserGJK.Navigate(_url);

                //// Wait for control to load page
                //while (webBrowserGJK.ReadyState != WebBrowserReadyState.Complete)
                //    Application.DoEvents();

                //html = webBrowserGJK.DocumentText;
           
        }

        private void Btnback_Click(object sender, EventArgs e)
        {
            GetWebpage("http://118.69.32.45:1111/Default.aspx");
        }

        private void webBrowserGJK_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (login == true)
            {
                HtmlElement ElBtnNew = this.webBrowserGJK.Document.Body.Document.GetElementById("ctl00_BodyContentPlaceHolder_J5sLbtnNew");
                if (ElBtnNew != null)
                {
                    ElBtnNew.InvokeMember("click");
                }
                else
                {
                    login = false;
                    GetWebpage("http://118.69.32.45:1111/Default.aspx");

                }

            }
        }
        public void setvalue()
        {
           
                HtmlElement ElTxtPCode = this.webBrowserGJK.Document.Body.Document.GetElementById("ctl00_BodyContentPlaceHolder_J5stxtProductCode");
                HtmlElement ElTxtPName = this.webBrowserGJK.Document.Body.Document.GetElementById("ctl00_BodyContentPlaceHolder_J5stxtProductName");
                HtmlElement ElDropdownProduct_Type = this.webBrowserGJK.Document.Body.Document.GetElementById("ctl00_BodyContentPlaceHolder_J5sddlProductType");
                HtmlElement ElTxtProductBrand_Code = this.webBrowserGJK.Document.Body.Document.GetElementById("ctl00_BodyContentPlaceHolder_J5stxtProductBrand_CODE");
                HtmlElement ElTxtProductBrand_Name = this.webBrowserGJK.Document.Body.Document.GetElementById("ctl00_BodyContentPlaceHolder_J5stxtProductBrand");
                HtmlElement ElBtnInsert = this.webBrowserGJK.Document.Body.Document.GetElementById("ctl00_BodyContentPlaceHolder_J5sLbtnInsert");
                if (ElBtnInsert != null)
                {
                    var existingFile = new FileInfo(FilePath);
                    // Open and read the XlSX file.
                    using (var package = new ExcelPackage(existingFile))
                    {
                        // Get the work book in the file
                        ExcelWorkbook workBook = package.Workbook;
                        if (workBook != null)
                        {
                            if (workBook.Worksheets.Count > 0)
                            {
                                // Get the first worksheet
                                ExcelWorksheet currentWorksheet = workBook.Worksheets.First();
                                // read some data
                                object TenSP = currentWorksheet.Cells[rows, 1].Value;
                                object MaSP = currentWorksheet.Cells[rows, 2].Value;
                                object Loai = currentWorksheet.Cells[rows, 3].Value;
                                object MaNhan = currentWorksheet.Cells[rows, 4].Value;
                                object TenNhan = currentWorksheet.Cells[rows, 5].Value;
                                ElTxtPCode.InnerText = MaSP.ToString();
                                ElTxtPName.InnerText = TenSP.ToString();
                                ElTxtProductBrand_Code.InnerText = MaNhan.ToString();
                                ElTxtProductBrand_Name.InnerText = TenNhan.ToString();
                                HtmlElementCollection eloptiton = ElDropdownProduct_Type.GetElementsByTagName("option");
                                foreach (HtmlElement item in eloptiton)
                                {
                                    if (item.GetAttribute("text").Trim() == Loai.ToString().Trim())
                                    {
                                        item.SetAttribute("selected", "selected");
                                    }
                                }
                                rows++;
                                if (rows <= currentWorksheet.Dimension.Rows)
                                {
                                    ElBtnInsert.InvokeMember("click");
                                }

                            }
                        }
                    }
                }
            
        }

        

        
        private void webBrowserGJK_FileDownload(object sender, EventArgs e)
        {
            if (login == true)
            {
                setvalue();
                
            }
                 
        }

       
       
       
   
    }
}

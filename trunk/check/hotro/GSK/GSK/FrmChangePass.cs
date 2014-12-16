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
using mshtml;
using System.Runtime.InteropServices;
namespace GSK
{
    public partial class FrmChangePass : Form
    {
       
        protected string _url;
        System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();
           
        string html = "";
        string FilePath;
        bool login = false;
        int rows = 2;
        int flag = 0;
        public FrmChangePass()
        {
            InitializeComponent();
            GetWebpage(TxtUrl.Text);
        }
        private void TimerEvent(Object myObject, EventArgs myEventArgs)
        {
            if (flag == 0) // Login
            {
                HtmlElement ElTxtUserName = this.webBrowserGJK.Document.Body.Document.GetElementById("txtUserid");

                if (ElTxtUserName != null)
                {

                    setvalueLogin(); 
                    flag = 1;
                    IntPtr hwnd = FindWindow(null, "Message from webpage");
                    hwnd = FindWindowEx(hwnd, IntPtr.Zero, "Button", "OK");
                    uint message = 0xf5;
                    SendMessage(hwnd, message, IntPtr.Zero, IntPtr.Zero);
                    return;
                }
            }
            if (flag == 1) // Login
            {
                HtmlElement ElTxtUserName = this.webBrowserGJK.Document.Body.Document.GetElementById("txtUserid");

                if (ElTxtUserName != null)
                {
                    string UserName = ElTxtUserName.GetAttribute("value");
                    if (UserName != "")
                    {
                        HtmlElement ELBLogin = this.webBrowserGJK.Document.Body.Document.GetElementById("btnLogin");
                        ELBLogin.InvokeMember("click");
                        flag = 2;
                        return;
                    }
                }
            }
            if (flag == 2) // Menu KH
            {

                HtmlElement ElbtnPasswdChange = this.webBrowserGJK.Document.Body.Document.GetElementById("btnPasswdChange");
                if (ElbtnPasswdChange != null)
                {
                    Random rand = new Random();
                    GetWebpage("https://gsk-uat.np.accenture.com/dms_vn/Sys/Module/Dialog_PasswordChange.aspx?rnd=" + rand.NextDouble().ToString());
                    flag = 3;
                    return;
                }
                
            }
            if (flag == 3) // Click Tự phát sinh
            {
                HtmlElement ElTxtOldPassword = this.webBrowserGJK.Document.Body.Document.GetElementById("txtOldPassword");
                if (ElTxtOldPassword != null)
                {
                    setvalueChangePass();
                    flag = 4;
                    return;
                }
            }
            if (flag == 4) // Set Value
            {
                HtmlElement ElTxtOldPassword = this.webBrowserGJK.Document.Body.Document.GetElementById("txtOldPassword");
                if (ElTxtOldPassword != null)
                {
                    string OldPassword = ElTxtOldPassword.GetAttribute("value");
                    if (OldPassword != "")
                    {
                        HtmlElement ELBSave = this.webBrowserGJK.Document.Body.Document.GetElementById("btnSave");
                        ELBSave.InvokeMember("click");
                        GetWebpage(TxtUrl.Text);
                        flag = 0;
                        return;
                    }
                }
            }
            
          

        }
      
 

        private  void BtnLogin_Click(object sender, EventArgs e)
        {
            BtnLogin.Enabled = false;
            myTimer.Tick += new EventHandler(TimerEvent);
            myTimer.Interval = 10000;
            myTimer.Start();
       
            //Uri uri = new Uri("");
            //webBrowserGJK.Url = uri;
         
        }
        private void BtnFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog MoThoai = new OpenFileDialog();
            MoThoai.Filter = "Excel 2007|*.xlsx";
            MoThoai.Title = "Chèn file Excel 2007";
            if (MoThoai.ShowDialog() == DialogResult.OK)
            {
                FilePath = MoThoai.FileName;
                this.TxtfileExcel.Text = System.IO.Path.GetFileName(MoThoai.FileName);
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
                webBrowserGJK.ScriptErrorsSuppressed = true;
                webBrowserGJK.CausesValidation = false;
                webBrowserGJK.Navigate(_url);

                //// Wait for control to load page
                //while (webBrowserGJK.ReadyState != WebBrowserReadyState.Complete)
                //    Application.DoEvents();

                //html = webBrowserGJK.DocumentText;
           
        }

        private void Btnback_Click(object sender, EventArgs e)
        {

            Application.Restart();
        }

        public void setvalueChangePass()
        {
            HtmlElement ElTxtOldPassword = this.webBrowserGJK.Document.Body.Document.GetElementById("txtOldPassword");
            HtmlElement ELTxtNewPassword = this.webBrowserGJK.Document.Body.Document.GetElementById("txtNewPassword");
            HtmlElement ELBtnConfirm = this.webBrowserGJK.Document.Body.Document.GetElementById("txtConfirm");

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
                        if (rows <= currentWorksheet.Dimension.Rows)
                        {

                          
                            object OldPassword = currentWorksheet.Cells[rows, 2].Value;
                            object NewPassword = currentWorksheet.Cells[rows, 3].Value;


                            ElTxtOldPassword.InnerText = OldPassword.ToString().Trim();
                            ELTxtNewPassword.InnerText = NewPassword.ToString().Trim();
                            ELBtnConfirm.InnerText = NewPassword.ToString().Trim();
                            currentWorksheet.Cells[rows, 4].Value = "Read";
                            package.Save();
                            rows++;
                        }
                        else
                        {
                            myTimer.Stop();
                            Application.Restart();


                        }
                    }
                }

            }
        }
        public  void setvalueLogin()
        {


                HtmlElement ElTxtUserName = this.webBrowserGJK.Document.Body.Document.GetElementById("txtUserid");
                HtmlElement ELTxtPass = this.webBrowserGJK.Document.Body.Document.GetElementById("txtPasswd");
              
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
                            if (rows <= currentWorksheet.Dimension.Rows)
                            {
                                object Username = currentWorksheet.Cells[rows, 1].Value;
                                object Pass = currentWorksheet.Cells[rows, 2].Value;
                                ElTxtUserName.InnerText = Username.ToString().Trim();
                                ELTxtPass.InnerText = Pass.ToString().Trim();
                            }
                            else
                            {
                                object Username = currentWorksheet.Cells[rows - 1, 1].Value;
                                object Pass = currentWorksheet.Cells[rows - 1, 3].Value;
                                ElTxtUserName.InnerText = Username.ToString().Trim();
                                ELTxtPass.InnerText = Pass.ToString().Trim();
                            }
                        }
                    }
                    
                }
            
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            myTimer.Stop();
        }

        private void BtnTiepTuc_Click(object sender, EventArgs e)
        {
            myTimer.Start();
        }

        private void BtnGo_Click(object sender, EventArgs e)
        {
            GetWebpage(TxtUrl.Text);
        }

      
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);
        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);

       
   

      

      

        

       
     
     

       
       
       
   
    }
}


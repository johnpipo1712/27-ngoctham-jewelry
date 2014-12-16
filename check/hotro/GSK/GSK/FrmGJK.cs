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
        System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();
           
        string html = "";
        string FilePath;
        bool login = false;
        int rows = 2;
        int flag = 0;
       
        public FrmGJK()
        {
            InitializeComponent();

            GetWebpage(TxtUrl.Text);
           
        }
        private void TimerEvent(Object myObject, EventArgs myEventArgs)
        {
            if (flag == 0) // Login
            {
                HtmlElement ELBtnMenuKH = this.webBrowserGJK.Document.Body.Document.GetElementById("pag_MasterRoot_tab_Main_itm_Cust");
                if (ELBtnMenuKH != null)
                {
                    ELBtnMenuKH.InvokeMember("click");
                    flag = 1;
                    return;
                }
            }
            if (flag == 1) // Menu KH
            {
                
                HtmlElement ELBtnThem = this.webBrowserGJK.Document.Body.Document.GetElementById("pag_M_Cust_btn_Add_Value");
                if (ELBtnThem != null)
                {
                    ELBtnThem.InvokeMember("click");
                    flag = 2;
                    return;
                }
                else
                {
                    HtmlElement ELBtnThem2 = this.webBrowserGJK.Document.Body.Document.GetElementById("pag_M_Cust_btn_Dtl_Add_Value");
                    if (ELBtnThem2 != null)
                    {
                        ELBtnThem2.InvokeMember("click");
                        flag = 2;
                        return;
                    }
                }
            }
            if (flag == 2) // Click Tự phát sinh
            {
                HtmlElement ELBtnTuPhatSinh = this.webBrowserGJK.Document.Body.Document.GetElementById("pag_MC_NewGeneral_btn_Gen_custCd_Value");
                if (ELBtnTuPhatSinh != null)
                {
                    ELBtnTuPhatSinh.InvokeMember("click");
                    flag = 3;
                    return;
                }
            }
            if (flag == 3) // Set Value
            {
                HtmlElement ELBtnMaKH = this.webBrowserGJK.Document.Body.Document.GetElementById("pag_MC_NewGeneral_txt_n_CUST_CD_Value");
                if (ELBtnMaKH != null)
                {
                    string MaKH =  ELBtnMaKH.GetAttribute("value");
                    if(MaKH !=  "")
                    {
                        setvalue();
                        return;
                    }
                }
            }
            if (flag == 4) // Click Lưu
            {
                HtmlElement ELBtnLuuKH = this.webBrowserGJK.Document.Body.Document.GetElementById("pag_MC_NewGeneral_frm_Detail_Save_Value");
                if (ELBtnLuuKH != null)
                {
                    ELBtnLuuKH.InvokeMember("click");
                    flag = 5;
                    return;
                }
            }
            if (flag == 5) // Click Close
            {
                HtmlElement ELBtnHuyKH = this.webBrowserGJK.Document.Body.Document.GetElementById("pag_MC_AssignRoute_frm_Detail_Cancel_Value");
                if (ELBtnHuyKH != null)
                {
                    ELBtnHuyKH.InvokeMember("click");
                    flag = 0;
                    return;
                }
            }

        }
      
 

        private  void BtnLogin_Click(object sender, EventArgs e)
        {
            BtnLogin.Enabled = false;
            if (TxtfileExcel.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng chọn file");
                return;
            }
            HtmlElement ElTxtUserName = this.webBrowserGJK.Document.Body.Document.GetElementById("txtUserid");
            HtmlElement ELTxtPass = this.webBrowserGJK.Document.Body.Document.GetElementById("txtPasswd");
            HtmlElement ELBtnLogin = this.webBrowserGJK.Document.Body.Document.GetElementById("btnLogin");
            if (ELBtnLogin != null)
            {
                ElTxtUserName.InnerText = TxtUserName.Text;
                ELTxtPass.InnerText = TxtPass.Text;
                ELBtnLogin.InvokeMember("click");
              
                myTimer.Tick += new EventHandler(TimerEvent);
                myTimer.Interval = 10000;
                myTimer.Start();
            }
            else
            {
                GetWebpage(TxtUrl.Text);
           
            }
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

    
        public  void setvalue()
        {


                HtmlElement ElMaKH = this.webBrowserGJK.Document.Body.Document.GetElementById("pag_MC_NewGeneral_txt_n_CUST_CD_Value");
                HtmlElement ElTexKH = this.webBrowserGJK.Document.Body.Document.GetElementById("pag_MC_NewGeneral_txt_n_CUST_NAME_Value");
                HtmlElement ElDropNhomGia = this.webBrowserGJK.Document.Body.Document.GetElementById("pag_MC_NewGeneral_drp_n_PRICEGRP_CD_Value");
                HtmlElement ElDropKhuVucNPP = this.webBrowserGJK.Document.Body.Document.GetElementById("pag_MC_NewGeneral_drp_n_AREA_CD_Value");
                HtmlElement ElDropKenhPhu = this.webBrowserGJK.Document.Body.Document.GetElementById("pag_MC_NewGeneral_drp_n_CUST_HIER3_Value");
                HtmlElement ElDiaChiMuaHang = this.webBrowserGJK.Document.Body.Document.GetElementById("pag_MC_NewGeneral_txt_n_ADDR1_Value");
                HtmlElement ElMaBuuDien = this.webBrowserGJK.Document.Body.Document.GetElementById("pag_MC_NewGeneral_txt_n_ADDR_POSTAL_Value");
                HtmlElement ElTenNguoiLienLac = this.webBrowserGJK.Document.Body.Document.GetElementById("pag_MC_NewGeneral_txt_n_CONT_PR_Value");
                HtmlElement ElSoDienThoai = this.webBrowserGJK.Document.Body.Document.GetElementById("pag_MC_NewGeneral_txt_n_CONT_NO_Value");
                HtmlElement ElDropSoTonKho = this.webBrowserGJK.Document.Body.Document.GetElementById("pag_MC_NewGeneral_drp_n_INVTERM_CD_Value");
                HtmlElement ElHanMucTinDung = this.webBrowserGJK.Document.Body.Document.GetElementById("pag_MC_NewGeneral_txt_n_CUST_CRDLMT_Value");
              
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

                                string textloi = "";
                                bool loi = true;
                                // read some data
                                object TenKH = currentWorksheet.Cells[rows, 2].Value;
                                object NhomGia = currentWorksheet.Cells[rows, 3].Value;
                                object KhuvucNPP = currentWorksheet.Cells[rows, 4].Value;
                                object KenhPhu = currentWorksheet.Cells[rows, 5].Value;
                                object DiaChiMuaHang = currentWorksheet.Cells[rows, 6].Value;
                                object MaBuuDien = currentWorksheet.Cells[rows, 7].Value;
                                object TenNguoiLienLac = currentWorksheet.Cells[rows, 8].Value;
                                object SoDienThoai = currentWorksheet.Cells[rows, 9].Value;
                                object SoTonKho = currentWorksheet.Cells[rows, 10].Value;
                                object HanMucTinDung = currentWorksheet.Cells[rows, 11].Value;
                                   
                                ElTexKH.InnerText = TenKH.ToString().Trim();
                                ElDiaChiMuaHang.InnerText = DiaChiMuaHang.ToString().Trim();
                                ElMaBuuDien.InnerText = MaBuuDien.ToString().Trim();
                                ElTenNguoiLienLac.InnerText = TenNguoiLienLac.ToString().Trim();
                                ElSoDienThoai.InnerText = SoDienThoai.ToString().Trim();
                                ElHanMucTinDung.InnerText = HanMucTinDung.ToString().Trim();

                                HtmlElementCollection eloptiton = ElDropNhomGia.GetElementsByTagName("option");
                                foreach (HtmlElement item in eloptiton)
                                {
                                    if (item.GetAttribute("text").ToUpper() == NhomGia.ToString().Trim().ToUpper())
                                    {
                                        item.SetAttribute("selected", "selected");
                                        loi = false;
                                    }

                                }
                                if(loi == true)
                                {
                                    textloi = "Tên chọn nhóm giá không đúng";
                                }
                                loi = true;
                                HtmlElementCollection eloptiton2 = ElDropKhuVucNPP.GetElementsByTagName("option");
                                foreach (HtmlElement item in eloptiton2)
                                {
                                    if (item.GetAttribute("text").ToUpper() == KhuvucNPP.ToString().Trim().ToUpper())
                                    {
                                        item.SetAttribute("selected", "selected");
                                        loi = false;
                                    }
                                }
                                if (loi == true)
                                {
                                    if (textloi == "")
                                        textloi = "Tên chọn khu vực NPP không đúng";
                                    else
                                        textloi += ",Tên chọn khu vực NPP không đúng";
                                }
                                loi = true;
                                HtmlElementCollection eloptiton3 = ElDropKenhPhu.GetElementsByTagName("option");
                                foreach (HtmlElement item in eloptiton3)
                                {
                                    if (item.GetAttribute("text").ToUpper() == KenhPhu.ToString().Trim().ToUpper())
                                    {
                                        item.SetAttribute("selected", "selected");
                                        loi = false;
                                    }
                                }
                                if (loi == true)
                                {
                                    if (textloi == "")
                                        textloi = "Tên chọn kênh phụ không đúng";
                                    else
                                        textloi += ",Tên chọn kênh không đúng";
                                }
                                loi = true;
                                HtmlElementCollection eloptiton4 = ElDropSoTonKho.GetElementsByTagName("option");
                                foreach (HtmlElement item in eloptiton4)
                                {
                                    if (item.GetAttribute("text").ToUpper() == SoTonKho.ToString().Trim())
                                    {
                                        item.SetAttribute("selected", "selected");
                                        loi = false;
                                    }
                                }
                                if (loi == true)
                                {
                                    if (textloi == "")
                                       textloi = "Tên chọn số tồn kho không đúng";
                                    else
                                        textloi += ",Tên chọn số tồn kho không đúng";
                                }
                                if(textloi == "")
                                {
                                    currentWorksheet.Cells[rows, 1].Value = ElMaKH.GetAttribute("value");
                                    package.Save();
                                    flag = 4;
                               
                                }
                                else
                                {
                                    currentWorksheet.Cells[rows, 1].Value = textloi;
                                    package.Save();
                                }
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

      

      

        

       
     
     

       
       
       
   
    }
}

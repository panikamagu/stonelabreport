using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using System.Linq;
using Syncfusion.EJ.Export;
using System.Collections;
using Syncfusion.XlsIO;
using CCP_MOULDS.Services;
using static CCP_MOULDS.SiteMaster;
using System.Configuration;

namespace CCP_MOULDS
{
    public partial class Data : System.Web.UI.Page 
    {
        List<Ordersl> order = new List<Ordersl>();

        protected void Page_Load(object sender, EventArgs e)
        {

          
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("EN");
            if (!IsPostBack)
            {

               
            }

            FNGET("0");

            this.cmb_Province.DataSource = ProvinceList.GetProvince();
          //  this.cmb_ampure.DataSource = AmpureList.GetAmpure(l_IDprovince.Text);
            //this.cmb_district.DataSource = DictrictList.GetDictrict(l_IDprovince.Text, l_IDampur.Text);



        }

        protected void Grid1_ServerExcelExporting(object sender, Syncfusion.JavaScript.Web.GridEventArgs e)
        {
            ExcelExport exp = new ExcelExport();

            exp.Export(Grid1.Model, (IEnumerable)Grid1.DataSource, "CCP-Export.xlsx", ExcelVersion.Excel2010, true, true, "flat-lime");
        }

        protected void Grid1_ServerPdfExporting(object sender, Syncfusion.JavaScript.Web.GridEventArgs e)
        {
            PdfExport exp = new PdfExport();

            exp.Export(Grid1.Model, (IEnumerable)Grid1.DataSource, "CCP-Export.xlsx", true, true, "flat-lime");
        }

        protected void Grid1_ServerWordExporting(object sender, Syncfusion.JavaScript.Web.GridEventArgs e)
        {
            WordExport exp = new WordExport();

            exp.Export(Grid1.Model, (IEnumerable)Grid1.DataSource, "CCP-Export.docx", true, true, "flat-lime");

        }


        private void FNGET(string dist)
        {

            order.Clear();

            try
            {
                string WRTrn22 = ConfigurationSettings.AppSettings["TRN22"]; //"50500";
                string WRTrn10 = ConfigurationSettings.AppSettings["TRN10"]; //"24500";
                string WRTrn6 = ConfigurationSettings.AppSettings["TRN6"]; //"14500";
                string WRTrn4 = ConfigurationSettings.AppSettings["TRN4"]; //"0";

                string NameTrn22 = "รถ 22 ล้อ";
                string NameTrn10 = "รถ 10 ล้อ";
                string NameTrn6 = "รถ 6 ล้อ";
                string NameTrn4 = "รถ 4 ล้อ";

                string PriceTrn22 = lbl_PriceY4.Text;
                string PriceTrn10 = lbl_PriceY3.Text;
                string PriceTrn6 = ConfigurationSettings.AppSettings["Price6"]; //"27.00";
                string PriceTrn4 = ConfigurationSettings.AppSettings["Price4"]; //"22.00";

                string DIS22 = ConfigurationSettings.AppSettings["DIS22"];
                string DIS10 = ConfigurationSettings.AppSettings["DIS10"];
                string DIS6 = ConfigurationSettings.AppSettings["DIS6"]; //"27.00";
                string DIS4 = ConfigurationSettings.AppSettings["DIS4"]; //"22.00";

                string Less22 = ConfigurationSettings.AppSettings["Less22"];
                string Less10 = ConfigurationSettings.AppSettings["Less10"];
                string Less6 = ConfigurationSettings.AppSettings["Less6"]; //"27.00";
                string Less4 = ConfigurationSettings.AppSettings["Less4"]; //"22.00";

                double dis; double.TryParse(dist, out dis);

                #region
                //string sql22 = "Select F_tran_price,F_tran_weight_law,F_tran_trucktype,F_Dis_Config_Percent from tbl_transport where F_tran_car_type2 = '" + "Y4" + "' ";
                //DataSet ds_s22 = new Class1().SqlGet(sql22, "tbl_transport");
                //long row22 = ds_s22.Tables[0].Rows.Count;
                //if (row22 != 0)
                //{
                //    string F_tran_price = ds_s22.Tables["tbl_transport"].Rows[0]["F_tran_price"].ToString();
                //    string F_tran_weight_law = ds_s22.Tables["tbl_transport"].Rows[0]["F_tran_weight_law"].ToString();
                //    string F_tran_trucktype = ds_s22.Tables["tbl_transport"].Rows[0]["F_tran_trucktype"].ToString();
                //    string F_Dis_Config_Percent = ds_s22.Tables["tbl_transport"].Rows[0]["F_Dis_Config_Percent"].ToString();

                //    int wtr; Int32.TryParse(F_tran_weight_law, out wtr);
                //    WRTrn22 = wtr.ToString("#,#");

                //    NameTrn22 = F_tran_trucktype;

                //    double Ptrn22; double.TryParse(F_tran_price, out Ptrn22);
                //    double Per; double.TryParse(F_Dis_Config_Percent, out Per);

                //    Ptrn22 = (dis * Ptrn22) + ((dis * Ptrn22) * Per);
                //    PriceTrn22 = Ptrn22.ToString("#,#");

                //    if (PriceTrn22.Contains("2550"))
                //    { }
                //}

                //string sql10 = "Select F_tran_price,F_tran_weight_law,F_tran_trucktype,F_Dis_Config_Percent from tbl_transport where F_tran_car_type2 = '" + "Y3" + "' ";
                //DataSet ds_s10 = new Class1().SqlGet(sql10, "tbl_transport");
                //long row10 = ds_s10.Tables[0].Rows.Count;
                //if (row10 != 0)
                //{
                //    string F_tran_price = ds_s10.Tables["tbl_transport"].Rows[0]["F_tran_price"].ToString();
                //    string F_tran_weight_law = ds_s10.Tables["tbl_transport"].Rows[0]["F_tran_weight_law"].ToString();
                //    string F_tran_trucktype = ds_s10.Tables["tbl_transport"].Rows[0]["F_tran_trucktype"].ToString();
                //    string F_Dis_Config_Percent = ds_s10.Tables["tbl_transport"].Rows[0]["F_Dis_Config_Percent"].ToString();

                //    int wtr; Int32.TryParse(F_tran_weight_law, out wtr);
                //    WRTrn10 = wtr.ToString("#,#");

                //    NameTrn10 = F_tran_trucktype;

                //    double Ptrn10; double.TryParse(F_tran_price, out Ptrn10);

                //    double Per; double.TryParse(F_Dis_Config_Percent, out Per);

                //    Ptrn10 = (dis * Ptrn10) + ((dis * Ptrn10) * Per);

                //    PriceTrn10 = Ptrn10.ToString("#,#");
                //}

                //string sql6 = "Select F_tran_price,F_tran_weight_law,F_tran_trucktype,F_Dis_Config_Percent from tbl_transport where F_tran_car_type2 = '" + "Y2" + "' ";
                //DataSet ds_s6 = new Class1().SqlGet(sql6, "tbl_transport");
                //long row6 = ds_s6.Tables[0].Rows.Count;
                //if (row6 != 0)
                //{
                //    string F_tran_price = ds_s6.Tables["tbl_transport"].Rows[0]["F_tran_price"].ToString();
                //    string F_tran_weight_law = ds_s6.Tables["tbl_transport"].Rows[0]["F_tran_weight_law"].ToString();
                //    string F_tran_trucktype = ds_s6.Tables["tbl_transport"].Rows[0]["F_tran_trucktype"].ToString();
                //    string F_Dis_Config_Percent = ds_s6.Tables["tbl_transport"].Rows[0]["F_Dis_Config_Percent"].ToString();


                //    int wtr; Int32.TryParse(F_tran_weight_law, out wtr);
                //    WRTrn6 = wtr.ToString("#,#");

                //    NameTrn6 = F_tran_trucktype;

                //    double Ptrn6; double.TryParse(PriceTrn6, out Ptrn6);
                //    double Per; double.TryParse(F_Dis_Config_Percent, out Per);

                //    Ptrn6 = (dis * Ptrn6) + ((dis * Ptrn6) * Per);

                //    PriceTrn6 = Ptrn6.ToString("#,#");

                //}

                #endregion

                double Ptrn22; double.TryParse(PriceTrn22, out Ptrn22);
                double Per22; double.TryParse(DIS22, out Per22);
                Ptrn22 = (Ptrn22) + ((Ptrn22) * Per22);

                PriceTrn22 = Ptrn22.ToString("#,#");

                double Ptrn10; double.TryParse(PriceTrn10, out Ptrn10);
                double Per10; double.TryParse(DIS10, out Per10);          
                Ptrn10 = (Ptrn10) + ((Ptrn10) * Per10);

                PriceTrn10 = Ptrn10.ToString("#,#");

                double Ptrn6; double.TryParse(PriceTrn6, out Ptrn6);
                double Per6; double.TryParse(DIS6, out Per6);
                Ptrn6 = (dis * Ptrn6) + ((dis * Ptrn6) * Per6);

                PriceTrn6 = Ptrn6.ToString("#,#");

                double Ptrn4; double.TryParse(PriceTrn4, out Ptrn4);
                double Per4; double.TryParse(DIS4, out Per4);

                Ptrn4 = (dis * Ptrn4) + ((dis * Ptrn4) * Per4);

                PriceTrn4 = Ptrn4.ToString("#,#");

                //order.Add(new Ordersl(PriceTrn22+" บาท", PriceTrn10 + " บาท", PriceTrn6 + " บาท", PriceTrn4 + " บาท"));
                //order.Add(new Ordersl("นน.ตามกฎหมาย " + NameTrn22 + " " + WRTrn22, "นน.ตามกฎหมาย " + NameTrn10 + " " + WRTrn10, "นน.ตามกฎหมาย " + NameTrn6 + " " + WRTrn6, "นน.ตามกฎหมาย " + NameTrn4 + " " + WRTrn4));
                ////order.Add(new Ordersl(WRTrn22, WRTrn10, WRTrn6, WRTrn4));
                //order.Add(new Ordersl("ราคาขึ้นต่ำ " + NameTrn22 + " " + Less22 + " บาท", "ราคาขึ้นต่ำ " + NameTrn10 + " " + Less10 + " บาท", "ราคาขึ้นต่ำ " + NameTrn6 + " " + Less6 + " บาท", "ราคาขึ้นต่ำ " + NameTrn4 + " " + Less4 + " บาท"));

                //this.Grid1.DataSource = order;
                //this.Grid1.DataBind();
            }
            catch (Exception error)
            {

            }
        }
        protected void cmb_Province_ValueSelect1(object sender, Syncfusion.JavaScript.Web.ComboBoxEventArgs e)
        {
            var A = e.Text;
            l_IDprovince.Text = A.ToString();
            var AP = e.Text;
            lbl_Province.Text = AP.ToString();

            this.cmb_ampure.DataSource = null;
            this.cmb_district.DataSource = null;
            cmb_ampure.Text = "";
            cmb_district.Text = "";
            cmb_ampure.Value = "";
            cmb_district.Value = "";

            this.cmb_ampure.DataSource = AmpureList.GetAmpure(l_IDprovince.Text);
            

            FNGET(lbl_distance.Text);

            if (l_IDprovince.Text == "ชลบุรี")
            {
                cmb_district.Enabled = true;
            }
            else
            {
                cmb_district.Enabled = false;
            }

        }

        protected void ButtonLarge_Click(object Sender, Syncfusion.JavaScript.Web.ButtonEventArgs e)
        {
            FNGET(lbl_distance.Text);
        }

        protected void cmb_ampure_ValueSelect(object sender, Syncfusion.JavaScript.Web.ComboBoxEventArgs e)
        {
            var A = e.Value;
            string DistanceA = "";
            string Y4A = "";
            string Y3A = "";

            if (A.ToString().Contains("|"))
            {
                string[] Am = A.ToString().Split('|');
                DistanceA = Am[0];
                Y4A = Am[1];
                Y3A = Am[2];
            }
            
            var AP = e.Text;
            l_IDampur.Text = AP.ToString();
            lbl_Ampure.Text = AP.ToString();

            this.cmb_district.DataSource = null;
            cmb_district.Text = "";
            cmb_district.Value = "";


            this.cmb_ampure.DataSource = AmpureList.GetAmpure(l_IDprovince.Text);
            this.cmb_district.DataSource = DictrictList.GetDictrict(l_IDprovince.Text, l_IDampur.Text);

            lbl_distance.Text = DistanceA.ToString();
            lbl_PriceY4.Text = Y4A;
            lbl_PriceY3.Text = Y3A;

            FNGET(lbl_distance.Text);
        }

        protected void cmb_district_ValueSelect(object sender, Syncfusion.JavaScript.Web.ComboBoxEventArgs e)
        {
            var A = e.Value;
            string DistanceA = "";
            string Y4A = "";
            string Y3A = "";

            if (A.ToString().Contains("|"))
            {
                string[] Am = A.ToString().Split('|');
                DistanceA = Am[0];
                Y4A = Am[1];
                Y3A = Am[2];
            }
           
            var AP = e.Text;
            l_IDdistrict.Text = AP.ToString();
            lbl_Dictrict.Text = AP.ToString();

            this.cmb_ampure.DataSource = AmpureList.GetAmpure(l_IDprovince.Text);
            this.cmb_district.DataSource = DictrictList.GetDictrict(l_IDprovince.Text, l_IDampur.Text);
           

            lbl_distance.Text = DistanceA.ToString();
            lbl_PriceY4.Text = Y4A;
            lbl_PriceY3.Text = Y3A;

            FNGET(lbl_distance.Text);

        }

        protected void LNK1_Click(object sender, EventArgs e)
        {

           
        }

        //private async System.Threading.Tasks.Task fnAsync()
        //{
        //    var result = await NetworkServices.GetDistance();
        //    result.ForEach(c => 
        //    {
        //        var x = c.DeliveryCostID;
        //        Label6.Text = x.ToString();

        //    });

        //}

        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //   fnAsync();
        //}
    }
}
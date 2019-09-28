using Syncfusion.EJ.Export;
using Syncfusion.JavaScript.Models;
using Syncfusion.JavaScript.Web;
using Syncfusion.XlsIO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CCP_MOULDS
{
    public partial class reportma : System.Web.UI.Page
    {
        List<TreeGridColumn> Columns = new List<TreeGridColumn>();
        protected void Page_Load(object sender, EventArgs e)
        {
          
            if (!IsPostBack)
            {


                if (Request.QueryString["ST"] != null && Request.QueryString["EN"] != null)
                {
                    lbl_DateEn.Text = Request.QueryString["EN"].ToString();
                    lbl_DateSt.Text = Request.QueryString["ST"].ToString();
                    datePicker.Value = Convert.ToDateTime(lbl_DateEn.Text);
                    datePicker1.Value = Convert.ToDateTime(lbl_DateSt.Text);
                }

              
            }

            this.cmb_dep.DataSource = CDep.GetDep();

            TaskDetailsCollection TasksCollection = new TaskDetailsCollection();
                this.TreeGridControlDefault.DataSource = TasksCollection.GetData2(cmb_dep.Text, lbl_DateSt.Text, lbl_DateEn.Text);
                this.TreeGridControlDefault.DataBind();
                //Columns = this.TreeGridControlDefault.Columns;
                //TreeGridColumn column = Columns[0];

        }


        protected void btn_en_Click(object sender, EventArgs e)
        {
            //Calen_Start0.Visible = true;
            //TaskDetailsCollection TasksCollection = new TaskDetailsCollection();
            //this.TreeGridControlDefault.DataSource = TasksCollection.GetData2(lbl_DateSt.Text, lbl_DateEn.Text);
            //this.TreeGridControlDefault.DataBind();

            string HH = datePicker.Value.Value.ToString("yyyy-MM-dd");
            lbl_DateEn.Text = HH;

            string He = datePicker1.Value.Value.ToString("yyyy-MM-dd");
            lbl_DateSt.Text = He;

            TaskDetailsCollection TasksCollection = new TaskDetailsCollection();
            this.TreeGridControlDefault.DataSource = TasksCollection.GetData2(cmb_dep.Text,lbl_DateSt.Text, lbl_DateEn.Text);
            this.TreeGridControlDefault.DataBind();

            //Columns = this.TreeGridControlDefault.Columns;
            //TreeGridColumn column = Columns[0];



        }


        public class TaskDetailsCollection
        {

            public List<BusinessObject> GetData2(string Dep ,string Datest, string Dateen)
            {
                List<BusinessObject> dataCollection = new List<BusinessObject>();

                string sql = "";

                if (Dep == "")
                {
                    sql = "Select * from ViewMAHistories where (Actualdate between '" + Datest + "' and '" + Dateen + "')";
                }
                else
                {
                    sql = "Select * from ViewMAHistories where (Actualdate between '" + Datest + "' and '" + Dateen + "') and Department like '%" + Dep + "%'";
                }


              
                DataSet ds_s = new Class1().SqlGet(sql, "ViewMAHistories");
                long row = ds_s.Tables[0].Rows.Count;
                if (row != 0)
                {

                    for (int ii = 0; ii < row; ii++)
                    {
                        string DocId = ds_s.Tables["ViewMAHistories"].Rows[ii]["DocId"].ToString();
                        string InternalSerial = ds_s.Tables["ViewMAHistories"].Rows[ii]["InternalSerial"].ToString();
                        string ToolRemark = ds_s.Tables["ViewMAHistories"].Rows[ii]["ToolRemark"].ToString();
                        string ToolName = ds_s.Tables["ViewMAHistories"].Rows[ii]["ToolName"].ToString();
                        string Actualdate = ds_s.Tables["ViewMAHistories"].Rows[ii]["Actualdate"].ToString();
                        string SubmitBy = ds_s.Tables["ViewMAHistories"].Rows[ii]["SubmitBy"].ToString();
                        string RemarkText = ds_s.Tables["ViewMAHistories"].Rows[ii]["RemarkText"].ToString();

                        int DocInt; Int32.TryParse(DocId, out DocInt);

                        string sql1 = "Select * from ChecksheetItems where MAHistoryDocId = '" + DocId + "' and IsDone = '1'";
                        DataSet ds_s1 = new Class1().SqlGet(sql1, "ChecksheetItems");
                        long row1 = ds_s1.Tables[0].Rows.Count;

                        string sql0 = "Select * from ChecksheetItems where MAHistoryDocId = '" + DocId + "' and IsDone = '0'";
                        DataSet ds_s0 = new Class1().SqlGet(sql0, "ChecksheetItems");
                        long row0 = ds_s0.Tables[0].Rows.Count;

                        BusinessObject Record1 = new BusinessObject()
                        {
                            DocId = DocInt,
                            InternalSerial = InternalSerial,
                            ToolRemark = ToolRemark,
                            ToolName = ToolName,
          
                            Actualdate = Actualdate,
                            SubmitBy = SubmitBy,
                            NumPass = "ผ่าน " + row1.ToString() + " ไม่ผ่าน " + row0.ToString(),
                            Delay = "",
                            Remark = string.Format("<a href='MAremark.aspx?DocID="+ DocId + "&ST="+ Datest + "&EN="+Dateen+"'>กรอกหมายเหตุ</a>"),
                            RemarkText = RemarkText,
                            Children = new List<BusinessObject>(),
                        };

                        string sqli = "Select * from ChecksheetItems where MAHistoryDocId = '" + DocId + "'";
                        DataSet ds_si = new Class1().SqlGet(sqli, "ChecksheetItems");
                        long rowi = ds_si.Tables[0].Rows.Count;
                        if (rowi != 0)
                        {

                            for (int i0 = 0; i0 < rowi; i0++)
                            {
                                string Name = ds_si.Tables["ChecksheetItems"].Rows[i0]["Name"].ToString();
                                string IsDone = ds_si.Tables["ChecksheetItems"].Rows[i0]["IsDone"].ToString();


                                if (IsDone == "True")
                                {
                                    IsDone = "ผ่าน";
                                }
                                else if (IsDone == "False")
                                {
                                    IsDone = "ไม่ผ่าน";
                                }

                                BusinessObject Child1 = new BusinessObject()
                                {

                                    DocId = DocInt,
                                    InternalSerial = "",
                                    ToolRemark = Name,
                                    ToolName = "",
                                    Actualdate = "",
                                    SubmitBy = "",
                                    NumPass = IsDone,
                                    Delay = "",
                                    Remark = "",
                                    RemarkText = ""
                                };

                                Record1.Children.Add(Child1);
                            }
                        }

                        dataCollection.Add(Record1);
                    }
                }

                return dataCollection;
            }



        }

        protected void TreeGridControlDefault_ServerExcelExporting(object sender, Syncfusion.JavaScript.Web.TreeGridEventArgs e)
        {
            ExcelExport exp = new ExcelExport();
            TreeGridExportSettings settings = new TreeGridExportSettings();
            settings.Theme = ExportTheme.FlatLime;
            exp.Export(TreeGridControlDefault.Model, (IEnumerable)TreeGridControlDefault.DataSource, "Export.xlsx", ExcelVersion.Excel2010, new TreeGridExportSettings() { Theme = ExportTheme.BootstrapTheme });
        }

        protected void TreeGridControlDefault_ServerPdfExporting(object sender, Syncfusion.JavaScript.Web.TreeGridEventArgs e)
        {
            PdfExport exp = new PdfExport();
            TreeGridExportSettings settings = new TreeGridExportSettings();
            settings.Theme = ExportTheme.FlatLime;
            exp.Export(TreeGridControlDefault.Model, (IEnumerable)TreeGridControlDefault.DataSource, settings, "Export");
        }

        protected void queryCellInfo(object sender, Syncfusion.JavaScript.Web.TreeGridEventArgs e)
        {
            List<BusinessObject> businessObjects = e.Arguments["data"] as List<BusinessObject>;

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

           // List<BusinessObject> businessObjects =  new List<BusinessObject>();
           // var x = this.TreeGridControlDefault.SummaryRows.ToString();
           // Label1.Text = x;


            //var datt = this.TreeGridControlDefault.Columns.FindIndex(c => c.Field == "Remark");

            ////var srer = this.TreeGridControlDefault.Model.Columns[7].ToString();


            //DataTable dt = (DataTable)(this.TreeGridControlDefault.Model.DataSource); // OrdersGrid is the Grid ID 
            //  var dat = dt.Rows.Count;


            //var dd = this.TreeGridControlDefault.Columns.ElementAt(datt).DropDownData;
            //Label1.Text = datt.ToString();


        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            //TaskDetailsCollection TasksCollection = new TaskDetailsCollection();
            //this.TreeGridControlDefault.DataSource = TasksCollection.GetData2(lbl_DateSt.Text, lbl_DateEn.Text);
            //this.TreeGridControlDefault.DataBind();

            Columns = this.TreeGridControlDefault.Columns;
            TreeGridColumn column = Columns[0];
        }
        //protected void EditEvents_ServerEditRow(object sender, GridEventArgs e)
        //{
        //    EditAction(e.EventType, e.Arguments["data"]);
        //}

        //private void EditAction(string eventType, object v)
        //{
        //    Dictionary<string, object> KeyVal = v as Dictionary<string, object>;
        //    if (eventType == "endEdit")
        //    {
        //        foreach (KeyValuePair<string, object> keyval in KeyVal)
        //        {
        //            if (keyval.Key == "Remark")
        //            {
        //                Label1.Text = Convert.ToString(keyval.Key);
        //            }
        //        }
        //    }
        //}
    }
    public class BusinessObject
    {
        public int DocId { get; set; }
        public string Actualdate { get; set; }    
        public string InternalSerial { get; set; }
        public string ToolName { get; set; }
        public string ToolRemark { get; set; }
        public string SubmitBy { get; set; }
        public string NumPass { get; set; }
        public string Delay { get; set; }

        public string Remark { get; set; }

        public string RemarkText { get; set; }
        public List<BusinessObject> Children { get; set; }
    }


}
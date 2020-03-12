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
using System.Globalization;
using System.Data.SqlClient;

namespace CCP_MOULDS
{
    public partial class reportabnormal : System.Web.UI.Page 
    {
        List<Ordersl> order = new List<Ordersl>();
        string Days = ConfigurationSettings.AppSettings["Daysab"];
        protected void Page_Load(object sender, EventArgs e)
        {    
          
            if (!IsPostBack)
            {
                Session["InlineEditDataSource"] = null;

            }

            this.cmb_dep.DataSource = CDep.GetDep();

            FNGET();
            Session["InlineEditDataSource"] = order;
           
        }

        private void FNGET()
        {
            string Datestart = lbl_DateSt.Text;
            string DateEnd = lbl_DateEn.Text;

            string sql = "";

            if (cmb_dep.Text == "")
            {
                sql = "Select * from ViewRepairHistories inner join MasterFailureCodes on ViewRepairHistories.FailureCode = MasterFailureCodes.FailureCode where (InformDate between '" + Datestart + "' and '" + DateEnd + "') and MasterFailureCodes.FailureConfig = 'X'";
            }
            else
            {
                sql = "Select * from ViewRepairHistories inner join MasterFailureCodes on ViewRepairHistories.FailureCode = MasterFailureCodes.FailureCode where (InformDate between '" + Datestart + "' and '" + DateEnd + "') and MasterFailureCodes.FailureConfig = 'X' and Department like '%" + cmb_dep.Text + "%'";
            }

            if ((List<Ordersl>)Session["InlineEditDataSource"] == null)
            {

                order.Clear();

                DataSet ds_s = new Class1().SqlGet(sql, "ViewRepairHistories");
                long row = ds_s.Tables[0].Rows.Count;
                if (row != 0)
                {
                   
                    for (int i = 0; i < row; i++)
                    {
                        string ReturnDate = ds_s.Tables["ViewRepairHistories"].Rows[i]["ReturnDate"].ToString();
                        if (ReturnDate == "-")
                        {
                            ReturnDate = DateTime.Now.ToString("yyyy-MM-dd");
                        }
                        string InformDate = ds_s.Tables["ViewRepairHistories"].Rows[i]["InformDate"].ToString();

                        DateTime ReturnDateD = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd", CultureInfo.GetCultureInfo("en-US")));
                        DateTime InformDateD = Convert.ToDateTime(InformDate);

                        TimeSpan DiffDate = ReturnDateD - InformDateD;
                        int Dif = DiffDate.Days;
                        int Diffcon; int.TryParse(Days, out Diffcon);

                        if (Dif == Dif)
                        {
                            #region
                            string RepairJobId = ds_s.Tables["ViewRepairHistories"].Rows[i]["RepairJobId"].ToString();

                            string InternalSerial = ds_s.Tables["ViewRepairHistories"].Rows[i]["InternalSerial"].ToString();
                            string ToolName = ds_s.Tables["ViewRepairHistories"].Rows[i]["ToolName"].ToString();
                            string Problem = ds_s.Tables["ViewRepairHistories"].Rows[i]["Problem"].ToString();
                            string InformByFullname = ds_s.Tables["ViewRepairHistories"].Rows[i]["InformByFullname"].ToString();

                            string Remark = ds_s.Tables["ViewRepairHistories"].Rows[i]["Remark"].ToString();
                            string RepairTagId = ds_s.Tables["ViewRepairHistories"].Rows[i]["RepairTagId"].ToString();
                            string RepairDangerTagId = ds_s.Tables["ViewRepairHistories"].Rows[i]["RepairDangerTagId"].ToString();

                            string RepairType = ds_s.Tables["ViewRepairHistories"].Rows[i]["RepairType"].ToString();
                            string RatingScore = ds_s.Tables["ViewRepairHistories"].Rows[i]["RatingScore"].ToString();
                            string UserComment = ds_s.Tables["ViewRepairHistories"].Rows[i]["UserComment"].ToString();
                            string CommentBy = ds_s.Tables["ViewRepairHistories"].Rows[i]["CommentBy"].ToString();
                            string FailureCode = ds_s.Tables["ViewRepairHistories"].Rows[i]["FailureCode"].ToString();
                            string FailureDescriptionEng = ds_s.Tables["ViewRepairHistories"].Rows[i]["FailureDescriptionEng"].ToString();
                            string FailureDescriptionTha = ds_s.Tables["ViewRepairHistories"].Rows[i]["FailureDescriptionTha"].ToString();
                            string RepairCode = ds_s.Tables["ViewRepairHistories"].Rows[i]["RepairCode"].ToString();
                            string RepairDescriptionEng = ds_s.Tables["ViewRepairHistories"].Rows[i]["RepairDescriptionEng"].ToString();
                            string RepairDescriptionTha = ds_s.Tables["ViewRepairHistories"].Rows[i]["RepairDescriptionTha"].ToString();
                            string RootCause = ds_s.Tables["ViewRepairHistories"].Rows[i]["RootCause"].ToString();
                            string Solution = ds_s.Tables["ViewRepairHistories"].Rows[i]["Solution"].ToString();
                            string Engineer = ds_s.Tables["ViewRepairHistories"].Rows[i]["Engineer"].ToString();
                            string RemarkText3 = ds_s.Tables["ViewRepairHistories"].Rows[i]["RemarkText3"].ToString();
                            #endregion

                            string ReturnDate1 = ds_s.Tables["ViewRepairHistories"].Rows[i]["ReturnDate"].ToString();
                            if (ReturnDate1 != "-")
                            {
                                DateTime ReturnDateD1 = Convert.ToDateTime(ReturnDate1);
                                ReturnDate1 = ReturnDateD1.ToString("yyyy-MM-dd HH:mm:ss");
                            }

                            InformDate = InformDateD.ToString("yyyy-MM-dd HH:mm:ss");

                            order.Add(new Ordersl(RepairJobId, InternalSerial, ToolName, Problem, InformByFullname, InformDate, Remark, RepairTagId, RepairDangerTagId, ReturnDate1, RepairType, RatingScore, UserComment, CommentBy, FailureCode, FailureDescriptionEng, FailureDescriptionTha, RepairCode, RepairDescriptionEng, RepairDescriptionTha, RootCause, Solution, Engineer, RemarkText3));
                        }
                    }

                    lbl_num.Text = "จำนวนทั้งหมด " + order.Count.ToString() + " รายการ";
                }
                else
                {

                    lbl_num.Text = "";
                }

            }
            else
            {
                order = (List<Ordersl>)Session["InlineEditDataSource"];
            }

            this.Grid1.DataSource = order;
            this.Grid1.DataBind();

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


        protected void Grid1_ServerEditRow(object sender, Syncfusion.JavaScript.Web.GridEventArgs e)
        {
            EditAction(e.EventType, e.Arguments["data"]);
        }


        protected void EditAction(string eventType, object record)
        {
            List<Ordersl> data = Session["InlineEditDataSource"] as List<Ordersl>;
            Dictionary<string, object> KeyVal = record as Dictionary<string, object>;
            if (eventType == "endEdit")
            {
                Ordersl value = new Ordersl();
                foreach (KeyValuePair<string, object> keyval in KeyVal)
                {
                    if (keyval.Key == "RepairJobId")
                    {
                        value = data.Where(d => d.RepairJobId == (string)keyval.Value).FirstOrDefault();
                        value.RepairJobId = Convert.ToString(keyval.Value);
                    }
                    else if (keyval.Key == "InternalSerial")
                    {
                        value.InternalSerial = Convert.ToString(keyval.Value);
                    }
                    else if (keyval.Key == "ToolName")
                    {
                        value.ToolName = Convert.ToString(keyval.Value);
                    }
                    else if (keyval.Key == "Problem")
                    {
                        value.Problem = Convert.ToString(keyval.Value);
                    }
                    else if (keyval.Key == "InformByFullname")
                    {
                        value.InformByFullname = Convert.ToString(keyval.Value);
                    }
                    else if (keyval.Key == "InformDate")
                    {
                        value.InformDate = Convert.ToString(keyval.Value);
                    }
                    else if (keyval.Key == "Remark")
                    {
                        value.Remark = Convert.ToString(keyval.Value);
                    }
                    else if (keyval.Key == "RepairTagId")
                    {
                        value.RepairTagId = Convert.ToString(keyval.Value);
                    }
                    else if (keyval.Key == "RepairDangerTagId")
                    {
                        value.RepairDangerTagId = Convert.ToString(keyval.Value);
                    }
                    else if (keyval.Key == "ReturnDate")
                    {
                        value.ReturnDate = Convert.ToString(keyval.Value);
                    }
                    else if (keyval.Key == "RepairType")
                    {
                        value.RepairType = Convert.ToString(keyval.Value);
                    }
                    else if (keyval.Key == "RatingScore")
                    {
                        value.RatingScore = Convert.ToString(keyval.Value);
                    }
                    else if (keyval.Key == "UserComment")
                    {
                        value.UserComment = Convert.ToString(keyval.Value);
                    }
                    else if (keyval.Key == "CommentBy")
                    {
                        value.CommentBy = Convert.ToString(keyval.Value);
                    }
                    else if (keyval.Key == "FailureCode")
                    {
                        value.FailureCode = Convert.ToString(keyval.Value);
                    }
                    else if (keyval.Key == "FailureDescriptionEng")
                    {
                        value.FailureDescriptionEng = Convert.ToString(keyval.Value);
                    }
                    else if (keyval.Key == "FailureDescriptionTha")
                    {
                        value.FailureDescriptionTha = Convert.ToString(keyval.Value);
                    }
                    else if (keyval.Key == "RepairCode")
                    {
                        value.RepairCode = Convert.ToString(keyval.Value);
                    }
                    else if (keyval.Key == "RepairDescriptionEng")
                    {
                        value.RepairDescriptionEng = Convert.ToString(keyval.Value);
                    }
                    else if (keyval.Key == "RepairDescriptionTha")
                    {
                        value.RepairDescriptionTha = Convert.ToString(keyval.Value);
                    }
                    else if (keyval.Key == "RootCause")
                    {
                        value.RootCause = Convert.ToString(keyval.Value);
                    }
                    else if (keyval.Key == "Solution")
                    {
                        value.Solution = Convert.ToString(keyval.Value);
                    }
                    else if (keyval.Key == "Engineer")
                    {
                        value.Engineer = Convert.ToString(keyval.Value);
                    }
                    else if (keyval.Key == "RemarkText")
                    {
                        value.RemarkText = Convert.ToString(keyval.Value);
                    }
                }
            }

            Session["InlineEditDataSource"] = data;
            this.Grid1.DataSource = data;
            this.Grid1.DataBind();


        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            if (datePicker.Value != null && datePicker1.Value != null)
            {
                Session["InlineEditDataSource"] = null;
                //order = null;

                this.Grid1.DataSource = null;
                this.Grid1.DataBind();

                string HH = datePicker.Value.Value.ToString("yyyy-MM-dd", new CultureInfo("en-US"));
                lbl_DateEn.Text = HH;

                string He = datePicker1.Value.Value.ToString("yyyy-MM-dd", new CultureInfo("en-US"));
                lbl_DateSt.Text = He;

                FNGET();
                Session["InlineEditDataSource"] = order;

                if (order.Count == 0)
                {
                    lbl_mess.Text = "ไม่พบรายการ";
                }
                else
                {
                    lbl_mess.Text = "";
                }

            }

            lbl_save.Text = "";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            List<Ordersl> data = Session["InlineEditDataSource"] as List<Ordersl>;
            foreach (var dd in data)
            {
                string Text = dd.RemarkText;
                string DocId = dd.RepairJobId;

                FN_Update(DocId, Text);
            }

            lbl_save.Text = "บันทึกสำเร็จ";
        }

        private void FN_Update(string DocId, string Text)
        {
            string sqlbb1 = "update RepairHistories set RemarkText3 = @RemarkText3 where RepairJobId = '" + DocId + "' ";
            SqlParameterCollection para = new SqlCommand().Parameters;
            para.AddWithValue("RemarkText3", SqlDbType.VarChar).Value = Text;

            int ibom = new Class1().SqlExecute(sqlbb1, para);
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
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CCP_MOULDS
{
    public partial class MAremark : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("TH");
            if (!IsPostBack)
            {
                if (Request.QueryString["DocID"] != null && Request.QueryString["ST"] != null && Request.QueryString["EN"] != null)
                {
                    DocId.Text = Request.QueryString["DocID"].ToString();

                    lblST.Text = Request.QueryString["ST"].ToString();
                    lblEN.Text = Request.QueryString["EN"].ToString();
                    FN_Get();
                }
                else
                {
                    Response.Redirect("reportma.aspx");
                }
            }
        }

        private void FN_Get()
        {
            try
            {
                string sql = "Select * from MAHistories where DocId = '"+DocId.Text+"'";
                DataSet ds_s = new Class1().SqlGet(sql, "MAHistories");
                long row = ds_s.Tables[0].Rows.Count;
                if (row != 0)
                {
                    string InternalSerial = ds_s.Tables["MAHistories"].Rows[0]["InternalSerial"].ToString();
                    string ToolRemark = ds_s.Tables["MAHistories"].Rows[0]["ToolRemark"].ToString();
                    string ToolName = ds_s.Tables["MAHistories"].Rows[0]["ToolName"].ToString();
                    string Actualdate = ds_s.Tables["MAHistories"].Rows[0]["Actualdate"].ToString();
                    string SubmitBy = ds_s.Tables["MAHistories"].Rows[0]["SubmitBy"].ToString();
                    string RemarkText = ds_s.Tables["MAHistories"].Rows[0]["RemarkText"].ToString();

                    TInternalSerial.Text = InternalSerial;
                    TToolRemark.Text = ToolRemark;
                    TToolName.Text = ToolName;
                    TActualdate.Text = Actualdate;
                    TSubmitBy.Text = SubmitBy;
                        TRemark.Text = RemarkText;
                }
            }
            catch (Exception error)
            {

            }        
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            FN_Update(DocId.Text,TRemark.Text);

            lbl_save.Text = "บันทึกหมายเหตุสำเร็จ";
            
        }

        private void FN_Update(string Doc, string Text)
        {
            string sqlbb1 = "update MAHistories set RemarkText = @RemarkText where DocId = '" + Doc + "' ";
            SqlParameterCollection para = new SqlCommand().Parameters;
            para.AddWithValue("RemarkText", SqlDbType.VarChar).Value = Text;

            int ibom = new Class1().SqlExecute(sqlbb1, para);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("reportma.aspx?ST=" + lblST.Text + "&EN="+lblEN.Text+"");

        }
    }
}
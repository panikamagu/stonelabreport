
using Syncfusion.JavaScript;
using Syncfusion.JavaScript.DataSources;
using Syncfusion.JavaScript.Models;
using Syncfusion.JavaScript.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Syncfusion.DocIO;
using Syncfusion.XlsIO;
using Syncfusion.Linq;
using Syncfusion.EJ.Export;
using System.Collections;
using System.Data;
using CCP_MOULDS;
using System.Data.SqlClient;

namespace Sample
{
    public partial class Default : System.Web.UI.Page
    {

        List<Orders> order = new List<Orders>();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {

                Plant();
                Group();

                //this.cb_Plant.DataSource = ListPlant.GetPlantList();
                //this.cb_Group.DataSource = ListGroup.GetGroupList();

            }
            FN_Get();

        }

        private void BindDataSource()

        {

            int code = 10000;

            for (int i = 1; i < 10; i++)

            {

                //order.Add(new Orders(code + 1, "ALFKI", i + 0, 2.3 * i, new DateTime(1991, 05, 15), "Berlin"));

                //order.Add(new Orders(code + 2, "ANATR", i + 2, 3.3 * i, new DateTime(1990, 04, 04), "Madrid"));

                //order.Add(new Orders(code + 3, "ANTON", i + 1, 4.3 * i, new DateTime(1957, 11, 30), "Cholchester"));

                //order.Add(new Orders(code + 4, "BLONP", i + 3, 5.3 * i, new DateTime(1930, 10, 22), "Marseille"));

                //order.Add(new Orders(code + 5, "BOLID", i + 4, 6.3 * i, new DateTime(1953, 02, 18), "Tsawassen"));

                //code += 5;

            }

            this.FlatGrid.DataSource = order;

            this.FlatGrid.DataBind();

        }

        private void FN_Get()
        {
            try
            {
                string PlantID = "";
                string PlantName = "";
                string GroupID = "";
                string GroupName = "";


                if (cb_Plant1.SelectedValue == "0")
                {
                    //mess
                    lbl_error.Text = "กรุณาเลือกโรงงาน";
                    lbl_error.Focus();

                }
                else
                {
                  
                    if (cb_Plant1.SelectedValue.ToString() != "0")
                    {
                        //String[] Plant = cb_Plant1.SelectedValue.ToString().Split('|');
                        PlantID = cb_Plant1.SelectedValue;// Plant[0];
                        //PlantName = Plant[1];
                    }

                    if (cb_Group1.SelectedValue.ToString() != "0")
                    {
                        //String[] Group = cb_Group1.SelectedValue.ToString().Split('|');
                        GroupID = cb_Group1.SelectedValue;// Group[0];
                        //GroupName = Group[1];
                    }


                    string sqly = "";


                    if (PlantID == "")
                    {
                        sqly = "Select GROUPMOULDNAME,MOULDID,MOULDDESCRIPTION" +
                                        ",MOULDSIZE,MOULDTHICKNESS,MOULDEA,PLANTID,PLANTNAME From VIEWMOULDS";
                    }
                    else if (PlantID != "" && GroupID == "")
                    {
                        sqly = "Select GROUPMOULDNAME,MOULDID,MOULDDESCRIPTION" +
                                        ",MOULDSIZE,MOULDTHICKNESS,MOULDEA,PLANTID,PLANTNAME  From VIEWMOULDS where PLANTID = '" + PlantID + "'";

                    }
                    else if (PlantID != "" && GroupID != "")
                    {
                        sqly = "Select GROUPMOULDNAME,MOULDID,MOULDDESCRIPTION" +
                                        ",MOULDSIZE,MOULDTHICKNESS,MOULDEA,PLANTID,PLANTNAME  From VIEWMOULDS where GROUPMOULDID = '" + GroupID + "' and PLANTID = '" + PlantID + "'";

                    }


                    long rowy = 0;
                    DataSet dsy = new Class1().SqlGet(sqly, "VIEWMOULDS");
                    rowy = dsy.Tables[0].Rows.Count;
                    if (rowy != 0)
                    {
                        for (int i = 0; i < rowy; i++)
                        {
                            string GROUPMOULDNAME = dsy.Tables[0].Rows[i]["GROUPMOULDNAME"].ToString();
                            string MOULDID = dsy.Tables[0].Rows[i]["MOULDID"].ToString();
                            string MOULDDESCRIPTION = dsy.Tables[0].Rows[i]["MOULDDESCRIPTION"].ToString();
                            string MOULDSIZE = dsy.Tables[0].Rows[i]["MOULDSIZE"].ToString();
                            string MOULDTHICKNESS = dsy.Tables[0].Rows[i]["MOULDTHICKNESS"].ToString();
                            string MOULDEA = dsy.Tables[0].Rows[i]["MOULDEA"].ToString();
                            string PLANTID = dsy.Tables[0].Rows[i]["PLANTID"].ToString();
                            string PLANTNAME = dsy.Tables[0].Rows[i]["PLANTNAME"].ToString();

                            order.Add(new Orders(GROUPMOULDNAME, MOULDID, MOULDDESCRIPTION, MOULDSIZE, MOULDTHICKNESS, MOULDEA, PLANTID, PLANTNAME));

                            //Grid1.DataSource = dsy;
                            //Grid1.DataBind();
                        }

                        this.FlatGrid.DataSource = order;
                        this.FlatGrid.DataBind();
                    }
                }
            }
            catch (Exception error)
            {
                lbl_error.Text = error + " Get";

            }
        }

        private void Plant()
        {
            long rowy = 0;
            String sqly = "Select PLANTID,PLANTNAME From PLANTS";
            DataSet dsy = new Class1().SqlGet(sqly, "PLANTS");
            rowy = dsy.Tables[0].Rows.Count;
            if (rowy != 0)
            {
                cb_Plant1.Items.Add(new ListItem("กรุณาเลือก", "0"));
                for (int i = 0; i < rowy; i++)
                {
                    string PLANTID = dsy.Tables[0].Rows[i]["PLANTID"].ToString();
                    string PLANTNAME = dsy.Tables[0].Rows[i]["PLANTNAME"].ToString();

                    cb_Plant1.Items.Add(new ListItem(PLANTID + "|" + PLANTNAME, PLANTID));


                }
            }

        }

        private void Group()
        {
            long rowy = 0;
            String sqly = "Select GROUPMOULDID,GROUPMOULDNAME From GROUPMOULDS";
            DataSet dsy = new Class1().SqlGet(sqly, "GROUPMOULDS");
            rowy = dsy.Tables[0].Rows.Count;
            if (rowy != 0)
            {
                cb_Group1.Items.Add(new ListItem("ทั้งหมด", "0"));

                for (int i = 0; i < rowy; i++)
                {
                    string GROUPMOULDID = dsy.Tables[0].Rows[i]["GROUPMOULDID"].ToString();
                    string GROUPMOULDNAME = dsy.Tables[0].Rows[i]["GROUPMOULDNAME"].ToString();

                    cb_Group1.Items.Add(new ListItem(GROUPMOULDID + "|" + GROUPMOULDNAME, GROUPMOULDID));
                }
            }
        }

        [Serializable]

        public class Order000s

        {

            public Order000s()

            {



            }

            public Order000s(long OrderId, string CustomerId, int EmployeeId, double Freight, DateTime OrderDate, string ShipCity)

            {

                this.OrderID = OrderId;

                this.CustomerID = CustomerId;

                this.EmployeeID = EmployeeId;

                this.Freight = Freight;

                this.OrderDate = OrderDate;

                this.ShipCity = ShipCity;

            }

            public long OrderID { get; set; }

            public string CustomerID { get; set; }

            public int EmployeeID { get; set; }

            public double Freight { get; set; }

            public DateTime OrderDate { get; set; }

            public string ShipCity { get; set; }

        }

        [Serializable]

        public class Orders

        {

            public Orders()
            {

            }

            public Orders(string GROUPMOULDNAME, string MOULDID, string MOULDDESCRIPTION, string MOULDSIZE, string MOULDTHICKNESS, string MOULDEA, string PLANTID, string PLANTNAME)

            {

                this.GROUPMOULDNAME = GROUPMOULDNAME;

                this.MOULDID = MOULDID;

                this.MOULDDESCRIPTION = MOULDDESCRIPTION;

                this.MOULDSIZE = MOULDSIZE;

                this.MOULDTHICKNESS = MOULDTHICKNESS;

                this.MOULDEA = MOULDEA;

                this.PLANTID = PLANTID;

                this.PLANTNAME = PLANTNAME;

            }

            public string GROUPMOULDNAME { get; set; }

            public string MOULDID { get; set; }

            public string MOULDDESCRIPTION { get; set; }

            public string MOULDSIZE { get; set; }

            public string MOULDTHICKNESS { get; set; }

            public string MOULDEA { get; set; }

            public string PLANTID { get; set; }

            public string PLANTNAME { get; set; }

        }


        private void FN_Insertstring(string MOULDID, string MOULDGROUPID, string MOULDDESCRIPTION, string MOULDSIZE, string MOULDTHICKNESS, string MOULDEA
   , string MOULDUNIT, string MOULDPLANT, string MOULDCREATEDATE, string MOULDCREATEBY, string MOULDEDITDATE, string MOULDEDITBY, string MOULDSTATUS)
        {
            try
            {
                string sql = "select * from MOULDS where MOULDID = ''";//and (H_Head_Reject = '0' or H_Head_Reject is null)
                long row = 0;
                DataSet ds = new Class1().SqlGet(sql, "TBL_Master_EmpSale");
                row = ds.Tables[0].Rows.Count;
                if (row != 0)
                {
                    string sqlbb = "update MOULDS set MOULDDESCRIPTION = @MOULDDESCRIPTION,MOULDSIZE = @MOULDSIZE,MOULDTHICKNESS = @MOULDTHICKNESS" +
                        "MOULDEA = @MOULDEA,MOULDEDITBY = @MOULDEDITBY,MOULDEDITDATE = @MOULDEDITDATE,MOULDEDITDATE = @MOULDEDITDATE where MOULDID = '" + MOULDID.Trim() + "'";
                    SqlParameterCollection para2 = new SqlCommand().Parameters;
                    para2.AddWithValue("MOULDDESCRIPTION", SqlDbType.Int).Value = MOULDDESCRIPTION;
                    para2.AddWithValue("MOULDSIZE", SqlDbType.Int).Value = MOULDSIZE;
                    para2.AddWithValue("MOULDTHICKNESS", SqlDbType.Int).Value = MOULDTHICKNESS;
                    para2.AddWithValue("MOULDEA", SqlDbType.Int).Value = MOULDEA;
                    para2.AddWithValue("MOULDEDITBY", SqlDbType.Int).Value = MOULDEDITBY;
                    para2.AddWithValue("MOULDEDITDATE", SqlDbType.Int).Value = MOULDEDITDATE;
                    para2.AddWithValue("MOULDTHICKNESS", SqlDbType.Int).Value = MOULDTHICKNESS;


                    int ibo = new Class1().SqlExecute(sqlbb, para2);
                }
                else
                {
                    string sqlbb = "insert into MOULDS(MOULDID,MOULDGROUPID,MOULDDESCRIPTION,MOULDSIZE,MOULDTHICKNESS,MOULDEA,MOULDUNIT,MOULDPLANT" +
                        ",MOULDCREATEDATE,MOULDCREATEBY,MOULDEDITDATE,MOULDEDITBY,MOULDSTATUS)values(@MOULDID,@MOULDGROUPID,@MOULDDESCRIPTION," +
                        "@MOULDSIZE,@MOULDTHICKNESS,@MOULDEA,@MOULDUNIT,@MOULDPLANT,@MOULDCREATEDATE,@MOULDCREATEBY,@MOULDEDITDATE,@MOULDEDITBY," +
                        "@MOULDSTATUS)";
                    SqlParameterCollection para2 = new SqlCommand().Parameters;
                    para2.AddWithValue("MOULDID", SqlDbType.Int).Value = MOULDID;
                    para2.AddWithValue("MOULDGROUPID", SqlDbType.Int).Value = MOULDGROUPID;
                    para2.AddWithValue("MOULDDESCRIPTION", SqlDbType.Int).Value = MOULDDESCRIPTION;
                    para2.AddWithValue("MOULDSIZE", SqlDbType.Int).Value = MOULDSIZE;
                    para2.AddWithValue("MOULDTHICKNESS", SqlDbType.Int).Value = MOULDTHICKNESS;
                    para2.AddWithValue("MOULDEA", SqlDbType.Int).Value = MOULDEA;
                    para2.AddWithValue("MOULDUNIT", SqlDbType.Int).Value = MOULDUNIT;
                    para2.AddWithValue("MOULDPLANT", SqlDbType.Int).Value = MOULDPLANT;
                    para2.AddWithValue("MOULDCREATEBY", SqlDbType.Int).Value = MOULDEDITBY;
                    para2.AddWithValue("MOULDCREATEDATE", SqlDbType.Int).Value = MOULDEDITDATE;
                    para2.AddWithValue("MOULDEDITBY", SqlDbType.Int).Value = MOULDEDITBY;
                    para2.AddWithValue("MOULDEDITDATE", SqlDbType.Int).Value = MOULDEDITDATE;
                    para2.AddWithValue("MOULDSTATUS", SqlDbType.Int).Value = MOULDSTATUS;


                    int ibo = new Class1().SqlExecute(sqlbb, para2);
                }
            }
            catch (Exception error)
            {
                lbl_error.Text = "insert" + error;
            }

        }

        private void Clear()
        {
            lbl_Idgroup.Text = "";
            lbl_idmould.Text = "";
            txt_DetailM.Text = "";
            txt_group.Text = "";
            txt_Plant.Text = "";
            txt_PlantId.Text = "";
            txt_qtym.Text = "";
            txt_sizeM.Text = "";
            txt_THICKM.Text = "";
        }



        protected void FlatGrid_ServerExcelExporting(object sender, Syncfusion.JavaScript.Web.GridEventArgs e)

        {

            ExcelExport exp = new ExcelExport();

            exp.Export(FlatGrid.Model, (IEnumerable)FlatGrid.DataSource, "Export.xlsx", ExcelVersion.Excel2010, true, true, "flat-lime");

        }



        protected void FlatGrid_ServerWordExporting(object sender, Syncfusion.JavaScript.Web.GridEventArgs e)

        {

            WordExport exp = new WordExport();

            exp.Export(FlatGrid.Model, (IEnumerable)FlatGrid.DataSource, "Export.docx", true, true, "flat-lime");

        }



        protected void FlatGrid_ServerPdfExporting(object sender, Syncfusion.JavaScript.Web.GridEventArgs e)

        {

            PdfExport exp = new PdfExport();

            exp.Export(FlatGrid.Model, (IEnumerable)FlatGrid.DataSource, "Export.pdf", true, true, "flat-lime");

        }

        protected void cb_Group1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_Plant1.SelectedValue != "0" && cb_Group1.SelectedValue != "0")
            {
                btn_Add.Visible = true;
            }
            else { btn_Add.Visible = false; }
        }

        protected void cb_Plant1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbl_error.Text = "";
        }

        protected void btn_Find_Click(object Sender, ButtonEventArgs e)
        {
            FN_Get();
        }

        protected void btn_Add_Click(object sender, EventArgs e)
        {
            Panel1.Visible = true;

            lbl_Idgroup.Text = cb_Group1.SelectedValue;
            txt_group.Text = cb_Group1.SelectedItem.ToString();
            txt_PlantId.Text = cb_Plant1.SelectedValue;
            txt_Plant.Text = cb_Plant1.SelectedItem.ToString();

            lbl_error.Text = "";
        }

        protected void btn_Add_a_Click(object sender, EventArgs e)
        {
            string MOULDID = "";
            string MOULDGROUPID = lbl_Idgroup.Text;
            string MOULDDESCRIPTION = txt_DetailM.Text;
            string MOULDSIZE = txt_THICKM.Text;
            string MOULDTHICKNESS = txt_THICKM.Text;
            string MOULDEA = txt_qtym.Text;
            string MOULDUNIT = "EA";
            string MOULDPLANT = txt_PlantId.Text;
            string MOULDCREATEDATE = txt_Plant.Text;
            string MOULDCREATEBY = "Admin";
            string MOULDEDITDATE = DateTime.Now.ToString("yyyy-MM-dd");
            string MOULDEDITBY = "Admin";
            string MOULDSTATUS = "ACTIVE";

            string sql = "select  max(cast([MOULDID] as int)) as MOULDID  from MOULDS";//and (H_Head_Reject = '0' or H_Head_Reject is null)
            long row = 0;
            DataSet ds = new Class1().SqlGet(sql, "TBL_Master_EmpSale");
            row = ds.Tables[0].Rows.Count;
            if (row != 0)
            {
                string inauto = ds.Tables[0].Rows[0]["MOULDID"].ToString();
                int MOULDIDint; int.TryParse(MOULDID, out MOULDIDint);
                int autoi = MOULDIDint + 1;

                MOULDID = autoi.ToString();
            }


            FN_Insertstring(MOULDID, MOULDGROUPID, MOULDDESCRIPTION, MOULDSIZE, MOULDTHICKNESS, MOULDEA, MOULDUNIT, MOULDPLANT, MOULDCREATEDATE, MOULDCREATEBY, MOULDEDITDATE, MOULDEDITBY, MOULDSTATUS);

            lbl_error.Text = "บันทึกข้อมูลเรียบร้อย";

            Clear();
            Panel1.Visible = false;
            FN_Get();
        }

        protected void btn_Cancel_Click(object sender, EventArgs e)
        {

            Clear();
            Panel1.Visible = true;
        }
    }
    }


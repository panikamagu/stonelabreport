using CCP_MOULDS.Models;
using CCP_MOULDS.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CCP_MOULDS
{
    public class ProvinceList
    {
        public string Ptext { get; set; }
        public string Pvalue { get; set; }

        public string Pvalueqq { get; set; }

        async void fn()
        {
            var result = await NetworkServices.GetDistance();
            result.ForEach(c =>
            {
                var P_Province = c.DeliveryCostProvince;
            });
        }

        //public static async System.Threading.Tasks.Task<List<ProvinceList>> GetProvinceAsync()
        //{
        //    List<ProvinceList> Provinceget = new List<ProvinceList>();

        //    var result = await NetworkServices.GetDistance();

        //    #region
        //    //foreach (var name in result)
        //    //{
        //    //    var P_Province = name.DeliveryCostProvince;

        //    //}
        //    #endregion

        //    result.ForEach(c =>
        //    {
        //        var P_Province = c.DeliveryCostProvince;
        //        Provinceget.Add(new ProvinceList { Pvalueqq = P_Province.ToString()});
        //    }
        //    );

        //    return Provinceget;
        //}


        public static List<ProvinceList> GetProvince()
        {


            List<ProvinceList> Province = new List<ProvinceList>();

            #region
            //string sql = "Select ProvinceId,ProvinceName from tbl_Province";
            //DataSet ds_s = new Class1().SqlGet(sql, "tbl_Provice");
            //long row = ds_s.Tables[0].Rows.Count;
            //if (row != 0)
            //{
            //    for (int i = 0; i < row; i++)
            //    {
            //        string ProvinceId = ds_s.Tables["tbl_Provice"].Rows[i]["ProvinceId"].ToString();
            //        string provincename = ds_s.Tables["tbl_Provice"].Rows[i]["ProvinceName"].ToString();
            //        Province.Add(new ProvinceList { Ptext = provincename, Pvalue = ProvinceId });

            //    }
            //}
            #endregion

            ApiGet apiData = new ApiGet();

            var provincename = JsonConvert.DeserializeObject<List<DeliveryCost>>(apiData.GetDataDeliveryCost("http://ccp-info.com/APIDeliveryCost/api/DeliveryCost/getdata"));
            var q = provincename.GroupBy(x => x.DeliveryCostProvince).Select(x => x);
            foreach (var d in q)
            {
                Province.Add(new ProvinceList { Ptext = d.Key});//, Pvalue = ProvinceId 
            }

            return Province;
        }

    }

    public class AmpureList
    {
        public string Atext { get; set; }
        public string Avalue { get; set; }
        public static List<AmpureList> GetAmpure(string Province)
        {
            List<AmpureList> Ampure = new List<AmpureList>();

            #region
            //string sql = "Select AmphurId,AmphurName from tbl_Amphur where ProvinceId = '" + Province.Trim() + "'";
            //DataSet ds_s = new Class1().SqlGet(sql, "tbl_Amphur");
            //long row = ds_s.Tables[0].Rows.Count;
            //if (row != 0)
            //{
            //    for (int i = 0; i < row; i++)
            //    {
            //        string amphurname = ds_s.Tables["tbl_Amphur"].Rows[i]["AmphurName"].ToString();
            //        string AmphurId = ds_s.Tables["tbl_Amphur"].Rows[i]["AmphurId"].ToString();
            //        Ampure.Add(new AmpureList { Atext = amphurname, Avalue = AmphurId });
            //    }
            //}
            #endregion

            ApiGet apiData = new ApiGet();

            var provincename = JsonConvert.DeserializeObject<List<DeliveryCost>>(apiData.GetDataDeliveryCost("http://ccp-info.com/APIDeliveryCost/api/DeliveryCost/getdata"));
            var q = provincename.Where(x => x.DeliveryCostProvince == Province).GroupBy(x => new { x.DeliveryCostProvince,x.DeliveryCostDistrict, x.DeliveryCostDistance, x.DeliveryCostY4, x.DeliveryCostY3 });
           
            foreach (var d in q)
            {
                Ampure.Add(new AmpureList { Atext = d.Key.DeliveryCostDistrict , Avalue = d.Key.DeliveryCostDistance+"|"+d.Key.DeliveryCostY4+"|"+d.Key.DeliveryCostY3});
            }

            return Ampure;
        }

    }

    public class DictrictList
    {
        public string Dtext { get; set; }
        public string Dvalue { get; set; }
        public static List<DictrictList> GetDictrict(string Province, string Amphur)
        {
            List<DictrictList> Dictrict = new List<DictrictList>();
            #region
            //string sql = "Select DistrictId,DistrictName from tbl_District where ProvinceId = '" + Province.Trim() + "' AND AmphurId = '" + Amphur.Trim() + "'";
            //DataSet ds_s = new Class1().SqlGet(sql, "tbl_District");
            //long row = ds_s.Tables[0].Rows.Count;
            //if (row != 0)
            //{
            //    for (int i = 0; i < row; i++)
            //    {
            //        string DistrictName = ds_s.Tables["tbl_District"].Rows[i]["DistrictName"].ToString();
            //        string DistrictId = ds_s.Tables["tbl_District"].Rows[i]["DistrictId"].ToString();

            //        Dictrict.Add(new DictrictList { Dtext = DistrictName, Dvalue = DistrictId });
            //    }
            //}
            #endregion

            ApiGet apiData = new ApiGet();

            var provincename = JsonConvert.DeserializeObject<List<DeliveryCost>>(apiData.GetDataDeliveryCost("http://ccp-info.com/APIDeliveryCost/api/DeliveryCost/getdata"));
            var q = provincename.Where(x => x.DeliveryCostProvince == Province && x.DeliveryCostDistrict == Amphur);//.GroupBy(x => new { x.DeliveryCostProvince, x.DeliveryCostDistrict,x.DeliveryCostTambon, x.DeliveryCostDistance, x.DeliveryCostY4, x.DeliveryCostY3 });

            foreach (var d in q)
            {
                Dictrict.Add(new DictrictList { Dtext = d.DeliveryCostTambon, Dvalue = d.DeliveryCostDistance + "|" + d.DeliveryCostY4 + "|" + d.DeliveryCostY3+"|"+d.DeliveryCostID });
            }

            return Dictrict;
        }

    }

    [Serializable]

    public class Ordersl

    {

        public Ordersl()
        {

        }

        public Ordersl(string RepairJobId, string InternalSerial, string ToolName, string Problem, string InformByFullname, string InformDate, string Remark, string RepairTagId, string RepairDangerTagId, string ReturnDate, string RepairType, string RatingScore, string UserComment, string CommentBy, string FailureCode, string FailureDescriptionEng, string FailureDescriptionTha, string RepairCode, string RepairDescriptionEng, string RepairDescriptionTha, string RootCause, string Solution, string Engineer,string RemarkText)

        {
            this.RepairJobId = RepairJobId;
            this.InternalSerial = InternalSerial;
            this.ToolName = ToolName;
            this.Problem = Problem;
            this.InformByFullname = InformByFullname;
            this.InformDate = InformDate;
            this.Remark = Remark;
            this.RepairTagId = RepairTagId;
            this.RepairDangerTagId = RepairDangerTagId;
            this.ReturnDate = ReturnDate;
            this.RepairType = RepairType;
            this.RatingScore = RatingScore;
            this.UserComment = UserComment;
            this.CommentBy = CommentBy;
            this.FailureCode = FailureCode;
            this.FailureDescriptionEng = FailureDescriptionEng;
            this.FailureDescriptionTha = FailureDescriptionTha;
            this.RepairCode = RepairCode;
            this.RepairDescriptionEng = RepairDescriptionEng;
            this.RepairDescriptionTha = RepairDescriptionTha;
            this.RootCause = RootCause;
            this.Solution = Solution;
            this.Engineer = Engineer;
            this.RemarkText = RemarkText;

        }

        public string RepairJobId { get; set; }
        public string InternalSerial { get; set; }
        public string ToolName { get; set; }
        public string Problem { get; set; }
        public string InformByFullname { get; set; }
        public string InformDate { get; set; }
        public string Remark { get; set; }
        public string RepairTagId { get; set; }
        public string RepairDangerTagId { get; set; }
        public string ReturnDate { get; set; }
        public string RepairType { get; set; }
        public string RatingScore { get; set; }
        public string UserComment { get; set; }
        public string CommentBy { get; set; }
        public string FailureCode { get; set; }
        public string FailureDescriptionEng { get; set; }
        public string FailureDescriptionTha { get; set; }
        public string RepairCode { get; set; }
        public string RepairDescriptionEng { get; set; }
        public string RepairDescriptionTha { get; set; }
        public string RootCause { get; set; }
        public string Solution { get; set; }
        public string Engineer { get; set; }
        public string RemarkText { get; set; }

    }

    public class Distance
    {
        public string DistanceMax(string Province, string Amphur)
        {
            string Distance = "";
            string xsql = "Select MAX(F_Dis_Distance) AS Distance from Tbl_Distance where F_Dis_ProvinceEnd = '" + Province.Trim() + "' And F_Dis_AmphoeEnd = '" + Amphur.Trim() + "'";
            DataSet dss = new Class1().SqlGet(xsql, "Tbl_Distance");
            long rows = dss.Tables[0].Rows.Count;
            if (rows != 0)
            {
                string Distanc = dss.Tables["Tbl_Distance"].Rows[0]["Distance"].ToString();
                double dist; double.TryParse(Distanc, out dist);
                Distance = dist.ToString("##");
            }
            else
            {
                Distance = "0";
            }

            return Distance;
        }

        public string DistanceValue(string Province, string Amphur,string District)
        {
            string Distance = "";
            string xsql = "Select F_Dis_Distance AS Distance from Tbl_Distance where F_Dis_ProvinceEnd = '" + Province.Trim() + "' And F_Dis_AmphoeEnd = '" + Amphur.Trim() + "' and F_Dis_DistrictEnd = '" + District.Trim() + "'";
            DataSet dss = new Class1().SqlGet(xsql, "Tbl_Distance");
            long rows = dss.Tables[0].Rows.Count;
            if (rows != 0)
            {
                string Distanc = dss.Tables["Tbl_Distance"].Rows[0]["Distance"].ToString();
                double dist; double.TryParse(Distanc, out dist);
                Distance = dist.ToString("##");
            }
            else
            {
                Distance = "0";
            }

            return Distance;
        }



    }

}
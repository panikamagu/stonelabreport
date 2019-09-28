using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CCP_MOULDS
{
    public class CDep
    {
        public string Ptext { get; set; }
        public static List<CDep> GetDep()
        {
            List<CDep> Dep = new List<CDep>();

            #region
            string sql = "Select Department from Employees where Department <> '' group by Department";
            DataSet ds_s = new Class1().SqlGet(sql, "Employees");
            long row = ds_s.Tables[0].Rows.Count;
            if (row != 0)
            {
                for (int i = 0; i < row; i++)
                {
                    string Department = ds_s.Tables["Employees"].Rows[i]["Department"].ToString();
                    //string provincename = ds_s.Tables["tbl_Provice"].Rows[i]["ProvinceName"].ToString();
                    Dep.Add(new CDep { Ptext = Department });

                }
            }
            #endregion

            return Dep;
        }
    }
}
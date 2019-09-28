using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CCP_MOULDS
{
    public class dboClass
    {

        private static string str_ip = "192.168.0.9";// ConfigurationSettings.AppSettings["IPSQL"];// "192.168.0.9";
        private static string str_db = "SLCCP"; //ConfigurationSettings.AppSettings["DB"];//"QTPCPS2";

        private static string str_User = "sa";// ConfigurationSettings.AppSettings["USER"];
        private static string str_Pass = "dogthaiP@ssw0rd";// ConfigurationSettings.AppSettings["PASSWORD"];

        public SqlConnection SqlStrCon()
        {
            return new SqlConnection("Data Source=" + str_ip + ";Initial Catalog=" + str_db + ";Persist Security Info=True;User ID=" + str_User + ";Password=" + str_Pass + "");
        }

    }

    public class Class1
    {
        //SQL Server Class
        #region
        public DataSet SqlGet(string sql, string tblName)
        {
            SqlConnection conn = new dboClass().SqlStrCon();
            SqlDataAdapter daa = new SqlDataAdapter(sql, conn);
            DataSet dsa = new DataSet();
            daa.Fill(dsa, tblName);
            return dsa;
        }
        public DataSet SqlGet(string sql, string tblName, SqlParameterCollection parameters)
        {
            SqlConnection conn = new dboClass().SqlStrCon();
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            foreach (SqlParameter param in parameters)
            {
                da.SelectCommand.Parameters.AddWithValue(param.ParameterName, param.SqlDbType).Value = param.Value;//นำข้อมุลเข้าbase
            }
            da.Fill(ds, tblName);
            return ds;
        }
        public int SqlExecute(string sql)
        {
            int i;
            SqlConnection conn = new dboClass().SqlStrCon();
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            i = cmd.ExecuteNonQuery();
            conn.Close();
            return i;
        }
        public int SqlExecute(string sql, SqlParameterCollection parameters)
        {
            int i;
            SqlConnection conn = new dboClass().SqlStrCon();
            SqlCommand cmd = new SqlCommand(sql, conn);
            foreach (SqlParameter param in parameters)
            {
                cmd.Parameters.AddWithValue(param.ParameterName, param.SqlDbType).Value = param.Value;
            }
            conn.Open();
            i = cmd.ExecuteNonQuery();
            conn.Close();
            return i;
        }
        public DataSet SqlExcSto(string stpName, string tblName, SqlParameterCollection parameters)
        {
            SqlConnection conn = new dboClass().SqlStrCon();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = stpName;
            foreach (SqlParameter param in parameters)
            {
                cmd.Parameters.AddWithValue(param.ParameterName, param.SqlDbType).Value = param.Value;
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, tblName);
            return ds;
        }
        #endregion
    }





}
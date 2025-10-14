using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArthaShikshaData
{
    public static class DbConnection
    {
        private static IConfiguration _configuration;

        public static void Initialize(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public static SqlConnection GetConnection()
        {
            string connectionString = "Data Source=DESKTOP-06FQROC\\SQLEXPRESS;Initial Catalog=ArthaShiksha;Integrated Security=True;TrustServerCertificate=True;";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            return sqlConnection;
        }

    }

    public static class BindData
    {

        public static DataTable BindGridviewQry(string pass)
        {
            try
            {
                SqlConnection strcon = DbConnection.GetConnection();
                SqlDataAdapter ada = new SqlDataAdapter(pass, strcon);
                DataTable dt = new DataTable();
                ada.Fill(dt);
                return dt;
            }

            catch (Exception ex)
            {

                throw new Exception("Error in Binding data" + ex.Message);

            }

        }

        public static DataSet BindGridview(string storeproc)
        {
            try
            {
                SqlConnection strcon = DbConnection.GetConnection();
                SqlCommand cmd = new SqlCommand(storeproc, strcon);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter ada = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                //  DataTable dt = new DataTable();
                // ada.SelectCommand;
                ada.Fill(ds);
                return ds;
            }

            catch (Exception ex)
            {

                throw new Exception("Error in Binding data" + ex.Message);

            }

        }
        public static DataTable BindGridviewTable(string storeproc)
        {
            try
            {
                SqlConnection strcon = DbConnection.GetConnection();
                SqlCommand cmd = new SqlCommand(storeproc, strcon);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter ada = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                ada.Fill(dt);
                return dt;
            }

            catch (Exception ex)
            {

                throw new Exception("Error in Binding data" + ex.Message);

            }

        }
        public static DataSet BindGridviewTableinSetr(string storeproc, Hashtable hs)
        {
            SqlConnection strcon = DbConnection.GetConnection();
            try
            {
                strcon.Open();

                SqlCommand cmd = new SqlCommand(storeproc, strcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 1000;
                SqlDataAdapter ada = new SqlDataAdapter(cmd);
                foreach (string parameter in hs.Keys)
                {
                    cmd.Parameters.AddWithValue(parameter, hs[parameter]);
                }
                DataSet dt = new DataSet();
                ada.Fill(dt);
                strcon.Close();
                return dt;
            }

            catch (Exception ex)
            {

                throw new Exception("Error in Binding data" + ex.Message);

            }
            finally
            {
                strcon.Close();

            }

        }


        //METHOD TO EXECUTE PARAMETERIZED INSERT AND UPDATE QUERY
        public static void ExecuteParameterizedNonQuery(string SQLQuery, Hashtable hs)
        {
            SqlConnection strcon = DbConnection.GetConnection();
            SqlCommand cmd = strcon.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = SQLQuery;
            foreach (string parameter in hs.Keys)
            {
                //cmd.Parameters.AddWithValue(parameter, hs[parameter]);
                cmd.Parameters.AddWithValue(parameter, hs[parameter]);
            }
            strcon.Open();

            cmd.ExecuteNonQuery();

            strcon.Close();
        }
        public static SqlDataReader Bind_label_Text(string query)
        {
            SqlDataReader rdr = null;
            SqlConnection strcon = DbConnection.GetConnection();
            SqlCommand cmd = new SqlCommand(query, strcon);

            try
            {

                cmd.Connection.Open();
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                rdr.Read();
                return rdr;
            }
            catch (Exception ex)
            {
                cmd.Connection.Close();
                throw;
            }
            finally
            {
            }
        }
        public static DataTable ExecuteQuery(string select)
        {

            DataTable dt = new DataTable();

            SqlDataAdapter adapter = null;
            SqlConnection conn = null;

            try
            {
                conn = DbConnection.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                //if ((conn != null) && (!conn.Database.Equals(Database)))
                //{
                //    conn.ChangeDatabase(Database);
                //}



                adapter = new SqlDataAdapter(select, conn);
                //adapter.SelectCommand.Transaction = tx;
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {

                throw ex;

            }
            finally
            {

                if (conn.State == ConnectionState.Open) { conn.Close(); }
            }
            return dt;
        }
        public static int ExecuteQueryProc(string storeproc, Hashtable hs)
        {

            try
            {
                SqlConnection strcon = DbConnection.GetConnection();
                if (strcon.State == ConnectionState.Closed)
                {
                    strcon.Open();
                }
                SqlCommand cmd = new SqlCommand(storeproc, strcon);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter ada = new SqlDataAdapter(cmd);
                foreach (string parameter in hs.Keys)
                {
                    cmd.Parameters.AddWithValue(parameter, hs[parameter]);
                }

                int Value = cmd.ExecuteNonQuery();

                if (strcon.State == ConnectionState.Open)
                {
                    strcon.Close();
                }
                return Value;
            }

            catch (Exception ex)
            {

                throw ex;

            }
        }
        public static bool ExecuteNonQuery(string query)
        {
            bool result = false;
            int recordsAffected = 0;
            SqlConnection conn = DbConnection.GetConnection();
            SqlCommand cmd = new SqlCommand(query, conn);
            try
            {

                cmd.Connection.Open();
                recordsAffected = cmd.ExecuteNonQuery();
                result = (recordsAffected > 0) ? true : false;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();

            }
            return result;

        }
        public static DataTable BindGridviewTable(string storeproc, Hashtable hs)
        {
            SqlConnection strcon = DbConnection.GetConnection();
            try
            {
                strcon.Open();

                SqlCommand cmd = new SqlCommand(storeproc, strcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 600;

                SqlDataAdapter ada = new SqlDataAdapter(cmd);
                foreach (string parameter in hs.Keys)
                {
                    cmd.Parameters.AddWithValue(parameter, hs[parameter]);
                }
                DataTable dt = new DataTable();
                ada.Fill(dt);
                strcon.Close();
                return dt;
            }

            catch (Exception ex)
            {

                throw new Exception("Error in Binding data" + ex.Message);

            }
            finally
            {
                strcon.Close();

            }
        }

        public static DataTable BindGridviewTableR()
        {
            SqlConnection strcon = DbConnection.GetConnection();
            try
            {
                strcon.Open();

                SqlCommand cmd = new SqlCommand("select Id,Name from Region order by Name", strcon);
                //cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter ada = new SqlDataAdapter(cmd);
                //foreach (string parameter in hs.Keys)
                //{
                //    cmd.Parameters.AddWithValue(parameter, hs[parameter]);
                //}
                DataTable dt = new DataTable();
                ada.Fill(dt);
                strcon.Close();
                return dt;
            }

            catch (Exception ex)
            {

                throw new Exception("Error in Binding data" + ex.Message);

            }
            finally
            {
                strcon.Close();

            }

        }


        public static DataTable BindGridviewTableB(string RegionId)
        {
            SqlConnection strcon = DbConnection.GetConnection();
            try
            {
                strcon.Open();
                SqlCommand cmd = new SqlCommand();
                if (RegionId == "0")
                {
                    cmd = new SqlCommand("select Id,Name from Branch  order by Name", strcon);
                }
                else
                {
                    cmd = new SqlCommand("select Id,Name from Branch where RegionId='" + RegionId + "' order by Name", strcon);
                }
                //cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter ada = new SqlDataAdapter(cmd);
                //foreach (string parameter in hs.Keys)
                //{
                //    cmd.Parameters.AddWithValue(parameter, hs[parameter]);
                //}
                DataTable dt = new DataTable();
                ada.Fill(dt);
                strcon.Close();
                return dt;
            }

            catch (Exception ex)
            {

                throw new Exception("Error in Binding data" + ex.Message);

            }
            finally
            {
                strcon.Close();

            }

        }

        public static DataTable BindGridviewTableU(string id)
        {
            SqlConnection strcon = DbConnection.GetConnection();
            try
            {
                strcon.Open();
                SqlCommand cmd = new SqlCommand();
                string query = "select u.id UnitId,U.Name,u.UnitCode,a.GeoLocation.Lat Lat,a.GeoLocation.Long Long," +
                                "CASE WHEN ut.Name='Tiny' then 15 WHEN ut.Name='Small' then 15 WHEN ut.Name='Medium' then 30 " +
                                " WHEN ut.Name='Large' then 45 WHEN ut.Name='Jumbo' then 90 else  120 end TaskTime" +

                                   " from dbo.unit u  inner join Address a on u.AddressId = a.id and u.IsActive=1 " +
                                    "inner join UnitType ut on ut.id = u.UnitTypeId " +
                                        "where u.AreaInspectorId = '" + id + "' ";

                cmd = new SqlCommand(query, strcon);

                //cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter ada = new SqlDataAdapter(cmd);
                //foreach (string parameter in hs.Keys)
                //{
                //    cmd.Parameters.AddWithValue(parameter, hs[parameter]);
                //}
                DataTable dt = new DataTable();
                ada.Fill(dt);
                strcon.Close();
                return dt;
            }

            catch (Exception ex)
            {

                throw new Exception("Error in Binding data" + ex.Message);

            }
            finally
            {
                strcon.Close();

            }

        }

        public static DataTable BindGridviewTableULine(string id)
        {
            SqlConnection strcon = DbConnection.GetConnection();
            try
            {
                strcon.Open();
                SqlCommand cmd = new SqlCommand();
                string query = "select min(a.GeoLocation.Lat)Lat,min(a.GeoLocation.Long)Long,max(a.GeoLocation.Lat)MaxLat,max(a.GeoLocation.Long)MaxLong" +

                                   " from dbo.unit u  inner join Address a on u.AddressId = a.id and u.IsActive=1 " +
                                    "inner join UnitType ut on ut.id = u.UnitTypeId " +
                                        "where u.AreaInspectorId = '" + id + "' and a.GeoLocation.Lat!='0.0' and a.GeoLocation.Long!='0.0'  ";

                cmd = new SqlCommand(query, strcon);

                //cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter ada = new SqlDataAdapter(cmd);
                //foreach (string parameter in hs.Keys)
                //{
                //    cmd.Parameters.AddWithValue(parameter, hs[parameter]);
                //}
                DataTable dt = new DataTable();
                ada.Fill(dt);
                strcon.Close();
                return dt;
            }

            catch (Exception ex)
            {

                throw new Exception("Error in Binding data" + ex.Message);

            }
            finally
            {
                strcon.Close();

            }

        }

        public static DataTable BindGridviewTableUBlock(string id)
        {
            SqlConnection strcon = DbConnection.GetConnection();
            try
            {
                strcon.Open();
                SqlCommand cmd = new SqlCommand();
                string query = "select * from [dbo].[BlockSize] where AOID='" + id + "'";

                cmd = new SqlCommand(query, strcon);

                //cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter ada = new SqlDataAdapter(cmd);
                //foreach (string parameter in hs.Keys)
                //{
                //    cmd.Parameters.AddWithValue(parameter, hs[parameter]);
                //}
                DataTable dt = new DataTable();
                ada.Fill(dt);
                strcon.Close();
                return dt;
            }

            catch (Exception ex)
            {

                throw new Exception("Error in Binding data" + ex.Message);

            }
            finally
            {
                strcon.Close();

            }

        }
        public static DataTable BindGridviewTableOff(string BranchId, string RegionId)
        {
            SqlConnection strcon = DbConnection.GetConnection();
            try
            {
                strcon.Open();
                SqlCommand cmd = new SqlCommand();
                if (RegionId == "0" && BranchId == "0")
                {
                    cmd = new SqlCommand("select v.id Id,FirstName Name,EmployeeNo from vw_all_areaofficer v inner join " +
                                           "EmployeeDevice ed on v.id = ed.AppUserId and ed.IsAOAppInstalled=1 " +
                                           "inner Join Branch b on v.BranchId=b.Id inner Join Region r on b.RegionId=r.Id " +
                                           "order by Name", strcon);
                }
                else
                    if (RegionId != "0" && BranchId == "0")
                {

                    cmd = new SqlCommand("select v.id Id,FirstName Name,EmployeeNo from vw_all_areaofficer v inner join " +
                                           "EmployeeDevice ed on v.id = ed.AppUserId and ed.IsAOAppInstalled=1 " +
                                           "inner Join Branch b on v.BranchId=b.Id inner Join Region r on b.RegionId=r.Id " +
                                           " where r.Id='" + RegionId + "'" +
                                           "order by Name", strcon);

                }
                else
                        if (RegionId == "0" && BranchId != "0")
                {

                    cmd = new SqlCommand("select v.id Id,FirstName Name,EmployeeNo from vw_all_areaofficer v inner join " +
                                           "EmployeeDevice ed on v.id = ed.AppUserId and ed.IsAOAppInstalled=1 " +
                                           "inner Join Branch b on v.BranchId=b.Id inner Join Region r on b.RegionId=r.Id " +
                                           " where v.BranchId='" + BranchId + "'" +
                                           "order by Name", strcon);

                }
                else
                            if (RegionId != "0" && BranchId != "0")
                {

                    cmd = new SqlCommand("select v.id Id,FirstName Name,EmployeeNo from vw_all_areaofficer v inner join " +
                                           "EmployeeDevice ed on v.id = ed.AppUserId and ed.IsAOAppInstalled=1 " +
                                           "inner Join Branch b on v.BranchId=b.Id inner Join Region r on b.RegionId=r.Id " +
                                           " where v.BranchId='" + BranchId + "' and r.Id='" + RegionId + "'" +
                                           "order by Name", strcon);

                }

                //cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter ada = new SqlDataAdapter(cmd);
                //foreach (string parameter in hs.Keys)
                //{
                //    cmd.Parameters.AddWithValue(parameter, hs[parameter]);
                //}
                DataTable dt = new DataTable();
                ada.Fill(dt);
                strcon.Close();
                return dt;
            }

            catch (Exception ex)
            {

                throw new Exception("Error in Binding data" + ex.Message);

            }
            finally
            {
                strcon.Close();

            }

        }

        public static DataTable BindGridviewTableHome(string id)
        {
            SqlConnection strcon = DbConnection.GetConnection();
            try
            {
                strcon.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("select v.id AOId,FirstName AOName,EmployeeNo,a.GeoLocation.Lat Lat,a.GeoLocation.Long Long " +
                                       "from vw_all_areaofficer v inner join EmployeeDevice ed on " +
                                         "v.id = ed.AppUserId and ed.IsAOAppInstalled=1 " +
                                            "inner join EmployeeAddress a on a.id = v.ResidentialAddressId where a.GeoLocation is not null " +
                                            " and a.GeoLocation.Lat <> 0 and v.Id='" + id + "' order by v.BranchId", strcon);

                //cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter ada = new SqlDataAdapter(cmd);
                //foreach (string parameter in hs.Keys)
                //{
                //    cmd.Parameters.AddWithValue(parameter, hs[parameter]);
                //}
                DataTable dt = new DataTable();
                ada.Fill(dt);
                strcon.Close();
                return dt;
            }

            catch (Exception ex)
            {

                throw new Exception("Error in Binding data" + ex.Message);

            }
            finally
            {
                strcon.Close();

            }

        }
        public static DataSet BindDataSet(string storeproc, Hashtable hs)
        {
            SqlConnection strcon = DbConnection.GetConnection();
            try
            {
                strcon.Open();

                SqlCommand cmd = new SqlCommand(storeproc, strcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 600;
                SqlDataAdapter ada = new SqlDataAdapter(cmd);
                foreach (string parameter in hs.Keys)
                {
                    cmd.Parameters.Add(parameter, (SqlDbType)hs[parameter]);
                }
                DataSet dt = new DataSet();
                ada.Fill(dt);
                strcon.Close();
                return dt;
            }

            catch (Exception ex)
            {

                throw new Exception("Error in Binding data" + ex.Message);

            }
            finally
            {
                strcon.Close();

            }

        }
        public static int ExecuteParaNonQuery(string Sp_name, Hashtable hs)
        {
            int r = 0;
            SqlConnection strcon = DbConnection.GetConnection();
            SqlCommand cmd = new SqlCommand(Sp_name, strcon);
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;

                foreach (string parameter in hs.Keys)
                {
                    cmd.Parameters.AddWithValue(parameter, hs[parameter]);
                }
                strcon.Open();

                r = cmd.ExecuteNonQuery();
                strcon.Close(); cmd.Connection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                strcon.Close();
                cmd.Connection.Close();
            }
            return r;
        }
        public static DataTable BindGridviewTableG50(string storeproc, Hashtable hs)
        {
            SqlConnection strcon = DbConnection.GetConnection();
            try
            {
                strcon.Open();

                SqlCommand cmd = new SqlCommand(storeproc, strcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 600;

                SqlDataAdapter ada = new SqlDataAdapter(cmd);
                foreach (string parameter in hs.Keys)
                {
                    cmd.Parameters.AddWithValue(parameter, hs[parameter]);
                }
                DataTable dt = new DataTable();
                ada.Fill(dt);
                strcon.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Binding data" + ex.Message);
            }
            finally
            {
                strcon.Close();
            }
        }
    }
}

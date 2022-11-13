using System;
using System.Data;
using System.Data.SqlClient;

namespace MyCrudPackage
{
    public static class Crud
    {
        /// <summary>
        /// myobj - being the model of your object
        /// spname - provide your stored procedure name
        /// sqlconnection - provide your complete connection string 
        /// This can be used to do the transactions such as Insertion,Deletion,Updation
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="myobj"></param>
        /// <param name="spname"></param>
        /// <param name="sqlconnection"></param>
        /// <returns>the value you send it from stored procedure</returns>
        public static object DBTransaction<T>(T myobj, string spname, string sqlconnection)
        {
            object myreturnobject = null;

            using (SqlConnection con = new SqlConnection(sqlconnection))
            {
                using (SqlCommand sqlcmd = new SqlCommand(spname, con))
                {
                    var properties = typeof(T).GetProperties();
                    foreach (var property in properties)
                    {
                        SqlParameter sqlparam = new SqlParameter("@" + property.Name, property.GetValue(myobj, null));
                        sqlcmd.Parameters.Add(sqlparam);
                    }

                    con.Open();
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    myreturnobject = sqlcmd.ExecuteScalar();
                    con.Close();
                }
            }

            return myreturnobject;
        }

        /// <summary>
        /// myobj - being the model of your object
        /// spname - provide your stored procedure name
        /// sqlconnection - provide your complete connection string 
        /// This will return multiple or single dataset(s)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="myobj"></param>
        /// <param name="spname"></param>
        /// <param name="sqlconnection"></param>
        /// <returns>the value you send it from stored procedure</returns>
        public static DataSet GetDataSet<T>(T myobj, string spname, string sqlconnection)
        {
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(sqlconnection))
            {

                using (SqlCommand sqlcmd = new SqlCommand(spname, con))
                {
                    var properties = typeof(T).GetProperties();
                    foreach (var property in properties)
                    {
                        SqlParameter sqlparam = new SqlParameter("@" + property.Name, property.GetValue(myobj, null));
                        sqlcmd.Parameters.Add(sqlparam);
                    }

                    sqlcmd.Connection = con;
                    con.Open();
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter sda = new SqlDataAdapter(sqlcmd))
                    {

                        sda.Fill(ds);
                    }
                    con.Close();
                }
            }
            return ds;
        }

        /// <summary>
       
        /// spname - provide your stored procedure name
        /// sqlconnection - provide your complete connection string 
        /// This will return multiple or single dataset(s)
        /// </summary>
      
        /// <param name="spname"></param>
        /// <param name="sqlconnection"></param>
        /// <returns>the value you send it from stored procedure</returns>
        public static DataSet GetDataSet(string spname, string sqlconnection)
        {
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(sqlconnection))
            {

                using (SqlCommand sqlcmd = new SqlCommand(spname, con))
                {
                    sqlcmd.Connection = con;
                    con.Open();
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter sda = new SqlDataAdapter(sqlcmd))
                    {
                        sda.Fill(ds);
                    }
                    con.Close();
                }
            }
            return ds;
        }

        /// <summary>
        /// myobj - being the model of your object
        /// spname - provide your stored procedure name
        /// sqlconnection - provide your complete connection string 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="myobj"></param>
        /// <param name="spname"></param>
        /// <param name="sqlconnection"></param>
        /// <returns>2 Table value will be returned, one being the recordcount and the other being the data</returns>
        public static DataTable GetDataTable<T>(T myobj, string spname, string sqlconnection)
        {
            

            DataTable ToBind = new DataTable();

            using (SqlConnection con = new SqlConnection(sqlconnection))
            {

                using (SqlCommand sqlcmd = new SqlCommand(spname, con))
                {
                    var properties = typeof(T).GetProperties();
                    foreach (var property in properties)
                    {
                        SqlParameter sqlparam = new SqlParameter("@" + property.Name, property.GetValue(myobj, null));
                        sqlcmd.Parameters.Add(sqlparam);
                    }
                   
                    con.Open();
                    sqlcmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader myReturnObj = sqlcmd.ExecuteReader();
                   
                    int k = -1;

                    for (int columns = 0; columns < myReturnObj.FieldCount; columns++)
                    { ToBind.Columns.Add(myReturnObj.GetName(columns)); }

                    int NoofColumns = ToBind.Columns.Count;

                    while (myReturnObj.Read())
                    {
                        DataRow dr = ToBind.NewRow();
                        for (int i = 0; i < NoofColumns; i++)
                        {
                            k = myReturnObj.GetOrdinal(ToBind.Columns[i].ColumnName);
                            if (k > -1)
                            {

                                dr[k] = myReturnObj[ToBind.Columns[i].ColumnName];

                            }
                        }
                        ToBind.Rows.Add(dr);
                    }

                    con.Close();

                }
            }

            return ToBind;

        }

        /// <summary>
        /// spname - provide your stored procedure name
        /// sqlconnection - provide your complete connection string 
        /// </summary>
        /// <param name="spname"></param>
        /// <param name="sqlconnection"></param>
        /// <returns>2 Table value will be returned, one being the recordcount and the other being the data</returns>
        public static DataTable GetDataTable(string spname, string sqlconnection)
        {

            DataTable ToBind = new DataTable();

            using (SqlConnection con = new SqlConnection(sqlconnection))
            {

                using (SqlCommand sqlcmd = new SqlCommand(spname, con))
                {
        
                   
                    con.Open();
                    sqlcmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader myReturnObj = sqlcmd.ExecuteReader();
                    
                    int k = -1;

                    for (int columns = 0; columns < myReturnObj.FieldCount; columns++)
                    { ToBind.Columns.Add(myReturnObj.GetName(columns)); }

                    int NoofColumns = ToBind.Columns.Count;

                    while (myReturnObj.Read())
                    {
                        DataRow dr = ToBind.NewRow();
                        for (int i = 0; i < NoofColumns; i++)
                        {
                            k = myReturnObj.GetOrdinal(ToBind.Columns[i].ColumnName);
                            if (k > -1)
                            {

                                dr[k] = myReturnObj[ToBind.Columns[i].ColumnName];

                            }
                        }
                        ToBind.Rows.Add(dr);
                    }

                    con.Close();

                }
            }

            return ToBind;

        }

    }
}

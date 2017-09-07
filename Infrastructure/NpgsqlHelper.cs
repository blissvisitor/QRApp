using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Configuration;
using System.Data;
using Npgsql;
namespace Infrastructure
{
    public class NpgsqlHelper
    {
        private static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PostGreSqlConnString"].ConnectionString;

        //string connectionString = "Server=127.0.0.1;Port=5432;User Id=test;Password=test;Database=testdb;" ; 
        NpgsqlConnection conn = new NpgsqlConnection(connectionString);
        #region postgresql操作数据库方法
        public static int ExecuteScalar(string sql)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    using (NpgsqlCommand cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = sql;
                        connection.Open();
                        return Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connection.Dispose();
                }
            }
        }
        public static bool ExecuteNonQuerysw(IList<string> sql)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                using (NpgsqlTransaction tran = connection.BeginTransaction()) //开始数据库事务。即创建一个事务对象tran  
                {
                    using (NpgsqlCommand cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = connection;
                        cmd.Transaction = tran; //获取或设置将要其执行的事务  
                        try
                        {
                            for (var i = 0; i < sql.Count; i++)
                            {
                                cmd.CommandText = sql[i];
                                int m=cmd.ExecuteNonQuery();
                                if (m < 1) {
                                    tran.Rollback();
                                    return false;
                                }
                            }
                            tran.Commit();
                            return true;
                        }
                        catch (Exception ex)
                        {
                            return false;
                            tran.Rollback();//如果执行不成功，发送异常，则执行rollback方法，回滚到事务操作开始之前。  
                        }
                        finally
                        {
                            connection.Dispose();
                        }
                    }
                }
                //try
                //{
                //    using (NpgsqlCommand cmd = connection.CreateCommand())
                //    {
                //        cmd.CommandText = sql;
                //        connection.Open();
                //        return Convert.ToInt32(cmd.ExecuteScalar());
                //    }
                //}
                //catch (Exception ex)
                //{
                //    throw ex;
                //}
                //finally
                //{
                //    connection.Dispose();
                //}
            }
        }

        public static object ExecuteScalar(string sql, NpgsqlParameter[] parameters)
        {

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    using (NpgsqlCommand cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = sql;
                        connection.Open();

                        foreach (NpgsqlParameter parameter in parameters)
                        {
                            cmd.Parameters.Add(parameter);
                        }

                        return cmd.ExecuteScalar();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connection.Dispose();
                }
            }

        }
        public static int ExecuteNonQuery(string sql)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    using (NpgsqlCommand cmd = connection.CreateCommand())
                    {
                        connection.Open();
                        cmd.CommandText = sql;
                        return cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connection.Dispose();
                }
            }
        }
        //C#事务插入多条数据
        //public static int ExcuteTransction(string sql) 
        //{ 
        //    using (NpgsqlConnection con =new NpgsqlConnection(connectionString))
        //    {
        //        int x = -1;
        //        con.Open();
        //        NpgsqlCommand command = con.CreateCommand();
        //        NpgsqlTransaction transcation = con.BeginTransaction();
        //        command.Connection = con;
        //        command.Transaction = transcation;
        //        try
        //        {
        //            command.CommandText = sql;
        //            x=command.ExecuteNonQuery();
        //            if(x<=0){
        //                transcation.Rollback();
        //            }
        //            transcation.Commit();
        //        }
        //        catch
        //        {
        //            x = -1;
        //            transcation.Rollback();
        //            throw;
        //        }
        //        finally 
        //        {
        //            con.Close();
        //            transcation.Dispose();
        //            con.Dispose();
        //        }
        //        return x;
        //    }
        //}



        public static int ExecuteNonQuery(string sql, NpgsqlParameter[] parameters)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    using (NpgsqlCommand cmd = connection.CreateCommand())
                    {
                        connection.Open();
                        foreach (NpgsqlParameter parameter in parameters)
                        {
                            cmd.Parameters.Add(parameter);
                        }
                        cmd.CommandText = sql;
                        return cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connection.Dispose();
                }
            }
        }

        //public static int ExecuteNonQuery1(string sql, NpgsqlParameter[] parameters)
        //{
        //    //创建一个MySqlConnection对象
        //    NpgsqlConnection connection = new NpgsqlConnection(connectionString);
        //    //创建一个MySqlCommand对象
        //    NpgsqlCommand cmd = new NpgsqlCommand();

        //    using (connection)
        //    {
        //        try
        //        {
        //            using (cmd = connection.CreateCommand())
        //            {
        //                connection.Open();
        //                foreach (NpgsqlParameter parameter in parameters)
        //                {
        //                    cmd.Parameters.Add(parameter);
        //                }
        //                cmd.CommandText = sql;
        //                int counts = cmd.ExecuteNonQuery();
        //                if (counts > 0)
        //                {
        //                    cmd.CommandText = "SELECT  currval('comm_project_Village_id_seq') LIMIT 1";
        //                    int id = int.Parse(cmd.ExecuteScalar().ToString());
        //                    return id;
        //                }
        //                else
        //                {
        //                    return -1;
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }
        //        finally
        //        {
        //            connection.Dispose();
        //        }
        //    }
        //}

        public static NpgsqlDataReader ExecuteReader(string sql)
        {
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);

            using (NpgsqlCommand cmd = connection.CreateCommand())
            {
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = sql;
                connection.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
        }

        public static NpgsqlDataReader ExecuteReader(string sql, NpgsqlParameter[] parameters)
        {
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            NpgsqlCommand cmd = connection.CreateCommand();
            try
            {
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = sql;
                connection.Open();
                foreach (NpgsqlParameter parameter in parameters)
                {
                    cmd.Parameters.Add(parameter);
                }
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                if (connection != null) connection.Close();
                throw ex;
            }

        }

        public static DataTable ExecuteDataTable(string sql)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    using (NpgsqlCommand cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = sql;
                        connection.Open();
                        using (NpgsqlDataReader reader = cmd.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);
                            return dt;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connection.Dispose();
                }
            }
        }

        public static DataTable ExecuteDataTable(string sql, NpgsqlParameter[] parameters)
        {

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    using (NpgsqlCommand cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = sql;
                        connection.Open();

                        foreach (NpgsqlParameter parameter in parameters)
                        {
                            cmd.Parameters.Add(parameter);
                        }

                        using (NpgsqlDataReader reader = cmd.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);
                            return dt;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connection.Dispose();
                }
            }

        }

        public static int ExecuteSql(string sql, params NpgsqlParameter[] Parameters)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, connection, null, sql, Parameters);
                        int rows = cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        return rows;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        cmd.Dispose();
                        connection.Close();
                    }
                }
            }
        }

        public static void ExecuteSqlTran(IList<NpgsqlSqlMap> sqlList)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    NpgsqlTransaction tran = conn.BeginTransaction();
                    try
                    {
                        for (int i = 0; i < sqlList.Count; i++)
                        {
                            PrepareCommand(cmd, conn, null, sqlList[i].Sql, sqlList[i].SqlParameters);
                            cmd.ExecuteNonQuery();
                        }
                        tran.Commit();
                    }
                    catch (NpgsqlException ex)
                    {
                        tran.Rollback();
                        throw new Exception(ex.Message);
                    }
                    finally
                    {
                        cmd.Dispose();
                        conn.Close();
                    }

                }


            }
        }
        private static void PrepareCommand(NpgsqlCommand cmd, NpgsqlConnection conn, NpgsqlTransaction trans, string cmdText, NpgsqlParameter[] Parameters)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null)
                cmd.Transaction = trans;
            cmd.CommandType = CommandType.Text;//cmdType;
            if (Parameters != null)
            {
                foreach (NpgsqlParameter parm in Parameters)
                    cmd.Parameters.Add(parm);
            }
        }
        #endregion
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Configuration;
using System.Data;
//申明mysql.Data bll
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Infrastructure
{
    public class MySqlDHelper
    {
        //数据库连接字符串
        private static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MysqlConnectionString"].ConnectionString;

        //MySqlConnection conn = new MySqlConnection(connectionString);

        #region mysql 操作数据库的方法


        #region ExecuteScalar
        /// <summary>
        /// 用指定的数据库连接字符串执行一个命令并返回一个数据集的第一列
        /// </summary>
        /// <remarks>
        /// 例如:Object obj = ExecuteScalar(connString, new MySqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="sql">一个有效的连接字符串</param>
        /// <returns>用 Convert.ToInt32{Type}把类型转换为想要的 </returns>
        public static int ExecuteScalar(string sql)
        {
            //创建一个MySqlConnection对象
            MySqlConnection connection = new MySqlConnection(connectionString);
            //创建一个MySqlCommand对象
            MySqlCommand cmd = new MySqlCommand();

            using (connection)
            {
                try
                {
                    using (cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = sql;//存储过程名称或者sql数据库查询语句
                        connection.Open();//打开数据连接
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

        /// <summary>
        /// 用指定的数据库连接执行一个命令并返回一个数据集
        /// </summary>
        /// <param name="sql">sql数据库查询语句</param>
        /// <param name="parameters">执行命令所用参数的集合</param>
        /// <returns></returns>
        public static object ExecuteScalar(string sql, MySqlParameter[] parameters)
        {
            //创建一个MySqlConnection对象
            MySqlConnection connection = new MySqlConnection(connectionString);
            //创建一个MySqlCommand对象
            MySqlCommand cmd = new MySqlCommand();

            using (connection)
            {
                try
                {
                    using (cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = sql;//数据库查询语句
                        connection.Open();//打开数据库连接

                        foreach (MySqlParameter parameter in parameters)
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
        #endregion

        #region ExecuteNonQuery
        /// <summary>
        /// 给定连接的数据库用假设参数执行一个sql命令（不返回数据集）
        /// </summary>
        /// <param name="sql">mysql数据库查询语句</param>
        /// <param name="parameters">执行命令所用参数的集合</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string sql, MySqlParameter[] parameters)
        {
            //创建一个MySqlConnection对象
            MySqlConnection connection = new MySqlConnection(connectionString);
            //创建一个MySqlCommand对象
            MySqlCommand cmd = new MySqlCommand();

            using (connection)
            {
                try
                {
                    using (cmd = connection.CreateCommand())
                    {
                        connection.Open();
                        foreach (MySqlParameter parameter in parameters)
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

        /// <summary>
        /// 给定连接的数据库用假设参数执行一个sql命令（不返回数据集）
        /// </summary>
        /// <param name="sql">mysql数据库查询语句</param>
        /// <param name="parameters">执行命令所用参数的集合</param>
        /// <returns></returns>
        public static int ExecuteNonQuerys(string sql)
        {
            ////创建一个MySqlConnection对象
            //MySqlConnection connection = new MySqlConnection(connectionString);
            ////创建一个MySqlCommand对象
            //MySqlCommand cmd = new MySqlCommand();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    using (MySqlCommand cmd = connection.CreateCommand())
                    {
                        connection.Open();
                        //foreach (MySqlParameter parameter in parameters)
                        //{
                        //    cmd.Parameters.Add(parameter);
                        //}
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
                    connection.Close();
                    connection.Dispose();
                }
            }
        }
        #endregion

        #region ExecuteReader
        /// <summary>
        /// 用执行的数据库连接执行一个返回数据集的sql命令
        /// </summary>
        /// <param name="sql">mysql数据库查询语句</param>
        /// <returns>包含结果的读取器</returns>
        public static MySqlDataReader ExecuteReader(string sql)
        {
            //创建一个MySqlConnection对象
            MySqlConnection connection = new MySqlConnection(connectionString);
            //创建一个MySqlCommand对象
            MySqlCommand cmd = new MySqlCommand();
            using (cmd = connection.CreateCommand())
            {
                cmd.CommandType = System.Data.CommandType.Text;//命令类型(存储过程, 文本, 等等)
                cmd.CommandText = sql;//存储过程名称或者sql命令语句
                connection.Open();
                //调用 MySqlCommand  的 ExecuteReader 方法
                MySqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                return reader;
            }
        }

        /// <summary>
        /// 用执行的数据库连接执行一个返回数据集的sql命令
        /// </summary>
        /// <param name="sql">mysql数据库查询语句</param>
        /// <param name="parameters">执行命令所用参数的集合</param>
        /// <returns></returns>
        public static MySqlDataReader ExecuteReader(string sql, MySqlParameter[] parameters)
        {
            //创建一个MySqlConnection对象
            MySqlConnection connection = new MySqlConnection(connectionString);
            //创建一个MySqlCommand对象
            MySqlCommand cmd = new MySqlCommand();

            cmd = connection.CreateCommand();
            try
            {
                cmd.CommandType = System.Data.CommandType.Text;//命令类型(存储过程, 文本, 等等)
                cmd.CommandText = sql;//存储过程名称或者sql命令语句
                connection.Open();
                foreach (MySqlParameter parameter in parameters)
                {
                    cmd.Parameters.Add(parameter);

                }
                //调用 MySqlCommand  的 ExecuteReader 方法
                MySqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                //清楚参数
                return reader;

            }
            catch (Exception ex)
            {
                if (connection != null)
                {
                    connection.Close();
                }
                throw ex;
            }
        }
        #endregion

        #region ExecuteDataTable
        /// <summary>
        /// 返回DataTable
        /// </summary>
        /// <param name="sql">mysql查询语句</param>
        /// <returns></returns>
        public static DataTable ExecuteDataTable(string sql)
        {
            //创建一个MySqlCommand对象
            MySqlCommand cmd = new MySqlCommand();
            //创建一个MySqlConnection对象
            MySqlConnection connection = new MySqlConnection(connectionString);

            //在这里我们用一个try/catch结构执行sql文本命令/存储过程，因为如果这个方法产生一个异常我们要关闭连接

            using (connection = new MySqlConnection(connectionString))
            {
                try
                {
                    using (cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = sql;//存储过程名称或者sql命令语句
                        connection.Open();
                        MySqlDataReader reader = cmd.ExecuteReader();
                        using (reader)
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

        /// <summary>
        /// 返回DataTable
        /// </summary>
        /// <param name="sql">数据库查询语句</param>
        /// <param name="parameters">执行命令所用参数的集合</param>
        /// <returns></returns>
        public static DataTable ExecuteDataTable(string sql, MySqlParameter[] parameters)
        {
            //创建一个MySqlCommand对象
            MySqlCommand cmd = new MySqlCommand();
            //创建一个MySqlConnection对象
            MySqlConnection connection = new MySqlConnection(connectionString);

            using (connection)
            {
                try
                {
                    using (cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = sql;//存储过程名称或者sql命令语句
                        connection.Open();

                        foreach (MySqlParameter parameter in parameters)
                        {
                            cmd.Parameters.Add(parameter);
                        }

                        using (MySqlDataReader reader = cmd.ExecuteReader())
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
        #endregion

        #region ExecuteSqlTran
        public static int ExecuteSql(string sql, params MySqlParameter[] Parameters)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand())
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
        /// <summary>
        /// OleDb事务
        /// </summary>
        /// <param name="sqlList"></param>
        public static void ExecuteSqlTran(IList<mySqlSqlMap> sqlList)
        {
            //创建一个MySqlCommand对象
            MySqlCommand cmd = new MySqlCommand();
            //创建一个MySqlConnection对象
            MySqlConnection connection = new MySqlConnection(connectionString);

            using (connection)
            {
                connection.Open();
                using (cmd = new MySqlCommand())
                {
                    MySqlTransaction tran = connection.BeginTransaction();
                    try
                    {
                        for (int i = 0; i < sqlList.Count; i++)
                        {
                            PrepareCommand(cmd, connection, null, sqlList[i].Sql, sqlList[i].SqlParameters);
                            cmd.ExecuteNonQuery();
                        }
                        tran.Commit();
                    }
                    catch (MySqlException ex)
                    {
                        tran.Rollback();
                        throw new Exception(ex.Message);
                    }
                    finally
                    {
                        cmd.Dispose();
                        connection.Close();
                    }

                }
            }
        }
        #endregion

        #region PrepareCommand
        /// <summary>
        /// 准备执行一个命令
        /// </summary>
        /// <param name="cmd">sql命令</param>
        /// <param name="conn">OleDb连接</param>
        /// <param name="trans">OleDb事务</param>
        /// <param name="cmdText">命令类型例如 存储过程或者文本</param>
        /// <param name="Parameters">执行命令的参数</param>
        private static void PrepareCommand(MySqlCommand cmd, MySqlConnection conn, MySqlTransaction trans, string cmdText, MySqlParameter[] Parameters)
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
                foreach (MySqlParameter parm in Parameters)
                    cmd.Parameters.Add(parm);
            }
        }
        #endregion

        #endregion
        //private static string Conn = "Database='ceshi';Data Source='localhost';User Id='root';Password='newmap';charset='utf8';pooling='true'";

        //private static HashtableparmCache = Hashtable.Synchronized(new Hashtable());

        //public static int ExecuteNonQuery(string connectionString, CommandType cmdType, string cmdText, params MySqlParameter[] commandParameters)
        //{

        //    MySqlCommand cmd = new MySqlCommand();

        //    using (MySqlConnection conn = new MySqlConnection(connectionString))
        //    {
        //        PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
        //        int val = cmd.ExecuteNonQuery();
        //        cmd.Parameters.Clear();
        //        return val;
        //    }
        //}

        ////数据库连接字符串
        //public static string Conn = "Database='wp';Data Source='localhost';User Id='root';Password='root';charset='utf8';pooling=true";
    }
}

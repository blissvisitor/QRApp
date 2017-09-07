using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
//using Epomap.Common.Json;
//using Oracle.DataAccess.Client;
using System.Collections;
using System.Data.OracleClient;


namespace Infrastructure
{
    public abstract class OracleHelper
    {
        public static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString;

        public OracleHelper() { }

        public static int ExecuteNonQuery(string sql)
        {

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    using (OracleCommand cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = sql;
                        connection.Open();
                        return cmd.ExecuteNonQuery();
                    }
                }
                catch
                {
                    throw;
                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }
            }

        }

        public static int ExecuteNonQuery(string connectionString, string sql)
        {

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    using (OracleCommand cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = sql;
                        connection.Open();
                        return cmd.ExecuteNonQuery();
                    }
                }
                catch
                {
                    throw;
                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }
            }

        }

        public static int ExecuteNonQuery(string sql, params OracleParameter[] parameters)
        {

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    using (OracleCommand cmd = connection.CreateCommand())
                    {
                        connection.Open();
                        foreach (OracleParameter parameter in parameters)
                        {
                            cmd.Parameters.Add(parameter);
                        }
                        cmd.CommandText = sql;
                        return cmd.ExecuteNonQuery();
                    }
                }
                catch { throw; }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }
            }

        }

        public static int ExecuteNonQuery(string connectionString, string sql, params OracleParameter[] parameters)
        {

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    using (OracleCommand cmd = connection.CreateCommand())
                    {
                        connection.Open();
                        foreach (OracleParameter parameter in parameters)
                        {
                            cmd.Parameters.Add(parameter);
                        }
                        cmd.CommandText = sql;
                        return cmd.ExecuteNonQuery();
                    }
                }
                catch { throw; }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }
            }

        }

        public static OracleDataReader ExecuteReader(string sql)
        {
            OracleConnection connection = new OracleConnection(connectionString);

            using (OracleCommand cmd = connection.CreateCommand())
            {
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = sql;
                connection.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
        }

        public static OracleDataReader ExecuteReader(string connectionString, string sql)
        {
            OracleConnection connection = new OracleConnection(connectionString);

            using (OracleCommand cmd = connection.CreateCommand())
            {
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = sql;
                connection.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
        }

        public static OracleDataReader ExecuteReader(string sql, params OracleParameter[] parameters)
        {
            OracleConnection connection = new OracleConnection(connectionString);
            OracleCommand cmd = connection.CreateCommand();

            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = sql;
            connection.Open();
            if (parameters != null && parameters.Length > 0)
            {
                foreach (OracleParameter parameter in parameters)
                {
                    cmd.Parameters.Add(parameter);
                }
            }
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);


        }

        public static OracleDataReader ExecuteReader(string connectionString, string sql, params OracleParameter[] parameters)
        {
            OracleConnection connection = new OracleConnection(connectionString);
            OracleCommand cmd = connection.CreateCommand();

            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = sql;
            connection.Open();
            foreach (OracleParameter parameter in parameters)
            {
                cmd.Parameters.Add(parameter);
            }
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);


        }

        public static DataTable ExecuteDataTable(string sql)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    using (OracleCommand cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = sql;
                        connection.Open();
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);
                            return dt;
                        }
                    }
                }
                catch
                {
                    throw;
                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
        }

        public static DataTable ExecuteDataTable(string connectionString, string sql)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    using (OracleCommand cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = sql;
                        connection.Open();
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);
                            return dt;
                        }
                    }
                }
                catch
                {
                    throw;
                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
        }

        public static DataTable ExecuteDataTable(string sql, params OracleParameter[] parameters)
        {

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    using (OracleCommand cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = sql;
                        connection.Open();

                        foreach (OracleParameter parameter in parameters)
                        {
                            cmd.Parameters.Add(parameter);
                        }

                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);
                            return dt;
                        }
                    }
                }
                catch
                {
                    throw;
                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }
            }

        }

        public static DataTable ExecuteDataTable(string connectionString, string sql, params OracleParameter[] parameters)
        {

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    using (OracleCommand cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = sql;
                        connection.Open();

                        foreach (OracleParameter parameter in parameters)
                        {
                            cmd.Parameters.Add(parameter);
                        }

                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);
                            return dt;
                        }
                    }
                }
                catch
                {
                    throw;
                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }
            }

        }

        public static object ExecuteScalar(string sql)
        {

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    using (OracleCommand cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = sql;
                        connection.Open();
                        return cmd.ExecuteScalar();
                    }
                }
                catch
                {
                    throw;
                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }
            }

        }

        public static object ExecuteScalar(string connectionString, string sql)
        {

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    using (OracleCommand cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = sql;
                        connection.Open();
                        return cmd.ExecuteScalar();
                    }
                }
                catch
                {
                    throw;
                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }
            }

        }

        public static object ExecuteScalar(string sql, params OracleParameter[] parameters)
        {

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    using (OracleCommand cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = sql;
                        connection.Open();

                        foreach (OracleParameter parameter in parameters)
                        {
                            cmd.Parameters.Add(parameter);
                        }

                        return cmd.ExecuteScalar();
                    }
                }
                catch
                {
                    throw;
                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }
            }

        }

        public static object ExecuteScalar(string connectionString, string sql, params OracleParameter[] parameters)
        {

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    using (OracleCommand cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = sql;
                        connection.Open();

                        foreach (OracleParameter parameter in parameters)
                        {
                            cmd.Parameters.Add(parameter);
                        }

                        return cmd.ExecuteScalar();
                    }
                }
                catch
                {
                    throw;
                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }
            }

        }

        /// <summary>
        /// 执行多条sql语句
        /// </summary>
        /// <param name="list">哈希表,key:sql语句,value:parameters[]</param>
        public static int ExecuteTransaction(List<DictionaryEntry> list)
        {
            int result = 0;

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();
                using (OracleTransaction transaction = connection.BeginTransaction())
                {
                    using (OracleCommand cmd = connection.CreateCommand())
                    {

                        try
                        {
                            cmd.Transaction = transaction;
                            foreach (DictionaryEntry entry in list)
                            {
                                string sql = entry.Key.ToString();
                                cmd.CommandText = sql;
                                cmd.Parameters.Clear();

                                OracleParameter[] parameters = entry.Value as OracleParameter[];
                                foreach (OracleParameter parameter in parameters)
                                {
                                    cmd.Parameters.Add(parameter);
                                }
                                result += cmd.ExecuteNonQuery();
                            }
                            transaction.Commit();

                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            throw ex;
                        }

                    }
                }
                connection.Close();
                connection.Dispose();
            }
            return result;
        }

        /// <summary>
        /// 执行多条sql语句
        /// </summary>
        /// <param name="list">哈希表,key:sql语句,value:parameters[]</param>
        public static int ExecuteTransaction(string connectionString, Hashtable list)
        {
            int result = 0;

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();
                using (OracleTransaction transaction = connection.BeginTransaction())
                {
                    using (OracleCommand cmd = connection.CreateCommand())
                    {

                        try
                        {
                            cmd.Transaction = transaction;
                            foreach (DictionaryEntry entry in list)
                            {
                                string sql = entry.Key.ToString();
                                cmd.CommandText = sql;
                                cmd.Parameters.Clear();

                                OracleParameter[] parameters = entry.Value as OracleParameter[];
                                foreach (OracleParameter parameter in parameters)
                                {
                                    cmd.Parameters.Add(parameter);
                                }
                                result += cmd.ExecuteNonQuery();
                            }
                            transaction.Commit();

                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            throw ex;
                        }

                    }
                }
                connection.Close();
                connection.Dispose();
            }
            return result;
        }

        public static void ExecuteTransaction(IList<KeyValuePair<string, OracleParameter[]>> list)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();
                using (OracleTransaction transaction = connection.BeginTransaction())
                {
                    using (OracleCommand cmd = connection.CreateCommand())
                    {
                        try
                        {
                            cmd.Transaction = transaction;
                            foreach (KeyValuePair<string, OracleParameter[]> item in list)
                            {
                                cmd.CommandText = item.Key;
                                cmd.Parameters.Clear();
                                foreach (OracleParameter p in item.Value)
                                {
                                    cmd.Parameters.Add(p);
                                }
                                int re = cmd.ExecuteNonQuery();
                            }
                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            throw ex;
                        }
                    }
                }
                connection.Close();
                connection.Dispose();
            }
        }

        public static void ExecuteTransaction(string connectionString, IList<KeyValuePair<string, OracleParameter[]>> list)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();
                using (OracleTransaction transaction = connection.BeginTransaction())
                {
                    using (OracleCommand cmd = connection.CreateCommand())
                    {
                        try
                        {
                            cmd.Transaction = transaction;
                            foreach (KeyValuePair<string, OracleParameter[]> item in list)
                            {
                                cmd.CommandText = item.Key;
                                cmd.Parameters.Clear();
                                foreach (OracleParameter p in item.Value)
                                {
                                    cmd.Parameters.Add(p);
                                }
                                int re = cmd.ExecuteNonQuery();
                            }
                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            throw ex;
                        }
                    }
                }
                connection.Close();
                connection.Dispose();
            }
        }

        public static void ExecuteTransaction(string sql)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();
                using (OracleTransaction transaction = connection.BeginTransaction())
                {
                    using (OracleCommand cmd = connection.CreateCommand())
                    {
                        try
                        {
                            cmd.Transaction = transaction;
                            cmd.CommandText = sql;
                            cmd.ExecuteNonQuery();
                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            throw ex;
                        }
                    }

                }
                connection.Close();
                connection.Dispose();
            }
        }

        public static void ExecuteTransaction(string connectionString, string sql)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();
                using (OracleTransaction transaction = connection.BeginTransaction())
                {
                    using (OracleCommand cmd = connection.CreateCommand())
                    {
                        try
                        {
                            cmd.Transaction = transaction;
                            cmd.CommandText = sql;
                            cmd.ExecuteNonQuery();
                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            throw ex;
                        }
                    }

                }
                connection.Close();
                connection.Dispose();
            }
        }

        public static void ExecuteTransaction(IList<string> list)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();
                using (OracleTransaction transaction = connection.BeginTransaction())
                {
                    using (OracleCommand cmd = connection.CreateCommand())
                    {
                        try
                        {
                            cmd.Transaction = transaction;
                            foreach (string sql in list)
                            {
                                cmd.CommandText = sql;
                                cmd.Parameters.Clear();
                                int re = cmd.ExecuteNonQuery();
                            }
                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            throw ex;
                        }
                    }
                }
                connection.Close();
                connection.Dispose();
            }
        }

        public static void ExecuteTransaction(string connectionString, IList<string> list)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();
                using (OracleTransaction transaction = connection.BeginTransaction())
                {
                    using (OracleCommand cmd = connection.CreateCommand())
                    {
                        try
                        {
                            cmd.Transaction = transaction;
                            foreach (string sql in list)
                            {
                                cmd.CommandText = sql;
                                cmd.Parameters.Clear();
                                int re = cmd.ExecuteNonQuery();
                            }
                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            throw ex;
                        }
                    }
                }
                connection.Close();
                connection.Dispose();
            }
        }

        public static void ExecuteTransaction(string sql, params OracleParameter[] parameters)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();
                using (OracleTransaction transaction = connection.BeginTransaction())
                {
                    using (OracleCommand cmd = connection.CreateCommand())
                    {
                        try
                        {
                            cmd.Transaction = transaction;
                            cmd.CommandText = sql;
                            foreach (OracleParameter p in parameters)
                            {
                                cmd.Parameters.Add(p);
                            }
                            cmd.ExecuteNonQuery();
                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            throw ex;
                        }
                    }
                }
                connection.Close();
                connection.Dispose();
            }
        }

        public static void ExecuteTransaction(string connectionString, string sql, params OracleParameter[] parameters)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();
                using (OracleTransaction transaction = connection.BeginTransaction())
                {
                    using (OracleCommand cmd = connection.CreateCommand())
                    {
                        try
                        {
                            cmd.Transaction = transaction;
                            cmd.CommandText = sql;
                            foreach (OracleParameter p in parameters)
                            {
                                cmd.Parameters.Add(p);
                            }
                            cmd.ExecuteNonQuery();
                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            throw ex;
                        }
                    }
                }
                connection.Close();
                connection.Dispose();
            }
        }

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="procedureName">存储过程名称</param>
        /// <param name="parameters">存储过程参数</param>
        public static void ExecuteProcedure(string procedureName, params OracleParameter[] parameters)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();
                using (OracleCommand cmd = connection.CreateCommand())
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = procedureName;
                        foreach (OracleParameter p in parameters)
                        {
                            cmd.Parameters.Add(p);
                        }
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                connection.Close();
                connection.Dispose();
            }
        }

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="procedureName">存储过程名称</param>
        /// <param name="parameters">存储过程参数</param>
        public static void ExecuteProcedure(string connectionString, string procedureName, params OracleParameter[] parameters)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();
                using (OracleCommand cmd = connection.CreateCommand())
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = procedureName;
                        foreach (OracleParameter p in parameters)
                        {
                            cmd.Parameters.Add(p);
                        }
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                connection.Close();
                connection.Dispose();
            }
        }

        public static void ExecuteTransaction(IList<KeyValuePair<string, IList<OracleParameter>>> list)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();
                using (OracleTransaction transaction = connection.BeginTransaction())
                {
                    using (OracleCommand cmd = connection.CreateCommand())
                    {
                        try
                        {
                            cmd.Transaction = transaction;
                            foreach (KeyValuePair<string, IList<OracleParameter>> item in list)
                            {
                                cmd.CommandText = item.Key;
                                cmd.Parameters.Clear();
                                foreach (OracleParameter p in item.Value)
                                {
                                    cmd.Parameters.Add(p);
                                }
                                int count = cmd.ExecuteNonQuery();
                            }
                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            throw ex;
                        }
                    }
                }
                connection.Close();
                connection.Dispose();
            }
        }
    }
}

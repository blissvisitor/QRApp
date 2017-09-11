using Infrastructure;
using Model.models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.dal
{
    public class ClassDal
    {
        /// <summary>
        /// 获取所有一级分类
        /// </summary>
        /// <returns></returns>
        public static List<FIRSTCLASS> getAllFirstClass()
        {
            List<FIRSTCLASS> lst = new List<FIRSTCLASS>();
            try
            {
                string sql = "select id,name from firstclass order by name";
                DataTable dt = MySqlDHelper.ExecuteDataTable(sql);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        FIRSTCLASS fc = new FIRSTCLASS();
                        fc.ID = int.Parse(row["id"].ToString());
                        fc.NAME= row["name"].ToString();
                        lst.Add(fc);
                    }
                }
                return lst;
            }
            catch (Exception e)
            {
                string err = new DateTime().ToString() + " 获取所有一级分类：class/getAllFirstClass ,错误：" + e.Message;
                LogHelper.WriteLog(err);
                return lst;
            }
        }
        /// <summary>
        /// 根据一级分类id获取二级分类
        /// </summary>
        /// <param name="firstId">first_id</param>
        /// <returns></returns>
        public static List<SECONDCLASS> getSecondClassByFirstId(int firstId)
        {
            List<SECONDCLASS> lst = new List<SECONDCLASS>();
            try
            {
                string sql = "select id,first_id,name from secondclass where  first_id=" + firstId + " order by name ";
                DataTable dt = MySqlDHelper.ExecuteDataTable(sql);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        SECONDCLASS sc= new SECONDCLASS();
                        sc.ID = int.Parse(row["id"].ToString());
                        sc.FIRST_ID = int.Parse(row["first_id"].ToString());
                        sc.NAME = row["name"].ToString();
                        lst.Add(sc);
                    }
                }
                return lst;
            }
            catch (Exception e)
            {
                string err = new DateTime().ToString() + " 根据一级分类id获取二级分类：class/getSecondClassByFirstId ,错误：" + e.Message;
                LogHelper.WriteLog(err);
                return lst;
            }
        }

        /// <summary>
        /// 根据二级分类id获取三级分类
        /// </summary>
        /// <param name="secondID">second_id</param>
        /// <returns></returns>
        public static List<THIRDCLASS> getThirdClassBySecondId(int secondId)
        {
            List<THIRDCLASS> lst = new List<THIRDCLASS>();
            try
            {
                string sql = "select id,first_id,second_id,name from thirdclass where second_id=" + secondId + " order by name ";
                DataTable dt = MySqlDHelper.ExecuteDataTable(sql);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        THIRDCLASS tc = new THIRDCLASS();
                        tc.ID = int.Parse(row["id"].ToString());
                        tc.FIRST_ID = int.Parse(row["first_id"].ToString());
                        tc.SECOND_ID = int.Parse(row["second_id"].ToString());
                        tc.NAME = row["name"].ToString();
                        lst.Add(tc);
                    }
                }
                return lst;
            }
            catch (Exception e)
            {
                string err = new DateTime().ToString() + " 根据二级分类id获取三级分类：class/getThirdClassBySecondId ,错误：" + e.Message;
                LogHelper.WriteLog(err);
                return lst;
            }
        }
        /// <summary>
        /// 根据一级分类id获取三级分类
        /// </summary>
        /// <param name="firstId">first_id</param>
        /// <returns></returns>
        public static List<THIRDCLASS> getThirdClassByFirstId(int firstId)
        {
            List<THIRDCLASS> lst = new List<THIRDCLASS>();
            try
            {
                string sql = "select id,first_id,second_id,name from thirdclass where  first_id=" + firstId + " order by name ";
                DataTable dt = MySqlDHelper.ExecuteDataTable(sql);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        THIRDCLASS tc = new THIRDCLASS();
                        tc.ID = int.Parse(row["id"].ToString());
                        tc.FIRST_ID = int.Parse(row["first_id"].ToString());
                        tc.SECOND_ID = int.Parse(row["second_id"].ToString());
                        tc.NAME = row["name"].ToString();
                        lst.Add(tc);
                    }
                }
                return lst;
            }
            catch (Exception e)
            {
                string err = new DateTime().ToString() + " 根据一级分类id获取三级分类：class/getThirdClassByFirstId,错误：" + e.Message;
                LogHelper.WriteLog(err);
                return lst;
            }
        }

    }
}

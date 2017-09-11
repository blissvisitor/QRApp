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
    public class RegionDal
    {
        /// <summary>
        /// 获取所有省份
        /// </summary>
        /// <returns></returns>
        public static List<PROVINCE>  getAllProvince() {
            List<PROVINCE> lst = new List<PROVINCE>();
            try
            {
                string sql = "select id,province_id,province_name from province order by province_id ";
                DataTable dt = MySqlDHelper.ExecuteDataTable(sql);
                if (dt.Rows.Count > 0) {
                    foreach (DataRow row in dt.Rows) {
                        PROVINCE pr = new PROVINCE();
                        pr.ID =int.Parse(row["id"].ToString());
                        pr.PROVINCE_ID = row["province_id"].ToString();
                        pr.PROVINCE_NAME = row["province_name"].ToString();
                        lst.Add(pr);
                    }
                }
                return lst;
            }
            catch (Exception e)
            {
                string err = new DateTime().ToString() + " 获取所有省份：region/getAllProvince ,错误：" + e.Message;
                LogHelper.WriteLog(err);
                return lst;
            }   
        }
        /// <summary>
        /// 根据省份id获取城市
        /// </summary>
        /// <param name="proId">province_id</param>
        /// <returns></returns>
        public static List<CITY> getCityByProId(string proId) {
            List<CITY> lst = new List<CITY>();
            try
            {
                string sql = "select id,province_id,city_id,city_name from city  where  province_id='"+proId+"' order by city_id ";
                DataTable dt = MySqlDHelper.ExecuteDataTable(sql);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        CITY city= new CITY();
                        city.ID = int.Parse(row["id"].ToString());
                        city.PROVINCE_ID = row["province_id"].ToString();
                        city.CITY_ID = row["city_id"].ToString();
                        city.CITY_NAME = row["city_name"].ToString();
                        lst.Add(city);
                    }
                }
                return lst;
            }
            catch (Exception e)
            {
                string err = new DateTime().ToString() + " 根据省份id获取城市：region/getCityByProId ,错误：" + e.Message;
                LogHelper.WriteLog(err);
                return lst;
            }
        }
        /// <summary>
        /// 根据城市id获取区县
        /// </summary>
        /// <param name="cityId">cityId</param>
        /// <returns></returns>
        public static List<COUNTY> getCountyByCityId(string cityId)
        {
            List<COUNTY> lst = new List<COUNTY>();
            try
            {
                string sql = "select id,city_id,county_id,county_name from county  where  city_id='" + cityId + "'order by county_id ";
                DataTable dt = MySqlDHelper.ExecuteDataTable(sql);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        COUNTY county = new COUNTY();
                        county.ID = int.Parse(row["id"].ToString());
                        county.CITY_ID = row["city_id"].ToString();
                        county.COUNTY_ID = row["county_id"].ToString();
                        county.COUNTY_NAME = row["county_name"].ToString();
                        lst.Add(county);
                    }
                }
                return lst;
            }
            catch (Exception e)
            {
                string err = new DateTime().ToString() + " 根据城市id获取区县：region/getCountyByCityId ,错误：" + e.Message;
                LogHelper.WriteLog(err);
                return lst;
            }
        }
        /// <summary>
        /// 根据区县id获取乡镇
        /// </summary>
        /// <param name="countyId">province_id</param>
        /// <returns></returns>
        public static List<TOWN> getTownByCountyId(string countyId)
        {
            List<TOWN> lst = new List<TOWN>();
            try
            {
                string sql = "select id,county_id,town_id,town_name from town  where  county_id='" + countyId + "'order by town_id ";
                DataTable dt = MySqlDHelper.ExecuteDataTable(sql);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        TOWN town = new TOWN();
                        town.ID = int.Parse(row["id"].ToString());
                        town.COUNTY_ID = row["county_id"].ToString();
                        town.TOWN_ID = row["town_id"].ToString();
                        town.TOWN_NAME = row["town_name"].ToString();
                        lst.Add(town);
                    }
                }
                return lst;
            }
            catch (Exception e)
            {
                string err = new DateTime().ToString() + " 根据区县id获取乡镇：region/getTownByCountyId ,错误：" + e.Message;
                LogHelper.WriteLog(err);
                return lst;
            }
        }
        /// <summary>
        /// 根据id获取乡镇
        /// </summary>
        /// <param name="countyId">province_id</param>
        /// <returns></returns>
        public static List<VILLAGE> getVillageByTownId(string townId)
        {
            List<VILLAGE> lst = new List<VILLAGE>();
            try
            {
                string sql = "select id,town_id,village_id,village_name from village  where  town_id='" + townId + "'order by village_id ";
                DataTable dt = MySqlDHelper.ExecuteDataTable(sql);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        VILLAGE village = new VILLAGE();
                        village.ID = int.Parse(row["id"].ToString());
                        village.TOWN_ID = row["town_id"].ToString();
                        village.VILLAGE_ID = row["village_id"].ToString();
                        village.VILLAGE_NAME = row["village_name"].ToString();
                        lst.Add(village);
                    }
                }
                return lst;
            }
            catch (Exception e)
            {
                string err = new DateTime().ToString() + " 根据城市id获取区县：region/getVillageByTownId ,错误：" + e.Message;
                LogHelper.WriteLog(err);
                return lst;
            }
        }
    }
}

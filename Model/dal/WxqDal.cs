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
   public class WxqDal
    {
        //获取微信二维码
        public static List<WXQ> getWXQR(int start,int limit) {
            
            List<WXQ> lslt = new List<WXQ>();
            try
            {
                string sql = "select* from wxq limit " + (start - 1) * limit + "," + limit;
                DataTable dt = MySqlDHelper.ExecuteDataTable(sql);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        WXQ wxq = new WXQ();
                        wxq.ID = int.Parse(row["id"].ToString());
                        wxq.CITYID = row["city_id"].ToString();
                        wxq.PROID = row["pro_id"].ToString();
                        wxq.COUNTYID = row["county_id"].ToString();
                        if (string.IsNullOrEmpty(row["pubtime"].ToString())) {
                            wxq.PUBTIME = Convert.ToDateTime(row["pubtime"].ToString());
                        }
                        if (string.IsNullOrEmpty(row["endtime"].ToString()))
                        {
                            wxq.PUBTIME = Convert.ToDateTime(row["endtime"].ToString());
                        }
                        if (string.IsNullOrEmpty(row["firstclass"].ToString())) {
                            wxq.FIRSTCLASS = Convert.ToInt32(row["firstclass"]);
                        }
                        if (string.IsNullOrEmpty(row["secondclass"].ToString()))
                        {
                            wxq.SECONDCLASS = Convert.ToInt32(row["secondclass"]);
                        }
                        if (string.IsNullOrEmpty(row["thirdclass"].ToString()))
                        {
                            wxq.THIRDCLASS = Convert.ToInt32(row["thirdclass"]);
                        }
                        wxq.FIRSTCLASS = row["firstclass"].ToString();

                        pr.PROVINCE_ID = row["province_id"].ToString();
                        pr.PROVINCE_NAME = row["province_name"].ToString();
                        lst.Add(pr);
                    }
                }
                return lst;
            }
            catch (Exception e)
            {

                throw;
            }
            

        }
        /// <summary>
        /// 获取所有省份
        /// </summary>
        /// <returns></returns>
        public static List<WXQ> getWXQR(int id,string title,string content,string classify,string label,string region,DateTime )
        {
            List<PROVINCE> lst = new List<PROVINCE>();
            try
            {
                string sql = "select id,province_id,province_name from province order by province_id ";
                DataTable dt = MySqlDHelper.ExecuteDataTable(sql);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        PROVINCE pr = new PROVINCE();
                        pr.ID = int.Parse(row["id"].ToString());
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

    }
}

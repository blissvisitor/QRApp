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
    public class ProvinceDal
    {
        public static List<Province>  getAllList() {
            List<Province> lst = new List<Province>();
            try
            {
                string sql = "select * from province order by province_name ";
                DataTable dt = MySqlDHelper.ExecuteDataTable(sql);
                if (dt.Rows.Count > 0) {
                    foreach (Province pro in dt.Rows) {
                        lst.Add(pro);
                    }
                }
                return lst;
            }
            catch (Exception e)
            {
                return lst;
            }   
        }
    }
}

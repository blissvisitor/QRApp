using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.models
{
    public class Town
    {
        //unique id
        public int ID { get; set; }
        //county id
        public int COUNTY_ID { get; set; }
        //town id
        public int TOWN_ID { get; set; }
        //乡镇
        public string TOWN_NAME { get; set; }
    }
}

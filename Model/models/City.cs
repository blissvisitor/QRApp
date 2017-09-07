using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.models
{
    public class City
    {
        //unique id
        public int ID { get; set; }
        //province id
        public int PROVINCE_ID { get; set; }
        //city id
        public int CITY_ID { get; set; }
        //市
        public string CITY_NAME { get; set; }
    }
}

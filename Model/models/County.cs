using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.models
{
    public class COUNTY
    {
        //unique id
        public int ID { get; set; }
        //city id
        public string CITY_ID { get; set; }
        //county id
        public string COUNTY_ID { get; set; }
        //县
        public string COUNTY_NAME { get; set; }
    }
}

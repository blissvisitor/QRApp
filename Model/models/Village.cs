using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.models
{
    public class VILLAGE
    {
        //unique id
        public int ID { get; set; }
        //county id
        public string TOWN_ID { get; set; }
        //town id
        public string VILLAGE_ID { get; set; }
        //村
        public string VILLAGE_NAME { get; set; }
    }
}

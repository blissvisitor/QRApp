using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.models
{
    public class Village
    {
        //unique id
        public int ID { get; set; }
        //county id
        public int TOWN_ID { get; set; }
        //town id
        public int VILLAGE_ID { get; set; }
        //村
        public string TVILLAGE_NAME { get; set; }
    }
}

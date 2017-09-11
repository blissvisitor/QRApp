using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.models
{
    //三级分类
    public class THIRDCLASS
    {
        //唯一id
        public int ID { get; set; }
        //一级id
        public int FIRST_ID { get; set; }
        //二级id
        public int SECOND_ID{ get; set; }
        //名称
        public string NAME { get; set; }
    }
}

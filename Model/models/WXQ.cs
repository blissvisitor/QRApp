using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.models
{
    public class WXQ
    {
        //unique id
        public int ID { get; set; }
        //导航
        public string NAVIGATION { get; set; }
        //标题
        public string TITLE { get; set; }
        //简介
        public string CONTENT { get; set; }
        //标签
        public string  LABEL{ get; set; }
        //区域
        public string REGION { get; set; }
        //发布时间
        public DateTime PUBTIME { get; set; }
        //qq号
        public string QQ { get; set; }
        //联系人
        public string CONTACT { get; set; }
        //电话
        public string PHONENUM { get; set; }
        //群主微信号
        public string GROUPMG { get; set; }
        //
        public DateTime ENDTIME { get; set; }
        //二维码图片路径
        public string QRIMG { get; set; }
        //页面地址
        public string PAGEURL { get; set; }
        //一级分类
        public int FIRSTCLASS { get; set; }
        //二级分类
        public int SECONDCLASS { get; set; }
        //三级分类
        public int THIRDCLASS { get; set; }
        //省代码
        public string PROID { get; set; }
        //市代码
        public string CITYID { get; set; }
        //县代码
        public string COUNTYID { get; set; }

    }
}

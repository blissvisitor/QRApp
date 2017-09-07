using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ForestrySystemNetPart.RemoteObjects.RM4Excel;

namespace ForestrySystemNetPart.RemoteObjects
{
    /// <summary>
    /// 用来生成Excel时用到的数据结构
    /// </summary>
    public class RM4ExcelData
    {
        /// <summary>
        /// Excel的标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 填充Excel用到的数据
        /// </summary>
        public List<RM4ExcelDataContentObject> Datas { get; set; }
    }
}

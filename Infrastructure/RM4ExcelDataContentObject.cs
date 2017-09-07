using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForestrySystemNetPart.RemoteObjects.RM4Excel
{
    public class RM4ExcelDataContentObject
    {
        /// <summary>
        /// 列要显示的名称
        /// </summary>
        public string ColumnName { get; set; }

        /// <summary>
        /// 列的数据
        /// </summary>
        public List<string> ColumnValues { get; set; }

    }
}

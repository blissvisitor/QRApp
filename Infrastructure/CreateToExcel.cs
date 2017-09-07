using System;
using System.Configuration;

using System.Collections.Generic;
using System.IO;
using NPOI;
using NPOI.HSSF;
using NPOI.HPSF;
using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.SS.UserModel;
using NPOI.POIFS;
using NPOI.Util;
using System.Data;
using System.Linq;
using System.Web;
using NPOI.SS;
using NPOI.DDF;
using NPOI.SS.Util;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Text;
using System.Web.Script.Serialization;
using System.Reflection;
using System.Text.RegularExpressions;
using Infrastructure;
using ForestrySystemNetPart.RemoteObjects;


namespace ForestrySystemNetPart.FXServiceLibrary
{
   // [RemotingService("Fluorine configuration service")]
    public class CreateToExcel
    {

        //  public string strFileName = @"C:\Documents and Settings\";
        public string strFileName = "";
        public string strHeaderText = "";
        public void CreateExcel(string json, string coveredrate)
        {
            string lstat = json;

            string lstatvalue = lstat.Replace("{", "").Replace("}", "").Replace("[", "").Replace("]", "");
            string[] statvalue = lstatvalue.Split(',');
            int index1 = 0;
            int index2 = 0;
            List<string> valuelist = new List<string>();
            for (int i = 0; i < statvalue.Length; i++)
            {
                int tem1 = statvalue[i].IndexOf("value");
                if (tem1 != -1)
                {
                    index1 = i;
                    break;
                }

            }
            for (int j = 0; j < statvalue.Length; j++)
            {
                int tem2 = statvalue[j].IndexOf("field");
                if (tem2 != -1)
                {
                    index2 = j;
                    break;
                }
            }
            string fistvalue = statvalue[index1].Remove(0, 9);
            string[] havefield = statvalue[index2].Split(':');
            strHeaderText = coveredrate;
            valuelist.Add(fistvalue);
            for (int j = index1 + 1; j < statvalue.Length; j++)
            {
                valuelist.Add(statvalue[j]);
            }


            DataTable ResultTable = ConverToDatatable(valuelist);
            string filename = GetFileName(havefield[2]);
            filename = filename.Replace('\'', '-');
            string paths = HttpContext.Current.Server.MapPath("~");
            strFileName = paths + "\\uploads\\excel";
            strFileName = strFileName + "\\" + filename;
     
          //  strHeaderText = GetFieldName(strHeaderText);
            StartCreateExcel(ResultTable, strHeaderText, strFileName);

        }

        private string GetFieldName(string text)
        {
            string filedname = "";
            switch (text)
            {
                case "'DCRY'":
                    filedname = "调查人员统计表";
                    break;
                case "'DCSJ'":
                    filedname = "调查日期统计表";
                    break;

                default:
                    text.Replace('\'', ' ');
                    filedname = text + "统计表";
                    break;
            }
            return filedname;
        }

        private string GetFileName(string field)
        {
            string time = DateTime.Now.ToString("yyyyMMddHHmmss");
            string filename = time + field + ".xls";
            return filename;
        }

        //private string GetSavePath()
        //{
        //    string path = @"D:\Platform_Data\EXCEL\filename.xls";
        //    Shell32.Shell picker = new Shell32.ShellClass();

        //    Shell32.Folder folder = picker.BrowseForFolder
        //     (0, "Resource Updater", 0, 0);

        //    if (folder == null)
        //        return path; //user hit cancel

        //    Shell32.FolderItem fi = (folder as Shell32.Folder3).Self;
        //    string thePath = fi.Path;
        //    return path;
        //}

        private DataTable ConverToDatatable(IList<string> valuelist)
        {
            DataTable ValueTable = new DataTable();
            ValueTable.Columns.Add("Field", typeof(string));
            ValueTable.Columns.Add("Value", typeof(string));
            for (int i = 0; i < valuelist.Count; i++)
            {
                var tem = valuelist[i];
                string[] tems = tem.Split(':');
                string field = tems[0].Replace("'", "");
                DataRow dows = ValueTable.NewRow();
                dows["Field"] = field;
                dows["Value"] = tems[1];
                ValueTable.Rows.Add(dows);

            }
            return ValueTable;
        }

        private static void StartCreateExcel(DataTable dtSource, string strHeaderText, string strFileName)
        {
            using (MemoryStream ms = ExportDT(dtSource, strHeaderText))
            {
                using (FileStream fs = new FileStream(strFileName, FileMode.Create, FileAccess.Write))
                {
                    byte[] data = ms.ToArray();
                    fs.Write(data, 0, data.Length);
                    fs.Flush();
                }
            }
        }


        private static MemoryStream ExportDT(DataTable dtSource, string strHeaderText)
        {
            HSSFWorkbook workbook = new HSSFWorkbook();
            HSSFSheet sheet = workbook.CreateSheet() as HSSFSheet;

            #region 右击文件 属性信息

            //{
            //    DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
            //    dsi.Company = "http://www.yongfa365.com/";
            //    workbook.DocumentSummaryInformation = dsi;

            //    SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
            //    si.Author = "柳永法"; //填加xls文件作者信息
            //    si.ApplicationName = "NPOI测试程序"; //填加xls文件创建程序信息
            //    si.LastAuthor = "柳永法2"; //填加xls文件最后保存者信息
            //    si.Comments = "说明信息"; //填加xls文件作者信息
            //    si.Title = "NPOI测试"; //填加xls文件标题信息
            //    si.Subject = "NPOI测试Demo"; //填加文件主题信息
            //    si.CreateDateTime = DateTime.Now;
            //    workbook.SummaryInformation = si;
            //}

            #endregion

            HSSFCellStyle dateStyle = workbook.CreateCellStyle() as HSSFCellStyle;
            HSSFDataFormat format = workbook.CreateDataFormat() as HSSFDataFormat;
            dateStyle.DataFormat = format.GetFormat("yyyy-mm-dd");

            //取得列宽
            int[] arrColWidth = new int[dtSource.Columns.Count];
            foreach (DataColumn item in dtSource.Columns)
            {
                arrColWidth[item.Ordinal] = Encoding.GetEncoding(936).GetBytes(item.ColumnName.ToString()).Length;
            }
            for (int i = 0; i < dtSource.Rows.Count; i++)
            {
                for (int j = 0; j < dtSource.Columns.Count; j++)
                {
                    int intTemp = Encoding.GetEncoding(936).GetBytes(dtSource.Rows[i][j].ToString()).Length;
                    if (intTemp > arrColWidth[j])
                    {
                        arrColWidth[j] = intTemp;
                    }
                }
            }
            int rowIndex = 0;

            foreach (DataRow row in dtSource.Rows)
            {
                #region 新建表，填充表头，填充列头，样式

                if (rowIndex == 65535 || rowIndex == 0)
                {
                    if (rowIndex != 0)
                    {
                        sheet = workbook.CreateSheet() as HSSFSheet;
                    }

                    #region 表头及样式

                    {
                        HSSFRow headerRow = sheet.CreateRow(0) as HSSFRow;
                        headerRow.HeightInPoints = 25;
                        headerRow.CreateCell(0).SetCellValue(strHeaderText);

                        HSSFCellStyle headStyle = workbook.CreateCellStyle() as HSSFCellStyle;
                        headStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
                        HSSFFont font = workbook.CreateFont() as HSSFFont;
                        font.FontHeightInPoints = 20;
                        font.Boldweight = 700;
                        headStyle.SetFont(font);

                        headerRow.GetCell(0).CellStyle = headStyle;

                        sheet.AddMergedRegion(new Region(0, 0, 0, dtSource.Columns.Count - 1));
                        //headerRow.Dispose();
                    }

                    #endregion


                    #region 列头及样式

                    {
                        HSSFRow headerRow = sheet.CreateRow(1) as HSSFRow;


                        HSSFCellStyle headStyle = workbook.CreateCellStyle() as HSSFCellStyle;
                        headStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
                        HSSFFont font = workbook.CreateFont() as HSSFFont;
                        font.FontHeightInPoints = 10;
                        font.Boldweight = 700;
                        headStyle.SetFont(font);


                        foreach (DataColumn column in dtSource.Columns)
                        {
                            headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);
                            headerRow.GetCell(column.Ordinal).CellStyle = headStyle;

                            //设置列宽
                            sheet.SetColumnWidth(column.Ordinal, (arrColWidth[column.Ordinal] + 1) * 256);

                        }
                        //headerRow.Dispose();
                    }

                    #endregion

                    rowIndex = 2;
                }

                #endregion

                #region 填充内容

                HSSFRow dataRow = sheet.CreateRow(rowIndex) as HSSFRow;
                foreach (DataColumn column in dtSource.Columns)
                {
                    HSSFCell newCell = dataRow.CreateCell(column.Ordinal) as HSSFCell;

                    string drValue = row[column].ToString();

                    switch (column.DataType.ToString())
                    {
                        case "System.String": //字符串类型
                            double result;
                            if (isNumeric(drValue, out result))
                            {

                                double.TryParse(drValue, out result);
                                newCell.SetCellValue(result);
                                break;
                            }
                            else
                            {
                                newCell.SetCellValue(drValue);
                                break;
                            }

                        case "System.DateTime": //日期类型
                            DateTime dateV;
                            DateTime.TryParse(drValue, out dateV);
                            newCell.SetCellValue(dateV);

                            newCell.CellStyle = dateStyle; //格式化显示
                            break;
                        case "System.Boolean": //布尔型
                            bool boolV = false;
                            bool.TryParse(drValue, out boolV);
                            newCell.SetCellValue(boolV);
                            break;
                        case "System.Int16": //整型
                        case "System.Int32":
                        case "System.Int64":
                        case "System.Byte":
                            int intV = 0;
                            int.TryParse(drValue, out intV);
                            newCell.SetCellValue(intV);
                            break;
                        case "System.Decimal": //浮点型
                        case "System.Double":
                            double doubV = 0;
                            double.TryParse(drValue, out doubV);
                            newCell.SetCellValue(doubV);
                            break;
                        case "System.DBNull": //空值处理
                            newCell.SetCellValue("");
                            break;
                        default:
                            newCell.SetCellValue("");
                            break;
                    }

                }

                #endregion

                rowIndex++;
            }
            using (MemoryStream ms = new MemoryStream())
            {
                workbook.Write(ms);
                ms.Flush();
                ms.Position = 0;

                //sheet;
                //workbook.Dispose();

                return ms;
            }
        }

        public static bool isNumeric(String message, out double result)
        {
            Regex rex = new Regex(@"^[-]?\d+[.]?\d*$");
            result = -1;
            if (rex.IsMatch(message))
            {
                result = double.Parse(message);
                return true;
            }
            else
                return false;

        }


        #region 接收生成查询结果数据结构的json串，生成Excel文件

        public string CreateExcelWithRJson(string jsonStr)
        {
            RM4ExcelData excelData = DataContractHelper.FromJsonTo<RM4ExcelData>(jsonStr);
            DataTable exceltable=CreateMyExcel(excelData);
            strHeaderText = excelData.Title;

            string paths = HttpContext.Current.Server.MapPath("~");
            strFileName = paths + "\\upload\\excel";
            strHeaderText = GetFieldName(strHeaderText);
            string filename = GetFileName(strHeaderText);
            strFileName = strFileName + "\\" + filename;

            StartCreateExcel(exceltable, strHeaderText, strFileName);
            return filename;

        }

        /// <summary>
        /// 生成Excel
        /// </summary>
        /// <param name="excelData"></param>
        private DataTable CreateMyExcel(RM4ExcelData excelData)
        {
            DataTable exceltable = new DataTable();
            List<string> fieldlist = new List<string>();
            for (int i = 0; i < excelData.Datas.Count; i++)
            {
                string filedname=excelData.Datas[i].ColumnName;
                exceltable.Columns.Add(filedname);
                fieldlist.Add(filedname);
            }
            for (int j = 0; j < excelData.Datas[0].ColumnValues.Count; j++)
            {
                DataRow datarow = exceltable.NewRow();
                for (int h = 0; h < fieldlist.Count; h++)
                {
                    string field = fieldlist[h];
                    datarow[field] = excelData.Datas[h].ColumnValues[j];
                }
                exceltable.Rows.Add(datarow);
            }
            return exceltable;
        
        }
        #endregion
       
        /// <summary>
        /// datatable导出到excel
        /// </summary>
        /// <param name="dtSource">datatable</param>
        /// <param name="strFileName">strFileName</param>
        /// <param name="sup">Supplier</param>
        /// <returns></returns>
        public  bool ExportEasy(DataTable dtSource, string strFileName)
        {
            try
            {
                HSSFWorkbook workbook = new HSSFWorkbook();
                //HSSFSheet sheet = workbook.CreateSheet();
                ISheet sheet = workbook.CreateSheet();
                //填充表头
                //HSSFRow dataRow = sheet.CreateRow(0);
                IRow dataRow = sheet.CreateRow(0);
                foreach (DataColumn column in dtSource.Columns)
                {
                    dataRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);
                }
                //合并单元格
                //dataRow.CreateCell(2).SetCellValue(sup.SupplierCode);
                //SetCellRangeAddress(sheet, 0, 0, 0, 1);
                //dataRow.CreateCell(0).SetCellValue("供应商代码：");
                //SetCellRangeAddress(sheet, 0, 0, 3, 4);
                //dataRow.CreateCell(3).SetCellValue("供应商名称：");
                //SetCellRangeAddress(sheet, 0, 0, 5, 7);
                //dataRow.CreateCell(8).SetCellValue("专柜编码：");
                //SetCellRangeAddress(sheet, 0, 0, 21, 22);
                //dataRow.CreateCell(21).SetCellValue("经营方式：");
                //dataRow.CreateCell(5).SetCellValue(sup.SupplierName);
                //dataRow.CreateCell(9).SetCellValue(sup.SpecialCode);
                //dataRow.CreateCell(23).SetCellValue(sup.ModeOperation);

                //填充内容
                for (int i = 0; i < dtSource.Rows.Count; i++)
                {
                    dataRow = sheet.CreateRow(i+1);
                    for (int j = 0; j < dtSource.Columns.Count; j++)
                    {
                        dataRow.CreateCell(j).SetCellValue(dtSource.Rows[i][j].ToString());
                        //if (j > 19)
                        //{
                        //    if (j == 20)
                        //        continue;
                        //    else
                        //    {
                        //        if (j > 23)
                        //        {
                        //            if (j == 24)
                        //                continue;
                        //            else
                        //            {
                        //                dataRow.CreateCell(j).SetCellValue(dtSource.Rows[i][j].ToString());
                        //            }
                        //        }
                        //        else
                        //        {
                        //            dataRow.CreateCell(j).SetCellValue(dtSource.Rows[i - 1][j - 1].ToString());
                        //        }
                        //    }

                        //}
                        //else
                        //{
                        //    dataRow.CreateCell(j).SetCellValue(dtSource.Rows[i - 1][j].ToString());
                        //}

                    }
                }
                //保存
                using (MemoryStream ms = new MemoryStream())
                {
                    using (FileStream fs = new FileStream(strFileName, FileMode.Create, FileAccess.Write))
                    {
                        workbook.Write(fs);
                    }
                }
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
        }

        /// <summary>
        /// 合并单元格
        /// </summary>
        /// <param name="sheet">要合并单元格所在的sheet</param>
        /// <param name="rowstart">开始行的索引</param>
        /// <param name="rowend">结束行的索引</param>
        /// <param name="colstart">开始列的索引</param>
        /// <param name="colend">结束列的索引</param>
        public static void SetCellRangeAddress(ISheet sheet, int rowstart, int rowend, int colstart, int colend)
        {
            CellRangeAddress cellRangeAddress = new CellRangeAddress(rowstart, rowend, colstart, colend);
            sheet.AddMergedRegion(cellRangeAddress);
        }

    }
}

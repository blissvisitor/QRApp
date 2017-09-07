using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing.Imaging;
using System.ComponentModel;
using System.Web.SessionState;

namespace Infrastructure
{
    public class UploadFile
    {
        public static string uploadimage(string img, FileUpload FileUpload1, string nameImg, string OwnerType)
        {
            //定义image类的对象
            System.Drawing.Image image, newimage_16, newimage_60;
            //建立虚拟路径
            string filePath = HttpContext.Current.Server.MapPath("../../uploads/images/") + OwnerType;
            if (System.IO.Directory.Exists(filePath) == false)
            {
                System.IO.Directory.CreateDirectory(filePath);
            }
            //图片路径
            string imagePath;
            //图片类型
            string imageType;
            //图片名称
            string imageName;
            //提供一个回调方法,用于确定Image对象在执行生成缩略图操作时何时提前取消执行
            //如果此方法确定 GetThumbnailImage 方法应提前停止执行,则返回 true；否则返回 false
            System.Drawing.Image.GetThumbnailImageAbort callb = null;
            string imageurl = "";
            if (!string.IsNullOrEmpty(img))
            {

                //上传图片 
                DateTime m1 = System.DateTime.Now;

                img = m1.Ticks + img.Substring(img.IndexOf("."));
                imageurl = img;

                if ("" != FileUpload1.PostedFile.FileName) //FileUpload1为上传文件控件
                {
                    imagePath = FileUpload1.PostedFile.FileName;
                    //取得图片类型
                    imageType = imagePath.Substring(imagePath.LastIndexOf(".") + 1);
                    //取得图片名称
                    imageName = nameImg;
                    //判断是否是JPG或者GIF图片,这里只是举个例子,并不一定必须是这两种图片
                    if ("JPEG" != imageType && "JPEG" != imageType && "jpeg" != imageType && "JPG" != imageType && "jpg" != imageType && "GIF" != imageType && "gif" != imageType && "PNG" != imageType && "png" != imageType && "BMP" != imageType && "bmp" != imageType)
                    {
                        imageurl = "false";
                    }
                    else
                    {
                        try
                        {
                            //保存到虚拟路径
                            FileUpload1.PostedFile.SaveAs(filePath + "\\" + imageName);
                            //为上传的图片建立引用
                            image = System.Drawing.Image.FromFile(filePath + "\\" + imageName);
                            //生成缩略图16*16
                            newimage_16 = image.GetThumbnailImage(16, 16, callb, new System.IntPtr());
                            newimage_16.Save(filePath + "\\16_" + imageName);
                            //生成缩略图60*60
                            newimage_60 = image.GetThumbnailImage(60, 60, callb, new System.IntPtr());
                            newimage_60.Save(filePath + "\\60_" + imageName);
                            //释放image对象占用的资源
                            image.Dispose();
                            //释放newimage_16对象的资源
                            newimage_16.Dispose();
                            //释放newimage_60对象的资源
                            newimage_60.Dispose();
                        }
                        catch
                        {
                            imageurl = "false";
                        }

                    } 

                }
            }
            else
            {
                imageurl = "false";
            }
            return imageurl;
        }
        /// <summary>
        /// 上传视频
        /// </summary>
        public static string uploadfile(string file, FileUpload FileUpload1, string NewName)
        {
            string fileurl = "";
            if (!string.IsNullOrEmpty(file))
            {
                try
                {
                    fileurl = NewName;
                    FileUpload1.SaveAs(HttpContext.Current.Server.MapPath("../../uploads/videos/") + NewName);
                }
                catch
                {
                    fileurl = "false";
                }

            }
            else
            {
                fileurl = "false";
            }
            return fileurl;
        }
    }
}

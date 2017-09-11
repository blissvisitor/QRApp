using Infrastructure;
using Model.dal;
using Model.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QRApp.Controllers
{
    public class ClassController : Controller
    {
        // GET: Class
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 获取所有一级分类
        /// </summary>
        [HttpGet]
        public void getAllFirstClass()
        {
            List<FIRSTCLASS> lst = ClassDal.getAllFirstClass();
            Response.Write("{\"success\":true,\"data\":" + JsonHelper.ObjectToJson(lst) + "}");
        }
        /// <summary>
        /// 根据一级分类id获取二级分类
        /// </summary>
        /// <param name="firstId">一级分类id</param>
        /// <returns></returns>
        [HttpGet]
        public void getSecondClassByFirstId(int firstId)
        {
            string str = firstId.ToString();
            int n;
            if (int.TryParse(str, out n))
            {
                //为数字
                List<SECONDCLASS> lst = ClassDal.getSecondClassByFirstId(firstId);
                Response.Write("{\"success\":true,\"data\":" + JsonHelper.ObjectToJson(lst) + "}");
            }
            else
            {
                Response.Write("{\"success\":false,\"error\":\"参数错误！\"}");
            }
            
        }

        /// <summary>
        /// 根据一级分类id获取三级分类
        /// </summary>
        /// <param name="firstId">一级分类id</param>
        /// <returns></returns>
        [HttpGet]
        public void getThirdClassByFirstId(int firstId)
        {
            string str = firstId.ToString();
            int n;
            if (int.TryParse(str, out n))
            {
                //为数字
                List<THIRDCLASS> lst = ClassDal.getThirdClassByFirstId(firstId);
                Response.Write("{\"success\":true,\"data\":" + JsonHelper.ObjectToJson(lst) + "}");
            }
            else
            {
                Response.Write("{\"success\":false,\"error\":\"参数错误！\"}");
            }

        }
        /// <summary>
        /// 根据二级分类id获取三级分类
        /// </summary>
        /// <param name="secondId">二级分类id</param>
        /// <returns></returns>
        [HttpGet]
        public void getThirdClassBySecondId(int secondId)
        {
            string str = secondId.ToString();
            int n;
            if (int.TryParse(str, out n))
            {
                //为数字
                List<THIRDCLASS> lst = ClassDal.getThirdClassByFirstId(secondId);
                Response.Write("{\"success\":true,\"data\":" + JsonHelper.ObjectToJson(lst) + "}");
            }
            else
            {
                Response.Write("{\"success\":false,\"error\":\"参数错误！\"}");
            }

        }
    }
}
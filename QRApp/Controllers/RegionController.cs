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
    public class RegionController : Controller
    {
        // GET: Region
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 获取所有省份
        /// </summary>
        [HttpGet]
        public void GetAllProvince()
        {
           
            List<PROVINCE> lst = RegionDal.getAllProvince();
            Response.Write("{\"success\":true,\"data\":" + JsonHelper.ObjectToJson(lst) + "}");
            //return JsonHelper.ObjectToJson(lst);
        }
        /// <summary>
        /// 根据省份获取城市
        /// </summary>
        /// <param name="proId">省份id</param>
        /// <returns></returns>
        [HttpGet]
        [AntiSqlInject]
        public void getCityByProId(string proId)
        {
            if (string.IsNullOrEmpty(proId)) {
                Response.Write("{\"success\":false,\"error\":\"参数错误！\"}");
            }
            List<CITY> lst = RegionDal.getCityByProId(proId);
            Response.Write("{\"success\":true,\"data\":" + JsonHelper.ObjectToJson(lst) + "}");
        }
        /// <summary>
        /// 根据城市获取区县
        /// </summary>
        /// <param name="cityId">城市id</param>
        /// <returns></returns>
        [HttpGet]
        [AntiSqlInject]
        public void getCountyByCityId(string cityId)
        {
            if (string.IsNullOrEmpty(cityId))
            {
                Response.Write("{\"success\":false,\"error\":\"参数错误！\"}");
            }
            List<COUNTY> lst = RegionDal.getCountyByCityId(cityId);
            Response.Write("{\"success\":true,\"data\":" + JsonHelper.ObjectToJson(lst) + "}");
        }
        /// <summary>
        /// 根据区县获取乡镇
        /// </summary>
        /// <param name="countyId">区县id</param>
        /// <returns></returns>
        [HttpGet]
        [AntiSqlInject]
        // countyId 区县id
        public void getTownByCountyId(string countyId)
        {
            if (string.IsNullOrEmpty(countyId))
            {
                Response.Write("{\"success\":false,\"error\":\"参数错误！\"}");
            }
            List<TOWN> lst = RegionDal.getTownByCountyId(countyId);
            Response.Write("{\"success\":true,\"data\":" + JsonHelper.ObjectToJson(lst) + "}");
        }
        /// <summary>
        /// 根据乡镇获取村
        /// </summary>
        /// <param name="townId">乡镇id</param>
        /// <returns></returns>
        [HttpGet]
        [AntiSqlInject]
        public void getVillageByTownId(string townId)
        {
            if (string.IsNullOrEmpty(townId))
            {
                Response.Write("{\"success\":false,\"error\":\"参数错误！\"}");
            }
            List<VILLAGE> lst = RegionDal.getVillageByTownId(townId);
            Response.Write("{\"success\":true,\"data\":" + JsonHelper.ObjectToJson(lst) + "}");
        }
    }
}
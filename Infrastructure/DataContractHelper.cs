using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;

namespace Infrastructure
{
    public static class DataContractHelper
    {
        /// <summary>
        /// 将对象转换成json串
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static string ToJsonString<T>(T item)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
            using (MemoryStream ms = new MemoryStream())
            {
                serializer.WriteObject(ms, item);
                StringBuilder sb = new StringBuilder();
                sb.Append(Encoding.UTF8.GetString(ms.ToArray()));

                return sb.ToString();
            }
        }

        //public static string ToJsonString(T item)
        //{


        //    return "";
        //}

        /// <summary>
        /// 将json串转换成对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonString"></param>
        /// <returns></returns>
        public static T FromJsonTo<T>(string jsonString)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString)))
            {
                T jsonObject = (T)serializer.ReadObject(ms);
                return jsonObject;
            }
        }
    }
}

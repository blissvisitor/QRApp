using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure
{
    /// <summary>
    /// 用于进行是否包含的判断，如需添加  请重载该方法
    /// </summary>
    public class IsContain
    {
        /// <summary>
        /// 判断字串是否在数组中
        /// </summary>
        /// <param name="str1">数组</param>
        /// <param name="str2">字串</param>
        /// <returns></returns>
        public static bool isContain(string[] str1, string str2)
        {
            bool ishave = false;
            if (str1.Contains(str2))
            {
                ishave = true;
            }
            else
            {
                for (int i = 1; i < str1.Length; i++)
                {
                    if (str1[i] == null)
                    {
                        continue;
                    }
                    if (str1[i].Contains(str2))
                    {
                        ishave = true;
                        break;
                    }
                }
            }
            return ishave;
        }

        /// <summary>
        /// 重载判断字串是否在数组中
        /// </summary>
        /// <param name="str1">集合</param>
        /// <param name="str2">字串</param>
        /// <returns></returns>
        public static bool isContain(IList<string> str1, string str2)
        {
            bool ishave = false;

            if (str1.Count == 0)
            {
                ishave = false;
            }
            else
            {
                for (int i = 0; i < str1.Count; i++)
                {
                    if (str1[i] == null) { continue; }
                    if (str1[i].Contains(str2))
                    {
                        ishave = true;
                        break;
                    }
                }
            }

            return ishave;
        }
    }
}
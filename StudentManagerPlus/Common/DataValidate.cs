using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace StudentManagerPlus.Common
{
    class DataValidate
    {
        /// <summary>
        /// 判断字符串是否正整数
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public static bool IsInteger(string txt)
        {
            Regex regex = new Regex(@"^[1·9]\d*$");
            return regex.IsMatch(txt);
        }
        /// <summary>
        /// 判断是否身份证号，只是判断位数和最后一位是否符合
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public static bool IsIdNo(string txt)
        {
            Regex regex = new Regex(@"^(^\d{18}$|^\d{17}(\d|X|x))$");
            return regex.IsMatch(txt);
        }
        /// <summary>
        /// 判断是否非负浮点数
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public static bool IsNumber(string txt)
        {
            Regex regex = new Regex(@"^\d+\.?\d*$");
            return regex.IsMatch(txt);
        }
    }
}

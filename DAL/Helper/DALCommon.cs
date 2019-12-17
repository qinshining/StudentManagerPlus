using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALCommon
    {
        /// <summary>
        /// 获取服务器时间
        /// </summary>
        /// <returns></returns>
        public static DateTime GetServerTime()
        {
            string sql = "select GETDATE()";
            return Convert.ToDateTime(SqlHelper.GetSingleResult(sql));
        }
    }
}

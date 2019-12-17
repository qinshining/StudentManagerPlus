using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Models;

namespace DAL
{
    public class MenuListService
    {
        /// <summary>
        /// 获取菜单数据
        /// </summary>
        /// <returns></returns>
        public List<MenuList> GetMenuList()
        {
            string sql = "SELECT MenuId,MenuName,MenuCode,ParentId FROM MenuList";
            SqlDataReader reader = SqlHelper.GetReader(sql);
            List<MenuList> list = new List<MenuList>();
            while (reader.Read())
            {
                list.Add(new MenuList()
                {
                    MenuId = Convert.ToInt32(reader["MenuId"]),
                    MenuName = reader["MenuName"].ToString(),
                    MenuCode = reader["MenuCode"].ToString(),
                    ParentId = Convert.ToInt32(reader["ParentId"])
                });
            }
            reader.Close();
            return list;
        }
    }
}

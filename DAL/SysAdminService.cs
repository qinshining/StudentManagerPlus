using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DAL
{
    public class SysAdminService
    {
        /// <summary>
        /// 根据账号密码登录
        /// </summary>
        /// <param name="objAdmin"></param>
        /// <returns></returns>
        //public SysAdmin AdminLogin(SysAdmin objAdmin)
        //{
        //    string sql = "select AdminName from SysAdmins where LoginId = {0} and LoginPwd = '{1}'";
        //    sql = string.Format(sql, objAdmin.LoginId, objAdmin.LoginPwd);
        //    try
        //    {
        //        SqlDataReader reader = SqlHelper.GetReader(sql);
        //        if (reader.Read())
        //        {
        //            objAdmin.AdminName = reader["AdminName"].ToString();
        //        }
        //        else
        //        {
        //            objAdmin = null;
        //        }
        //        reader.Close();
        //        return objAdmin;
        //    }
        //    catch (SqlException ex)
        //    {
        //        throw new Exception("连接数据库发生异常：" + ex.Message);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        public SysAdmin AdminLogin(SysAdmin objAdmin)
        {
            string sql = "select AdminName from SysAdmins where LoginId = @LoginId and LoginPwd = @LoginPwd";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@LoginId", objAdmin.LoginId),
                new SqlParameter("@LoginPwd", objAdmin.LoginPwd)
            };
            try
            {
                SqlDataReader reader = SqlHelper.GetReader(sql, param);
                if (reader.Read())
                {
                    objAdmin.AdminName = reader["AdminName"].ToString();
                }
                else
                {
                    objAdmin = null;
                }
                reader.Close();
                return objAdmin;
            }
            catch (SqlException ex)
            {
                throw new Exception("连接数据库发生异常：" + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 修改管理员密码
        /// </summary>
        /// <param name="objAdmin"></param>
        /// <returns></returns>
        public int ModifyPwd(SysAdmin objAdmin)
        {
            string sql = "update SysAdmins set LoginPwd = '{0}' where loginid = {1}";
            sql = string.Format(sql, objAdmin.LoginPwd, objAdmin.LoginId);
            return SqlHelper.ExecuteUpdate(sql);
        }
    }
}

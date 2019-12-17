using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class StudentClassService
    {
        /// <summary>
        /// 获取班级信息集合
        /// </summary>
        /// <returns></returns>
        public List<StudentClass> GetAllClass()
        {
            string sql = "select ClassId,ClassName from StudentClass";
            SqlDataReader reader = SqlHelper.GetReader(sql);
            List<StudentClass> list = new List<StudentClass>();
            while (reader.Read())
            {
                list.Add(new StudentClass()
                {
                    ClassId = Convert.ToInt32(reader["ClassId"]),
                    ClassName = reader["ClassName"].ToString()
                });
            }
            return list;
        }
        /// <summary>
        /// 获取班级的DataSet数据集
        /// </summary>
        /// <returns></returns>
        public DataSet GetClasses()
        {
            string sql = "select ClassId,ClassName from StudentClass";
            return SqlHelper.GetDataSet(sql);
        }
    }
}

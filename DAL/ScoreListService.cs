using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class ScoreListService
    {
        /// <summary>
        /// 根据班级编号获取成绩集合
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public List<Student> GetStudentScoreList(string classId)
        {
            string sql = "select Students.StudentId,StudentName,Gender,ClassName,CSharp,SQLServerDB from Students inner join StudentClass on StudentClass.ClassId = Students.ClassId inner join ScoreList on ScoreList.StudentId = Students.StudentId";
            if (!string.IsNullOrEmpty(classId))
            {
                sql += string.Format(" where Students.ClassId = {0}", classId);
            }
            SqlDataReader reader = SqlHelper.GetReader(sql);
            List<Student> list = new List<Student>();
            while (reader.Read())
            {
                list.Add(new Student()
                {
                    StudentId = Convert.ToInt32(reader["StudentId"]),
                    StudentName = reader["StudentName"].ToString(),
                    Gender = Convert.ToInt32(reader["Gender"]),
                    ClassName = reader["ClassName"].ToString(),
                    ScoreList = new ScoreList()
                    {
                        CSharp = Convert.ToDouble(reader["CSharp"]),
                        SQLServerDB = Convert.ToDouble(reader["SQLServerDB"])
                    }
                });
            }
            reader.Close();
            return list;
        }
        /// <summary>
        /// 获取平均分、参考及缺考人数
        /// </summary>
        /// <param name="classId"></param>
        /// <returns>attendCount、absentCount、avgCSharp、avgDB</returns>
        public Dictionary<string, string> GetScoreInfo(string classId)
        {
            StringBuilder sqlBuilder = new StringBuilder();
            sqlBuilder.Append("select attendCount = SUM(case when ScoreList.StudentId is null then 0 else 1 end),avgCSharp = avg(ISNULL(CSharp,0)),avgDB = avg(ISNULL(SQLServerDB,0)) from Students left join ScoreList on ScoreList.StudentId = Students.StudentId");
            if (!string.IsNullOrEmpty(classId))
            {
                sqlBuilder.AppendFormat(" where Students.ClassId = {0}", classId);
            }
            sqlBuilder.Append(";");
            sqlBuilder.Append("select absentCount = count(1) from Students where not exists(select 1 from ScoreList where ScoreList.StudentId = Students.StudentId)");
            if (!string.IsNullOrEmpty(classId))
            {
                sqlBuilder.AppendFormat(" and Students.ClassId = {0}", classId);
            }
            SqlDataReader reader = SqlHelper.GetReader(sqlBuilder.ToString());
            Dictionary<string, string> dic = new Dictionary<string, string>();
            if (reader.Read())
            {
                dic.Add("attendCount", reader["attendCount"] == DBNull.Value ? "0" : reader["attendCount"].ToString());
                dic.Add("avgCSharp", reader["avgCSharp"] == DBNull.Value ? "0" : reader["avgCSharp"].ToString());
                dic.Add("avgDB", reader["avgDB"] == DBNull.Value ? "0" : reader["avgDB"].ToString());
            }
            if (reader.NextResult())
            {
                if (reader.Read())
                {
                    dic.Add("absentCount", reader["absentCount"] == DBNull.Value ? "0" : reader["absentCount"].ToString());
                }
            }
            reader.Close();
            return dic;
        }
        /// <summary>
        /// 查询缺考人员名单
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public List<string> GetAbsentNames(string classId)
        {
            string sql = "select StudentName from Students where not exists(select 1 from ScoreList where ScoreList.StudentId = Students.StudentId)";
            if (!string.IsNullOrEmpty(classId))
            {
                sql += string.Format(" and Students.ClassId = {0}", classId);
            }
            SqlDataReader reader = SqlHelper.GetReader(sql);
            List<string> list = new List<string>();
            while (reader.Read())
            {
                list.Add(reader["StudentName"].ToString());
            }
            reader.Close();
            return list;
        }
        /// <summary>
        /// 获取全部考试成绩数据集
        /// </summary>
        /// <returns></returns>
        public DataSet GetScoreData()
        {
            string sql = "select Students.StudentId,StudentName,GenderName = case Gender when '0' then '女' else '男' end,Students.ClassId,ClassName,CSharp,SQLServerDB,PhoneNumber from Students inner join StudentClass on StudentClass.ClassId = Students.ClassId inner join ScoreList on ScoreList.StudentId = Students.StudentId";
            return SqlHelper.GetDataSet(sql);
        }
    }
}

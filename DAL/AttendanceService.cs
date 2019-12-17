using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data.SqlClient;

namespace DAL
{
    public class AttendanceService
    {
        /// <summary>
        /// 添加打卡记录
        /// </summary>
        /// <param name="cardNo"></param>
        /// <returns></returns>
        public int AddRecord(string cardNo)
        {
            string sql = string.Format("insert into Attendance (CardNo) values ('{0}')", cardNo);
            return SqlHelper.ExecuteUpdate(sql);
        }
        /// <summary>
        /// 查询当天的考勤记录
        /// </summary>
        /// <returns></returns>
        public DataSet QueryAttendanceToday()
        {
            string sql = "select StudentId,StudentName,GenderName = case Gender when '0' then '女' else '男' end,Students.CardNo,ClassName,SignTime from Students inner join StudentClass on StudentClass.ClassId = Students.ClassId inner join Attendance on Attendance.CardNo = Students.CardNo";
            sql += " where DATEDIFF(day,SignTime, GETDATE()) = 0";
            return SqlHelper.GetDataSet(sql);
        }
        /// <summary>
        /// 根据日期查询考勤记录
        /// </summary>
        /// <returns></returns>
        public DataSet QueryAttendanceToday(DateTime dateTime)
        {
            StringBuilder sqlBuilder = new StringBuilder();
            sqlBuilder.Append("select StudentId,StudentName,GenderName = case Gender when '0' then '女' else '男' end,Students.CardNo,ClassName,SignTime from Students inner join StudentClass on StudentClass.ClassId = Students.ClassId inner join Attendance on Attendance.CardNo = Students.CardNo");
            sqlBuilder.AppendFormat(" where DATEDIFF(day,SignTime, '{0}') = 0", dateTime.ToString());
            return SqlHelper.GetDataSet(sqlBuilder.ToString());
        }
        /// <summary>
        /// 查询应到学生总数
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public int GetStudentCount()
        {
            string sql = "select count(1) from Students";
            return Convert.ToInt32(SqlHelper.GetSingleResult(sql));
        }
        /// <summary>
        /// 查询当天已签到人数
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public int GetAttendCountToday()
        {
            string sql = "select count(distinct CardNo) from Attendance where DATEDIFF(day,SignTime, GETDATE()) = 0";
            return Convert.ToInt32(SqlHelper.GetSingleResult(sql));
        }
        /// <summary>
        /// 获取考勤信息，应到和已到人数
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> GetAttendanceInfo()
        {
            StringBuilder sqlBuilder = new StringBuilder();
            sqlBuilder.Append("select count(1) totalCount from Students");
            sqlBuilder.Append(";");
            sqlBuilder.Append("select count(distinct CardNo) attendCount from Attendance where DATEDIFF(day,SignTime, GETDATE()) = 0");
            SqlDataReader reader = SqlHelper.GetReader(sqlBuilder.ToString());
            Dictionary<string, string> dic = new Dictionary<string, string>();
            if (reader.Read())
            {
                dic.Add("totalCount", reader["totalCount"].ToString());
            }
            if (reader.NextResult())
            {
                if (reader.Read())
                {
                    dic.Add("attendCount", reader["attendCount"].ToString());
                }
            }
            reader.Close();
            return dic;
        }
        /// <summary>
        /// 根据日期获取考勤信息，应到和已到人数
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> GetAttendanceInfo(DateTime dateTime)
        {
            StringBuilder sqlBuilder = new StringBuilder();
            sqlBuilder.Append("select count(1) totalCount from Students");
            sqlBuilder.Append(";");
            sqlBuilder.AppendFormat("select count(distinct CardNo) attendCount from Attendance where DATEDIFF(day,SignTime, '{0}') = 0", dateTime);
            SqlDataReader reader = SqlHelper.GetReader(sqlBuilder.ToString());
            Dictionary<string, string> dic = new Dictionary<string, string>();
            if (reader.Read())
            {
                dic.Add("totalCount", reader["totalCount"].ToString());
            }
            if (reader.NextResult())
            {
                if (reader.Read())
                {
                    dic.Add("attendCount", reader["attendCount"].ToString());
                }
            }
            reader.Close();
            return dic;
        }
    }
}

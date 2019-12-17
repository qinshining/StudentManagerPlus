using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data.SqlClient;

namespace DAL
{
    /// <summary>
    /// 学员操作类
    /// </summary>
    public class StudentService
    {
        #region 添加学员

        /// <summary>
        /// 添加学员
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public int AddStudent(Student student)
        {
            string sql = "insert into Students (StudentName,Gender,Birthday,Age,StudentIdNo,CardNo,StuImage,PhoneNumber,StudentAddress,ClassId) values ('{0}','{1}','{2}',{3},'{4}','{5}','{6}','{7}','{8}',{9});select @@IDENTITY";
            sql = string.Format(sql, student.StudentName, student.Gender, student.Birthday.ToString("yyyy-MM-dd"), student.Age, student.StudentIdNo, student.CardNo, student.StuImage, student.PhoneNumber, student.StudentAddress, student.ClassId);
            try
            {
                int result = Convert.ToInt32(SqlHelper.GetSingleResult(sql));
                return result;
            }
            catch (SqlException ex)
            {
                throw new Exception("数据库发生异常：" + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region 查询学员
        /// <summary>
        /// 根据where条件查询学员集合
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        private List<Student> GetStudents(string sqlWhere)
        {
            StringBuilder sqlBuilder = new StringBuilder();
            sqlBuilder.Append("select StudentId,StudentName,Gender,Birthday,Age,StudentIdNo,CardNo,StuImage,PhoneNumber,StudentAddress,Students.ClassId,ClassName");
            sqlBuilder.Append(" from Students inner join StudentClass on StudentClass.ClassId = Students.ClassId");
            if (!string.IsNullOrEmpty(sqlWhere))
            {
                sqlBuilder.Append(sqlWhere);
            }
            SqlDataReader reader = SqlHelper.GetReader(sqlBuilder.ToString());
            List<Student> list = new List<Student>();
            while (reader.Read())
            {
                list.Add(new Student()
                {
                    StudentId = Convert.ToInt32(reader["StudentId"]),
                    StudentName = reader["StudentName"].ToString(),
                    Gender = Convert.ToInt32(reader["Gender"]),
                    Birthday = Convert.ToDateTime(reader["Birthday"]),
                    Age = Convert.ToInt32(reader["Age"]),
                    StudentIdNo = reader["StudentIdNo"].ToString(),
                    CardNo = reader["CardNo"].ToString(),
                    StuImage = reader["StuImage"].ToString(),
                    PhoneNumber = reader["PhoneNumber"].ToString(),
                    StudentAddress = reader["StudentAddress"].ToString(),
                    ClassId = Convert.ToInt32(reader["ClassId"]),
                    ClassName = reader["ClassName"].ToString()
                });
            }
            reader.Close();
            return list;
        }
        /// <summary>
        /// 根据班级编号查询学员
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public List<Student> GetStudentsByClassId(string classId)
        {
            string sqlWhere = string.IsNullOrEmpty(classId) ? string.Empty : string.Format(" where Students.ClassId = {0}", classId);
            return GetStudents(sqlWhere);
        }
        /// <summary>
        /// 根据学号查询学员对象
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public List<Student> GetStudentsById(string studentId)
        {
            string sqlWhere = string.IsNullOrEmpty(studentId) ? string.Empty : string.Format(" where Students.StudentId like '{0}%'", studentId);
            return GetStudents(sqlWhere);
        }
        /// <summary>
        /// 根据卡号查询学员
        /// </summary>
        /// <param name="cardNo"></param>
        /// <returns></returns>
        public Student GetStudentByCardNo(string cardNo)
        {
            StringBuilder sqlBuilder = new StringBuilder();
            sqlBuilder.Append("select StudentId,StudentName,Gender,StuImage,Students.CardNo,ClassName from Students inner join StudentClass on StudentClass.ClassId = Students.ClassId");
            sqlBuilder.AppendFormat(" where Students.CardNo = '{0}'", cardNo);
            SqlDataReader reader = SqlHelper.GetReader(sqlBuilder.ToString());
            Student student = null;
            if (reader.Read())
            {
                student = new Student()
                {
                    StudentId = Convert.ToInt32(reader["StudentId"]),
                    StudentName = reader["StudentName"].ToString(),
                    Gender = Convert.ToInt32(reader["Gender"]),
                    StuImage = reader["StuImage"].ToString(),
                    CardNo = reader["CardNo"].ToString(),
                    ClassName = reader["ClassName"].ToString(),
                };
            }
            return student;
        }

        #endregion

        #region 修改学员
        /// <summary>
        /// 修改学员信息
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public int ModifyStudent(Student student)
        {
            string sql = "update Students set StudentName = '{0}',Gender = '{1}',Birthday = '{2}',Age = {3},StudentIdNo = '{4}',CardNo = '{5}',StuImage = '{6}',PhoneNumber = '{7}',StudentAddress = '{8}',ClassId = {9} where StudentId = {10}";
            sql = string.Format(sql, student.StudentName, student.Gender, student.Birthday.ToString("yyyy-MM-dd"), student.Age, student.StudentIdNo, student.CardNo, student.StuImage, student.PhoneNumber, student.StudentAddress, student.ClassId, student.StudentId);
            try
            {
                return SqlHelper.ExecuteUpdate(sql);
            }
            catch (SqlException ex)
            {
                throw new Exception("数据库操作发生异常，请稍后再试：" + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 删除学员
        /// <summary>
        /// 删除学员信息
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public int DeleteStudent(Student student)
        {
            string sql = string.Format("delete from Students where StudentId = {0}", student.StudentId);
            try
            {
                return SqlHelper.ExecuteUpdate(sql);
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547)
                {
                    throw new Exception("该对象被其他对象引用，不能直接删除：" + ex.Message);
                }
                else
                {
                    throw new Exception("数据库操作发生异常，请稍后再试：" + ex.Message);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 数据校验

        /// <summary>
        /// 判断身份证号是否重复
        /// </summary>
        /// <param name="studentIdNo"></param>
        /// <returns></returns>
        public bool IsIdNoExists(string studentIdNo)
        {
            string sql = string.Format("select count(1) from Students where StudentIdNo = '{0}'", studentIdNo);
            return Convert.ToInt32(SqlHelper.GetSingleResult(sql)) > 0 ? true : false;
        }
        /// <summary>
        /// 判断修改后的身份证号是否重复
        /// </summary>
        /// <param name="studentIdNo"></param>
        /// <returns></returns>
        public bool IsIdNoExists(string studentIdNo, string studentId)
        {
            string sql = string.Format("select count(1) from Students where StudentIdNo = '{0}' and StudentId <> {1}", studentIdNo, studentId);
            return Convert.ToInt32(SqlHelper.GetSingleResult(sql)) > 0 ? true : false;
        }
        // <summary>
        /// 判断考勤号是否重复
        /// </summary>
        /// <param name="studentIdNo"></param>
        /// <returns></returns>
        public bool IsCardNoExists(string cardNo)
        {
            string sql = string.Format("select count(1) from Students where CardNo = '{0}'", cardNo);
            return Convert.ToInt32(SqlHelper.GetSingleResult(sql)) > 0 ? true : false;
        }
        // <summary>
        /// 判断修改后的考勤号是否重复
        /// </summary>
        /// <param name="studentIdNo"></param>
        /// <returns></returns>
        public bool IsCardNoExists(string cardNo, string studentId)
        {
            string sql = string.Format("select count(1) from Students where CardNo = '{0}' and StudentId <> {1}", cardNo, studentId);
            return Convert.ToInt32(SqlHelper.GetSingleResult(sql)) > 0 ? true : false;
        }

        #endregion
    }
}

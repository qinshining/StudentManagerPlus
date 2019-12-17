using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data;

namespace DAL
{
    public class ImportDataFromExcel
    {
        /// <summary>
        /// 从Excel中读取学生信息
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public List<Student> GetStudentsByExcle(string fileName)
        {
            string sql = "select * from [Student$]";
            try
            {
                DataSet ds = OleDBHelper.GetDataSet(sql, fileName);
                List<Student> list = new List<Student>();
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    list.Add(new Student()
                    {
                        StudentName = row["姓名"].ToString(),
                        Gender = row["性别"].ToString().Equals("男") ? 1 : 0,
                        Birthday = Convert.ToDateTime(row["出生日期"]),
                        StudentIdNo = row["身份证号"].ToString(),
                        CardNo = row["考勤卡号"].ToString(),
                        PhoneNumber = row["电话号码"].ToString(),
                        StudentAddress = row["家庭住址"].ToString(),
                        ClassId = Convert.ToInt32(row["班级编号"])
                    });
                }
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("读取excel过程中出现错误，请检查excel格式是否正确：" + ex.Message);
            }
        }
        /// <summary>
        /// 导入学员数据
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool ImportData(List<Student> list)
        {
            StringBuilder sqlBuilder = new StringBuilder();
            sqlBuilder.Append("insert into Students (StudentName,Gender,Birthday,Age,StudentIdNo,CardNo,PhoneNumber,StudentAddress,ClassId) values ('{0}','{1}','{2}',{3},'{4}','{5}','{6}','{7}',{8});");
            List<string> sqls = new List<string>();
            foreach (Student student in list)
            {
                string sql = string.Format(sqlBuilder.ToString(), student.StudentName, student.Gender, student.Birthday.ToString("yyyy-MM-dd"), student.Age, student.StudentIdNo, student.CardNo, student.PhoneNumber, student.StudentAddress, student.ClassId);
                sqls.Add(sql);
            }
            return SqlHelper.ExecuteTran(sqls);
        }
    }
}

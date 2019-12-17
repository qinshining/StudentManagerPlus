using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace StudentManagerPlus.ExcelPrint
{
    class ExcelPrint
    {
        /// <summary>
        /// 基于Excel模板打印学员
        /// </summary>
        /// <param name="student"></param>
        public void PrintStudent(Student student)
        {
            //【1】定义Excel工作簿对象
            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            //【2】获取已创建号的工作薄模板路径
            string excelTemplate = Environment.CurrentDirectory + "\\StudentInfo.xls";
            //【3】将模板中的内容加载到Excel工作薄对象中
            excelApp.Workbooks.Add(excelTemplate);
            //【4】获取第一个工作表
            Microsoft.Office.Interop.Excel.Worksheet sheet = excelApp.Worksheets[1];
            //【5】在当前Excel对象中写入数据
            if (student.StuImage.Length != 0)
            {
                Image image = (Image)new Common.SerializeObjectToString().DeserializeObject(student.StuImage);
                string imagePath = string.Format(Environment.CurrentDirectory + "\\{0}.jpg", Guid.NewGuid().ToString());
                if (File.Exists(imagePath))
                {
                    File.Delete(imagePath);
                }
                else
                {
                    image.Save(imagePath);
                    sheet.Shapes.AddPicture(imagePath, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoTrue, 10, 50, 90, 100);//将图片保存到工作表中
                    File.Delete(imagePath);
                }
            }
            //写入其他数据
            sheet.Cells[4, 4] = student.StudentId;
            sheet.Cells[4, 6] = student.StudentName;
            sheet.Cells[4, 8] = student.GenderName;
            sheet.Cells[6, 4] = student.ClassName;
            sheet.Cells[6, 6] = student.PhoneNumber;
            sheet.Cells[8, 4] = student.StudentAddress;
            sheet.Cells[14, 1] = "此处可填写备注信息";
            //【6】打印预览
            excelApp.Visible = true;
            excelApp.Sheets.PrintPreview(true);
            //【7】释放对象
            excelApp.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
            excelApp = null;            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagerPlus.ExcelPrint
{
    class DataExport
    {
        /// <summary>
        /// 导出数据
        /// </summary>
        /// <param name="dgv">dgv控件</param>
        /// <param name="title">导出excel的标题名称</param>
        public void ExportData(DataGridView dgv, string title)
        {
            //定义Excel工作薄对象
            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            //定义Excel工作表对象
            Microsoft.Office.Interop.Excel.Worksheet sheet = excelApp.Workbooks.Add().Worksheets[1];
            //设置标题样式（从第2行，第2列开始）
            sheet.Cells[2, 2] = title;//设置标题内容
            sheet.Cells[2, 2].RowHeight = 30;
            Microsoft.Office.Interop.Excel.Range range = sheet.get_Range("B2", "H2");//为什么get_Range点不出来？H2可以根据列数动态修改
            range.Merge(0);
            range.Borders.Value = 1;//设置表头边框
            range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;//设置单元格居中显示
            range.Font.Size = 15;
            //获取dgv总行数和总列数
            int rowCount = dgv.RowCount;
            int columnCount = dgv.ColumnCount;
            //设置列标题
            for (int i = 0; i < columnCount; i++)
            {
                //从第3行，第2列开始
                sheet.Cells[3, i + 2] = dgv.Columns[i].HeaderText;
                sheet.Cells[3, i + 2].Borders.Value = 1;
                sheet.Cells[3, i + 2].RowHeight = 25;
            }
            //显示数据
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < columnCount; j++)
                {
                    //从第4行，第2列开始
                    sheet.Cells[i + 4, j + 2] = dgv.Rows[i].Cells[j].Value;
                    sheet.Cells[i + 4, j + 2].Borders.Value = 1;
                    sheet.Cells[i + 4, j + 2].RowHeight = 25;
                }
            }
            sheet.Columns.AutoFit();//设置列宽和数据一致
            //打印预览
            excelApp.Visible = true;
            excelApp.Sheets.PrintPreview(true);//true参数可以不用
            //释放对象
            excelApp.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
            excelApp = null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Net;
using System.Windows.Forms;

namespace UpdateApp
{
    public class UpdateManager
    {
        //XML文件名
        private string xmlName = "UpdateList.xml";
        /// <summary>
        /// 用于反馈下载进度的事件
        /// </summary>
        public event Action<int, int> ReportProcess;
        public UpdateInfo LastUpdateInfo { get; set; }
        public UpdateInfo NewUpdateInfo { get; set; }
        /// <summary>
        /// 当前程序是否最新
        /// </summary>
        public bool IsNewest
        {
            get
            {
                return LastUpdateInfo.UpdateTime >= NewUpdateInfo.UpdateTime;
            }
        }
        /// <summary>
        /// 获取临时文件夹
        /// </summary>
        public string TempFilePath
        {
            get
            {
                string tempPath = Environment.GetEnvironmentVariable("Temp") + "/EderSoft.UpdateFiles";
                if (!Directory.Exists(tempPath))
                {
                    Directory.CreateDirectory(tempPath);
                }
                return tempPath;
            }
        }
        public UpdateManager()
        {
            this.LastUpdateInfo = new UpdateInfo();
            this.NewUpdateInfo = new UpdateInfo();
            this.GetLastUpdateInfo();
            this.GetNewUpdateInfo();
        }

        private void GetLastUpdateInfo()
        {
            XmlReader xmlReader = XmlReader.Create(xmlName);
            while (xmlReader.Read())
            {
                switch (xmlReader.Name)
                {
                    case "URLAddress":
                        this.LastUpdateInfo.URLAddress = xmlReader.GetAttribute("URL");
                        break;
                    case "UpdateTime":
                        this.LastUpdateInfo.UpdateTime = Convert.ToDateTime(xmlReader.GetAttribute("Date"));
                        break;
                    case "Version":
                        this.LastUpdateInfo.Version = xmlReader.GetAttribute("Num");
                        break;
                    default:
                        break;
                }
            }
            xmlReader.Close();
        }

        private void GetNewUpdateInfo()
        {
            string url = this.LastUpdateInfo.URLAddress + xmlName;
            string fileName = this.TempFilePath + "/" + xmlName;
            WebClient client = new WebClient();
            client.DownloadFile(url, fileName);
            XmlReader xmlReader = XmlReader.Create(fileName);
            while (xmlReader.Read())
            {
                switch (xmlReader.Name)
                {
                    case "UpdateTime":
                        this.NewUpdateInfo.UpdateTime = Convert.ToDateTime(xmlReader.GetAttribute("Date"));
                        break;
                    case "Version":
                        this.NewUpdateInfo.Version = xmlReader.GetAttribute("Num");
                        break;
                    case "UpdateFile":
                        this.NewUpdateInfo.FileList.Add(new string[] {
                            xmlReader.GetAttribute("FileName"),
                            xmlReader.GetAttribute("ContentLength"),
                            xmlReader.GetAttribute("Ver")
                        });
                        break;
                    default:
                        break;
                }
            }
            xmlReader.Close();
        }
        /// <summary>
        /// 下载更新文件
        /// </summary>
        public void DownloadFile()
        {
            if (this.IsNewest)
            {
                return;
            }
            for (int i = 0; i < this.NewUpdateInfo.FileList.Count; i++)
            {
                string fileName = this.NewUpdateInfo.FileList[i][0];
                WebRequest request = WebRequest.Create(this.LastUpdateInfo.URLAddress + fileName);
                WebResponse response = request.GetResponse();
                Stream stream = response.GetResponseStream();
                long fileLength = response.ContentLength;
                byte[] fileByte = new byte[fileLength];
                int startIndex = 0;
                int count = fileByte.Length;
                while (fileLength > 0)
                {
                    Application.DoEvents();
                    int downloadSize = stream.Read(fileByte, startIndex, count);
                    if (downloadSize == 0)
                    {
                        break;
                    }
                    startIndex += downloadSize;
                    count -= downloadSize;
                    float downloaded = (float)startIndex / 1024;
                    float fileSize = (float)fileLength / 1024;
                    int percent = Convert.ToInt32(downloaded / fileSize * 100);
                    ReportProcess(i, percent);
                }
                stream.Close();
                FileStream fs = new FileStream(this.TempFilePath + "/" + fileName, FileMode.Create, FileAccess.Write);
                fs.Write(fileByte, 0, fileByte.Length);
                fs.Close();
            }
        }

        public void CopyFile()
        {
            bool isDeleted = false;
            try
            {
                foreach (var item in this.NewUpdateInfo.FileList)
                {
                    string fileName = item[0];
                    string tempPath = this.TempFilePath + "/" + fileName;
                    if (File.Exists(fileName))
                    {
                        File.Delete(fileName);
                    }
                    File.Copy(tempPath, fileName);
                }
                //更新xml文件                
                if (File.Exists(xmlName))
                {
                    File.Delete(xmlName);
                }
                File.Copy(this.TempFilePath + "/" + xmlName, xmlName);
                isDeleted = true;
            }
            catch (Exception ex)
            {
                isDeleted = false;
                throw ex;
            }
            finally
            {
                if (isDeleted)
                {
                    foreach (var item in this.NewUpdateInfo.FileList)
                    {
                        string fileName = item[0];
                        string tempPath = this.TempFilePath + "/" + fileName;
                        if (File.Exists(tempPath))
                        {
                            File.Delete(tempPath);
                        }
                    }
                    if (File.Exists(xmlName))
                    {
                        File.Delete(this.TempFilePath + "/" + xmlName);
                    }
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpdateApp
{
    /// <summary>
    /// 更新信息类
    /// </summary>
    public class UpdateInfo
    {
        /// <summary>
        /// 服务器地址
        /// </summary>
        public string URLAddress { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdateTime { get; set; }
        /// <summary>
        /// 版本号
        /// </summary>
        public string Version { get; set; }
        /// <summary>
        /// 文件列表，包含文件名、版本号、文件大小等
        /// </summary>
        public List<string[]> FileList { get; set; } = new List<string[]>();
    }
}

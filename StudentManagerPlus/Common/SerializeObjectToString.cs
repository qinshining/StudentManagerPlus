using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace StudentManagerPlus.Common
{
    class SerializeObjectToString
    {
        #region 文件流序列化
        public void SaveSerializationFile(string fileName, object obj)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, obj);
            fs.Close();
        }
        public object DeserializeFile(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            object obj = bf.Deserialize(fs);
            fs.Close();
            return obj;
        }
        #endregion

        #region 内存流序列化
        /// <summary>
        /// 将对象序列化
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public string SerializeObject(object obj)
        {
            IFormatter formatter = new BinaryFormatter();
            string result = string.Empty;
            using (MemoryStream stream = new MemoryStream())
            {
                formatter.Serialize(stream, obj);
                byte[] byt = new byte[stream.Length];
                byt = stream.ToArray();
                result = Convert.ToBase64String(byt);
                stream.Flush();
            }
            return result;
        }
        /// <summary>
        /// 将字符串反序列化成对象
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public object DeserializeObject(string str)
        {
            IFormatter formatter = new BinaryFormatter();
            byte[] byt = Convert.FromBase64String(str);
            object obj = null;
            using (MemoryStream stream = new MemoryStream(byt, 0, byt.Length))
            {
                obj = formatter.Deserialize(stream);
            }
            return obj;
        }
        #endregion
    }
}

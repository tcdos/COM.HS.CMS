using System;
using System.IO;
using System.Xml.Serialization;

namespace ZS.KIT
{
    public class znResialization
    {

        public znResialization()
        { }

        /// <summary>
        /// 反序列化
        /// </summary>
        public static object Load(Type type, string fileUrl)
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream(fileUrl, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                XmlSerializer serializer = new XmlSerializer(type);
                return serializer.Deserialize(fs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (fs != null)
                    fs.Close();
            }
        }

        /// <summary>
        /// 序列化
        /// </summary>
        public static void Save(object obj, string fileUrl)
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream(fileUrl, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
                XmlSerializer serializer = new XmlSerializer(obj.GetType());
                serializer.Serialize(fs, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (fs != null)
                    fs.Close();
            }
        }
    }
}

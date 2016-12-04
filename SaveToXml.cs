using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace MVVMJSON
{
    class SaveToXml
    {
        public static void SaveData(object obj, string filename)
        {

            // convert string to stream
            byte[] byteArray = Encoding.UTF8.GetBytes(filename);
            //byte[] byteArray = Encoding.ASCII.GetBytes(contents);
            MemoryStream stream = new MemoryStream(byteArray);

            StreamReader reader = new StreamReader(stream);
            string text = reader.ReadToEnd();

            XmlSerializer sr = new XmlSerializer(obj.GetType());
           // TextWriter writer = new StreamWriter(filename);
            sr.Serialize(stream, obj);
        }
    }
}

using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ColladaNET
{
    public partial class Collada
    {

        private static System.Xml.Serialization.XmlSerializer serializer;
        private static System.Xml.Serialization.XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                { serializer = new System.Xml.Serialization.XmlSerializer(typeof(Collada)); }
                return serializer;
            }
        }


        /// <summary>
        /// Serializes given COLLADA object into an XML document
        /// </summary>
        /// <returns>string XML value</returns>
        public static string Serialize(Collada obj, System.Text.Encoding encoding)
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
                xmlWriterSettings.Encoding = encoding;
                // settings for human readability!!
                xmlWriterSettings.Indent = true;
                // xmlWriterSettings.NewLineOnAttributes = true;
                xmlWriterSettings.NewLineChars = Environment.NewLine;
                xmlWriterSettings.NewLineHandling = NewLineHandling.Replace;
                // settings end

                System.Xml.XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
                Serializer.Serialize(xmlWriter, obj);
                memoryStream.Seek(0, System.IO.SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }


        public static string Serialize(Collada obj)
        {
            return Serialize(obj, Encoding.UTF8);
        }

        /// <summary>
        /// Serializes current COLLADA object into an XML document
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize(System.Text.Encoding encoding)
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
                xmlWriterSettings.Encoding = encoding;

                System.Xml.XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
                Serializer.Serialize(xmlWriter, this);
                memoryStream.Seek(0, System.IO.SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        public virtual string Serialize()
        {
            return Serialize(Encoding.UTF8);
        }

        /// <summary>
        /// Deserializes workflow markup into an COLLADA object
        /// </summary>
        /// <param name="xmlStream">stream with xml markup content to deserialize</param>
        /// <param name="obj">Output COLLADA object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this XmlSerializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(Stream xmlStream, out Collada obj, out System.Exception exception)
        {
            exception = null;
            obj = default(Collada);
            try
            {
                obj = Deserialize(xmlStream);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(Stream xmlStream, out Collada obj)
        {
            System.Exception exception = null;
            return Deserialize(xmlStream, out obj, out exception);
        }

        public static Collada Deserialize(Stream xmlStream)
        {
            try
            {
                return ((Collada)(Serializer.Deserialize(xmlStream)));
            }
            finally
            {
                if ((xmlStream != null))
                {
                    xmlStream.Dispose();
                }
            }
        }

        /// <summary>
        /// Serializes current COLLADA object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, System.Text.Encoding encoding, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName, encoding);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            return SaveToFile(fileName, Encoding.UTF8, out exception);
        }

        public virtual void SaveToFile(string fileName)
        {
            SaveToFile(fileName, Encoding.UTF8);
        }

        public virtual void SaveToFile(string fileName, System.Text.Encoding encoding)
        {
            System.IO.StreamWriter streamWriter = null;
            try
            {
                string xmlString = Serialize(encoding);
                streamWriter = new System.IO.StreamWriter(fileName, false, Encoding.UTF8);
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        public static void SaveToFile(Collada obj, string fileName)
        {
            SaveToFile(obj, fileName, Encoding.UTF8);
        }

        public static void SaveToFile(Collada obj, string fileName, System.Text.Encoding encoding)
        {
            System.IO.StreamWriter streamWriter = null;
            try
            {
                string xmlString = Serialize(obj, encoding);
                streamWriter = new System.IO.StreamWriter(fileName, false, Encoding.UTF8);
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes xml markup from file into an COLLADA object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output COLLADA object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this XmlSerializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out Collada obj, out System.Exception exception)
        {
            exception = null;
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                obj = default(Collada);
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out Collada obj)
        {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static Collada LoadFromFile(string fileName)
        {
            try
            {
                Collada result = null;
                using (FileStream fs = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read))
                {
                    result = Deserialize(fs);
                }
                return result;
            }
            finally
            { }
        }

        public static async Task<Collada> LoadFromFileAsync(string fileName)
        {
            return await Task.Run<Collada>(() => { return Collada.LoadFromFile(fileName); });
        }

    }

}
using System;
using System.ComponentModel;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Xml.Serialization;

namespace _2ndLabComponents
{
    public partial class XmlBackuperKozlov : Component
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public XmlBackuperKozlov()
        {
            InitializeComponent();
        }

        public XmlBackuperKozlov(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }

        /// <summary>
        /// Создание бэкапа из объекта
        /// </summary>
        /// <param name="obj"> Объект, из которого создаётся бэкап </param>
        /// <param name="folderName"> Папка, в которой создаётся бэкап </param>
        public void MakeBackup(object obj, string folderName)
        {
            var attrs = obj.GetType().GetCustomAttributes();
            bool isSerializable = false;

            foreach (var attr in attrs)
            {
                if (attr is SerializableAttribute)
                {
                    isSerializable = true;
                    break;
                }
            }

            if (isSerializable)
            {
                try
                {
                    DirectoryInfo dirInfo = new DirectoryInfo(folderName);

                    if (dirInfo.Exists)
                    {
                        foreach (FileInfo file in dirInfo.GetFiles())
                        {
                            file.Delete();
                        }
                    }
                    else
                    {
                        dirInfo.Create();
                    }

                    string fileName = $"{folderName}.zip";

                    if (File.Exists(fileName))
                    {
                        File.Delete(fileName);
                    }

                    XmlSerializer formatter = new XmlSerializer(obj.GetType());

                    using (FileStream fs = new FileStream($"{folderName}/{obj.GetType().Name}.xml", FileMode.OpenOrCreate))
                    {
                        formatter.Serialize(fs, obj);
                    }

                    ZipFile.CreateFromDirectory(folderName, fileName);

                    dirInfo.Delete(true);
                }
                catch
                {
                    throw;
                }
            }
        }
    }
}

using Assets.Code.Interface;
using Lab;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Assets.Code.Cotrollers.SaveDataRepositiory
{
    class XmlDataSerializer<T> : IData<T>
    {
        private XmlSerializer _serializer;

        public XmlDataSerializer()
        {
            _serializer = new XmlSerializer(typeof(T));
        }
        public void Load(ref T data, string path = null)
        {
            if (string.IsNullOrEmpty(path) || !File.Exists(path))
                throw new GameException(
                    "XmlDataqSerializer.Load: file not found. ");

            using (FileStream stream = new FileStream(
                path, FileMode.Open, FileAccess.Read))
            {
                data = (T)_serializer.Deserialize(stream);
            }
        }

        public void Save(T data, string path = null)
        {
            if (null == data)
                return;

            if (string.IsNullOrEmpty(path))
                throw new GameException("XmlDataSerializer.Save");


            using (FileStream stream = new FileStream(
                path, FileMode.OpenOrCreate, FileAccess.Write))
            {
                _serializer.Serialize(stream, data);
            }
        }
    }
}

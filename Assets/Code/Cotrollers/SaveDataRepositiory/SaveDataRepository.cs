using Assets.Code.Interface;
using Lab;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Code.Cotrollers.SaveDataRepositiory
{
    public sealed class SaveDataRepository<T>
    {
        private const string _folderName = "SavedDataFolder";
        private const string _fileName = "data.bat";

        IData<T> _dataSaver;
        private readonly string _path;

        public SaveDataRepository()
        {
            //_dataSaver = new JsonDataSerializer<T>();
            _dataSaver = new XmlDataSerializer<T>();

            _path = Path.Combine(
                Directory.GetCurrentDirectory(), _folderName);
        }

        public void Save(T data)
        {
            if (!Directory.Exists(_path))
                Directory.CreateDirectory(_path);

            _dataSaver.Save(data, Path.Combine(_path, _fileName));
            
        }

        public void Load(ref T data)
        {
            if (!Directory.Exists(_path))
                return;

            _dataSaver.Load(ref data, Path.Combine(_path, _fileName));
        }
    }
}

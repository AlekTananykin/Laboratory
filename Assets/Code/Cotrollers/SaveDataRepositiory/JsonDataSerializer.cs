using Assets.Code.Interface;
using Lab;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Code.Cotrollers.SaveDataRepositiory
{
    public class JsonDataSerializer<T> : IData<T>
    {
        public void Load(ref T data, string path = null)
        {
            if (null == path || !File.Exists(path))
                throw new GameException(
                    "JsonDataSaver.Load: Path to load is not correct. ");

            string json = File.ReadAllText(path);
            JsonUtility.FromJsonOverwrite(json, data);
        }

        public void Save(T data, string path = null)
        {
            if (string.IsNullOrEmpty(path))
                throw new GameException(
                    "JsonDataSaver.Save: Path to save is not correct. ");

            string str = JsonUtility.ToJson(data, true);
            File.WriteAllText(path, str);
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Code.Interface
{
    interface IData<T>
    {
        void Save(T data, string path = null);
        void Load(ref T data, string path = null);
    }
}

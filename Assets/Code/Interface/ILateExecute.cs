using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    interface ILateExecute: IController
    {
        void LateExecute(float deltaTime);
    }
}

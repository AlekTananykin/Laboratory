using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    interface ILateExecute : IInteractionObject
    {
        void LateExecute(float deltaTime);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    public interface IInteractionStorage
    {
        void Add(IInteractionObject item);
        void Remove(IInteractionObject item);
    }
}

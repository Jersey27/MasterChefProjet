using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterChefResto.model
{
    public interface ObserverWaiter
    {
         void Update(Command command);
    }
}

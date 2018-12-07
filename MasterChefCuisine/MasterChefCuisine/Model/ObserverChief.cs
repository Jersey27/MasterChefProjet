using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterChefCuisine.Model
{
    public interface ObserverChief
    {
        void update(int IdRecipe);
    }
}

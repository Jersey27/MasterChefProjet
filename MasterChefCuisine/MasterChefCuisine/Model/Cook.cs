using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterChefCuisine.Model
{
    public class Cook : Preparator, ICook
    {

        void ICook.Cook(Recipe recipe)
        {
            throw new NotImplementedException();
        }
    }
}

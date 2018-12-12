using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterChefResto.model
{
    class Command
    {
        public int CustomerIdForCommand { get; set; }
        private string Starter { get; set; }
        private string MainCourse { get; set; }
        private string Dessert { get; set; }
    }

    
}

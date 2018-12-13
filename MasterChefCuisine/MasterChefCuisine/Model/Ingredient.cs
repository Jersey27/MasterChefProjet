using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MasterChefCuisine.Model
{
    public class Ingredient : IDisposable
    {
        private bool disposed = false;
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);
        public string NomIngredient { get; set; }
        public string typeIngredient { get; set; }
        public int quantityIngredient { get; set; }
        public bool canBePrepared { get; set; }
        public DateTime datePeremption { get; set; }

        public void Dispose()
        {
            if(quantityIngredient == 0)
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
            else
            {
                quantityIngredient--;
            }
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;
            if(disposing)
            {
                handle.Dispose();
            }
            disposed = true;
        }
    }
}

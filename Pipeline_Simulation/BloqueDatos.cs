using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pipeline_Simulation
{
    public class BloqueDatos
    {
        public int[] datos;

        public BloqueDatos(int dato0, int dato1, int dato2, int dato3)
        {
            this.datos = new int[4];
        }
    }
}

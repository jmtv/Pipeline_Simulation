using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pipeline_Simulation
{
    public class CacheInstrucciones
    {
        public BloqueInstrucciones[] bloqueInstrucciones;
        public int[] etiquetas;

        public CacheInstrucciones()
        {
            bloqueInstrucciones = new BloqueInstrucciones[4];
            etiquetas = new int[4];
        }

        public bool IngresarBloqueDatos(BloqueInstrucciones bloqueInstrucciones, int etiqueta)
        {

            this.bloqueInstrucciones[etiqueta % 4] = bloqueInstrucciones;
            this.etiquetas[etiqueta % 4] = etiqueta;

            return true;

        }
    }
}

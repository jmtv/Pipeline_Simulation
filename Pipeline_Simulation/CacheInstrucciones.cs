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

        public bool IngresarBloqueInstrucciones(BloqueInstrucciones bloqueInstrucciones, int etiqueta)
        {

            this.bloqueInstrucciones[etiqueta % 4] = bloqueInstrucciones;
            this.etiquetas[etiqueta % 4] = etiqueta;

            return true;

        }

        public BloqueInstrucciones BuscarInstruccion(int pc)
        {
            int numeroBloque = pc / 16;
            for (int i = 0; i < 4; i++)
            {
                if (etiquetas[i] == numeroBloque)
                {
                    return bloqueInstrucciones[i];
                }
            }

            return null;
        }
    }
}

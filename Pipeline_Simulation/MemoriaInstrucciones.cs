using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pipeline_Simulation
{
    public class MemoriaInstrucciones
    {
        public BloqueInstrucciones[] bloqueInstruccioneses;

        public MemoriaInstrucciones()
        {
            bloqueInstruccioneses = new BloqueInstrucciones[40];
        }
    }
}

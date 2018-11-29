using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pipeline_Simulation
{
    public class CacheDatos
    {
        public BloqueDatos[] bloqueDatos;
        public int[] etiquetas;
        public Estado[] estados;

        public CacheDatos()
        {
            bloqueDatos = new BloqueDatos[4];
            etiquetas = new int[4];
            estados = new Estado[4];
        }

        public bool IngresarBloqueDatos(BloqueDatos bloqueDatos, int etiqueta)
        {
            if (estados[etiqueta % 4] != Estado.Compartido)
            {
                return false;
            }

            this.bloqueDatos[etiqueta % 4] = bloqueDatos;
            this.etiquetas[etiqueta % 4] = etiqueta;
            this.estados[etiqueta % 4] = Estado.Compartido;

            return true;

        }


    }
}

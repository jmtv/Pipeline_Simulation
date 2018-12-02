using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pipeline_Simulation
{
    public class Main
    {
        public MemoriaDatos memoriaDatos = new MemoriaDatos();
        public MemoriaInstrucciones memoriaInstrucciones = new MemoriaInstrucciones();

        //Mutex para acceso a las estructuras intermedias 
        private Mutex mut_if_id = new Mutex();
        private Mutex mut_id_ex = new Mutex();
        private Mutex mut_ex_mem = new Mutex();
        private Mutex mut_mem_wb = new Mutex();

        //Lee los archivos de los hilillos y carga los datos a la memoria de instrucciones
        public void LeeHilillos()
        {
            int posicionMemoria = 0;
            for (int i = 0; i < 7; i++)
            {   
                string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Roy\Desktop\hilillos\" + i + ".txt");
                BloqueInstrucciones bloqueInstrucciones = new BloqueInstrucciones();
                for (int j = 0; j < lines.Length; j++)
                {
                    var line = lines[j];
                    string[] lineaSplit = line.Split(' ');
                    int lineaInt;
                    Instruccion instruccion = new Instruccion();


                    int.TryParse(lineaSplit[0], out lineaInt);
                    instruccion.ins0 = lineaInt;

                    int.TryParse(lineaSplit[1], out lineaInt);
                    instruccion.ins1 = lineaInt;

                    int.TryParse(lineaSplit[2], out lineaInt);
                    instruccion.ins2 = lineaInt;

                    int.TryParse(lineaSplit[3], out lineaInt);
                    instruccion.ins3 = lineaInt;

                    bloqueInstrucciones.instrucciones[j % 4] = instruccion;

                    if (j % 4 == 0 && j != 0)
                    {
                        memoriaInstrucciones.bloqueInstruccioneses[posicionMemoria] = bloqueInstrucciones;
                        posicionMemoria++;
                    }
                }
            }
        }

        public void IF()
        {
            //todo
            //cuando quiero bloquear el area compartida
            //mut_if_id.WaitOne();
            //cuando quiero librar el area compartida
            //mut_if_id.ReleaseMutex();
        }

        public void ID()
        {
            //todo
        }

        public void EX()
        {
            //todo
        }

        public void MEM()
        {
            //todo
        }

        public void WB()
        {
            //todo
        }

        public void Thread_Principal()
        {
            //todo
        }

        public Main()
        {

            LeeHilillos();

            //Estructuras intermedias
            int[] if_id = new int[5];
            int[] id_ex = new int[5];
            int[] ex_mem = new int[5];
            int[] mem_wb = new int[5];

            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.
            //Console.WriteLine("Hello World!");
            //Console.ReadKey();

            //creando las referecias a los hilos
            ThreadStart threadif = new ThreadStart(IF);
            ThreadStart threadid = new ThreadStart(ID);
            ThreadStart threadex = new ThreadStart(EX);
            ThreadStart threadmem = new ThreadStart(MEM);
            ThreadStart threadwb = new ThreadStart(WB);


            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
    }
}

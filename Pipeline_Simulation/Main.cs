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
        private static int totalQuantum;
        private int leftQuantum;

        private int pc;

        public CacheDatos cacheDatos = new CacheDatos();
        public CacheInstrucciones cacheInstrucciones = new CacheInstrucciones();

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
            for (int i = 0; i < 1; i++)
            {   
                string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Roy\Desktop\hilillos\" + i + ".txt");
                BloqueInstrucciones bloqueInstrucciones = new BloqueInstrucciones();
                for (int j = 0; j < lines.Length; j++)
                {
                    if (j % 4 == 0 && j != 0)
                    {
                        memoriaInstrucciones.bloqueInstruccioneses[posicionMemoria] = bloqueInstrucciones;
                        posicionMemoria++;
                    }

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

                }
            }
        }

        public void IF()
        {
            BloqueInstrucciones bloqueInstrucciones = cacheInstrucciones.BuscarInstruccion(pc);

            Instruccion irTemporal;

            /*Si hay fallo de cache*/
            if (bloqueInstrucciones == null)
            {
                bloqueInstrucciones = memoriaInstrucciones.BuscarInstruccion(pc);
                cacheInstrucciones.IngresarBloqueInstrucciones(bloqueInstrucciones, pc / 16);
                
            }

            /*No hay fallo de cache*/
            else
            {
                pc += 4;
            }
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
            int dummyIntermedioIR= 71;
 
            int dummyIntermedioA=9;
            int dummyIntermedioB=5;
            int dummyIntermedioImmediato = 5;
            int booleanoRL=0;//0-false
            int dummyResultadoALU=0;
            int dummyRL=0;

            int booleanBranch = 0;

            //switch para tipo de operacion
            switch (dummyIntermedioIR)
            {
                //aritmética
                case 71://add
                    dummyResultadoALU = dummyIntermedioA + dummyIntermedioB;
                    break;
                case 19://addi
                    dummyResultadoALU = dummyIntermedioA + dummyIntermedioImmediato; 
                    break;
                case 83://sub
                    dummyResultadoALU = dummyIntermedioA - dummyIntermedioB;
                    break;
                case 72://mul
                    dummyResultadoALU = dummyIntermedioA * dummyIntermedioB;
                    break;
                case 56://div
                    dummyResultadoALU = dummyIntermedioA / dummyIntermedioB;
                    break;
                //memoria
                case 5://lw
                    dummyResultadoALU = dummyIntermedioA + dummyIntermedioImmediato;
                    break;

                case 37://sw
                    dummyResultadoALU = dummyIntermedioA + dummyIntermedioImmediato;
                    break;

                case 51://lr
                    dummyResultadoALU = dummyIntermedioA + dummyIntermedioImmediato;
                    break;

                case 52://sc
                    dummyResultadoALU = dummyIntermedioA + dummyIntermedioImmediato;
                    break;
                //branch-jump
                case 99://beq
                  /*  if (dummyIntermedioA == dummyIntermedioB) {
                        booleanBranch = 1;
                    }*/
                    break;
                case 100://bne
                  /*  if (dummyIntermedioA != dummyIntermedioB)
                    {
                        booleanBranch = 1;
                    }*/
                    break;
                case 111://jal
                  /*  if (dummyIntermedioA == dummyIntermedioB)
                    {
                        booleanBranch = 1;
                    }*/
                    break;
                case 53://jalr
                  /*  if (dummyIntermedioA == dummyIntermedioB)
                    {
                        booleanBranch = 1;
                    }*/
                    break;

                default://999-FIN
                    
                    break;
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
            Console.WriteLine("Ingrese el quantum que quiere que tenga su programa: ");
            totalQuantum = Int32.Parse(Console.ReadLine());

            LeeHilillos();
            IF();

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

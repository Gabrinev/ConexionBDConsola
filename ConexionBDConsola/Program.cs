using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionBDConsola
{
    class Program
    {
        public static List<Job> jobslist;
        static void Main(string[] args)
        {

            int option = menu();

            while (option != 0)
            {
                switch (option)
                {
                    case 1:
                        showJobs();
                        break;
                    case 2:
                        insertNewJob();
                        break;
                    case 3:
                        modifyJob();
                        break;
                    case 4:
                        removeJob();
                        break;
                    case 5:
                        

                        break;
                   

                }
                option = menu();
            }
        }

        public static int menu()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("OFICINA DEL TRABAJO");
            Console.WriteLine("");
            Console.WriteLine("Pulse 1 para listar los trabajos");
            Console.WriteLine("Pulse 2 para añadir uno nuevo");
            Console.WriteLine("Pulse 3 para modificar uno existente");
            Console.WriteLine("Pulse 4 para eliminar uno");
            Console.WriteLine("Cualquier otra tecla para salir...");

            int bowl; // Variable to hold number
            ConsoleKeyInfo UserInput = Console.ReadKey(); // Get user input
            if (char.IsDigit(UserInput.KeyChar))
            {
                bowl = int.Parse(UserInput.KeyChar.ToString()); // use Parse if it's a Digit
                return bowl;
            }
            else
            {
                bowl = 0;  // Else we assign a default value
                return bowl;
            }
        }

        public static void insertNewJob()
        {
            String n;
            Decimal min, max;
            Console.WriteLine("");
            Console.WriteLine("Nombre trabajo: ");
            n = Console.ReadLine();
            Console.WriteLine("Sueldo minimo: ");
            min = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Sueldo maximo: ");
            max = Convert.ToDecimal(Console.ReadLine());

            Job temp = new Job(n, min, max);

            DALJob dalJob = new DALJob();
            dalJob.InsertJob(temp);
            Console.WriteLine("Cualquier otra tecla para salir...");
            Console.ReadKey();
        }

        private static void showJobs()
        {
            Console.WriteLine("");
            DALJob daljob = new DALJob();
            jobslist = daljob.SelectJobs();

            foreach (Job j in jobslist)
            {
                Console.WriteLine(j.ToString());
            }
            Console.WriteLine("Cualquier otra tecla para salir...");
            Console.ReadKey();
        }

        private static void removeJob()
        {
            Console.WriteLine("");
            Console.WriteLine("ID del trabajo que quiere eliminar: ");
            int n = Convert.ToInt32(Console.ReadLine());
            DALJob daljob = new DALJob();

            daljob.DelJob(n); 
            Console.WriteLine("Cualquier otra tecla para salir...");
            Console.ReadKey();

        }


        private static void modifyJob()
        {
            DALJob daljob = new DALJob();
            Console.WriteLine("");
            Console.WriteLine("ID del trabajo que quiere modificar: ");
            int n = Convert.ToInt32(Console.ReadLine());

            Job jobToMod = daljob.Select1Job(n);
            Console.WriteLine(jobToMod.ToString());

            String nom;
            Decimal min, max;

            Console.WriteLine("Nombre nuevo trabajo: ");
            nom = Console.ReadLine();
            Console.WriteLine("Nuevo sueldo minimo: ");
            min = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Nuevo sueldo maximo: ");
            max = Convert.ToDecimal(Console.ReadLine());

            Job temp = new Job(n,nom,min,max);
            daljob.UpdateJob(temp);
            Console.WriteLine("Cualquier otra tecla para salir...");
            Console.ReadKey();
        }
              
           
        
    }
}

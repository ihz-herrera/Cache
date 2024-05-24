using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cache
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            Console.WriteLine("Iniciando aplicación...");

            //crear un ciclo para ejecutar la validación de la licencia cada 1 segundo
            while (true)
            {
                //Medir el tiempo de cada ejecución
                var tiempoInicio = DateTime.Now;

                //crear una instancia de LicenciasService
                var licenciasService = new Repository.LicenciasService();


                var resultado = licenciasService.LicenciaValida();

                var tiempoFin = DateTime.Now;
                var tiempoTranscurrido = tiempoFin - tiempoInicio;

                //validar la licencia
                if (licenciasService.LicenciaValida())
                {
                    
                    Console.WriteLine($"La licencia es válida.{tiempoTranscurrido}");
                }
                else
                {
                    Console.WriteLine($"La licencia ha vencido.{tiempoTranscurrido}");
                }

                //esperar 1 segundo
                System.Threading.Thread.Sleep(1000);
                tiempoFin = DateTime.Now;
            }
        }
    }
}

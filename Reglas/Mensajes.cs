using System;
using System.Collections.Generic;
using System.Text;

namespace ParqueaderoApp.Reglas
{
    class Mensajes
    {
        public static void MensajeFinalizacion(string mensaje)
        {
            Console.Clear();
            Console.WriteLine(mensaje);
            Console.WriteLine("Presione enter para volver al menu incial");
            Console.ReadLine();
            Console.Clear();
        }
    }
}

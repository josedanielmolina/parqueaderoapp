using ParqueaderoApp.Reglas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Presentacion
{
    public class Menus
    {
        public void MenuPrincipalAdmin()
        {
            var salir = true;
            while (salir)
            {
                Console.Clear();
                Console.WriteLine("Menu Parqueadero - ADMIN");
                Console.WriteLine("*********************************************");

                Console.WriteLine("1-Registrar un servicio");
                Console.WriteLine("2-Finalizar un servicio");


                Console.WriteLine("Ingrese una opcion");

                var opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Regla.RegistrarServicio();
                        break;
                    case 2:
                        Regla.FinalizarServicio();
                        break;
                }
            }
        }        
        

    }
}

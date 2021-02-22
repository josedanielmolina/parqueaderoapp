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

                Console.WriteLine("1-Registrar un vehiculo");


                Console.WriteLine("Ingrese una opcion");

                var opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("Case 1");
                        break;

                }
            }
        }        
        

    }
}

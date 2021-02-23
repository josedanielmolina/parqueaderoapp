using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParqueaderoApp.Reglas
{
    class Regla
    {
        public static void RegistrarServicio()
        {
            using (var _context = new AppDbContext())
            {
                Console.Clear();

                Console.WriteLine("Digite la matricula");
                var matricula = Console.ReadLine();

                var matriculaFound = _context.Servicios.FirstOrDefault(x => x.Matricula == matricula);

                if (matriculaFound != null && matriculaFound.Estado == true)
                {
                    Console.Clear();
                    Console.WriteLine("El numero de matricula ya se encuentra registrado en el sistema");
                    Console.WriteLine("Presione enter para volver al menu principal");
                    Console.ReadLine();
                    return;

                }

                try
                {
                    var servicio = new Servicio();
                    servicio.Matricula = matricula;
                    servicio.Estado = true;
                    servicio.FechaEntrada = DateTime.Now;

                    _context.Add(servicio);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine(ex);

                    Console.WriteLine("Presione enter para continuar");
                    Console.ReadLine();
                    return;
                }

                

                Console.Clear();
                Console.WriteLine("Matricula registrada con exito");
                Console.WriteLine("Presione enter para regresar al menu principal");
                Console.ReadLine();
            }
        }
    }
}

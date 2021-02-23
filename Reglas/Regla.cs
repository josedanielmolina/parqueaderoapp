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

        public static void FinalizarServicio()
        {
            using (var _context = new AppDbContext())
            {
                Console.Clear();

                Console.WriteLine("Ingrese el numero de la matricula");
                var matriculaInput = Console.ReadLine();

                // Buscar la placa y verificar que existe y tenga un estado activo, en caso de que no exista enviar un mensaje de error
                var matriculaFound = _context.Servicios.FirstOrDefault(x => x.Matricula == matriculaInput && x.Estado == true);

                if(matriculaFound == null)
                {
                    Mensajes.MensajeFinalizacion("La matricula ingresada no cuenta con un registro activo");
                    return;
                }

                // Calcular el tiempo y costo del servicio y enviar un mensaje de informacion
                var fechaEntrada = matriculaFound.FechaEntrada;
                TimeSpan tiempoServicio = fechaEntrada.Subtract(DateTime.Now);
                Double tiempoServicioMinutos = Math.Abs(tiempoServicio.TotalMinutes);
                double tiempoServicioFinalRendondeado = Math.Truncate(tiempoServicioMinutos * 100) / 100;

                var valorHora = 25;
                double valorServicio = Math.Round(tiempoServicioFinalRendondeado * valorHora);


                Console.Clear();
                Console.WriteLine($"La duracion del servicio fue {tiempoServicioFinalRendondeado} minutos");
                Console.WriteLine($"El costo del servicio es ${valorServicio} pesos");
                Console.WriteLine("Desea finalizar el servicio ? si/no");
                var respuesta = Console.ReadLine();

                if (respuesta == "si")
                {
                    try
                    {
                        matriculaFound.Estado = false;
                        matriculaFound.FechaSalida = DateTime.Now;
                        matriculaFound.ValorServicio = valorServicio;
                        matriculaFound.DuracionSercivio = tiempoServicioFinalRendondeado;

                        _context.SaveChanges();

                        Mensajes.MensajeFinalizacion("Servicio finalizado con exito");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                        Mensajes.MensajeFinalizacion("Ha ocurrido un error, intente nuevamente");
                    }
                }
                else if (respuesta == "no")
                {
                    Console.Clear();
                    return;
                }
                else
                {
                    Mensajes.MensajeFinalizacion("Opcion incorrecta");
                    return;
                }

                Console.ReadLine();
                Mensajes.MensajeFinalizacion("El registro finalizo exitosamente");
            }
        }
    }
}

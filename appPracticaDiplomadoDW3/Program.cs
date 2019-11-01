using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appPracticaDiplomadoDW3
{
    class Program
    {
        static void Main(string[] args)
        {
            var empresa = new Empresa()
            {
                Nombre = "TECHSHYRA",
                Direccion = "SALOME UREÑA #12",
                RNC = "0018000124",
                Telefono = "829-773-8324"
            };

            var cliente = new Cliente()
            {
                Codigo = "00014",
                Nombre = "ROBERTO",
                Apellido = "DE LEON MARTINEZ",
                Direccion = "POR AHI"
            };

            var empleado = new Empleado()
            {
                Codigo = "00001",
                Nombre = "ROSA",
                Apellido = " FERRERAS",
                Direccion = "POR AHI ...",
                Puesto = "CAJERO"
            };

            var factura = new Factura(empresa, cliente, empleado);
            factura.Fecha = DateTime.Now;

            Console.WriteLine("************************* FACTURA *************************");
            Console.WriteLine("***********************" + empresa.Nombre + "***********************");

            while (true)
            {
                var producto = new Producto();
                var detalleFactura = new DetalleFactura();
                decimal precio, cantidad;

                Console.Write("INGRESE CODIGO PRODUCTO: ");
                producto.Codigo = Console.ReadLine();
                Console.Write("INGRESE NOMBRE PRODUCTO: ");
                producto.Descripcion = Console.ReadLine();
                Console.Write("INGRESE PRECIO PRODUCTO: ");
                if (decimal.TryParse(Console.ReadLine(), out precio) == false)
                    break;
                Console.Write("INGRESE CANTIDAD: ");
                if (decimal.TryParse(Console.ReadLine(), out cantidad) == false)
                    break;

                producto.Precio = precio;
                detalleFactura.AddLinea(producto, cantidad);

                factura.AddLineaFactura(detalleFactura);

                Console.WriteLine("++++++++++++++++ MENU +++++++++++++++++");
                Console.WriteLine("[S] CANCELAR");
                Console.WriteLine("[C] CONTINUAR");
                Console.WriteLine("[I] IMPRIMIR FACTURA");

                string op = Console.ReadLine();
                if (op == "I" || op == "i")
                {
                    factura.Imprimir();
                    break;
                }
                else if( op == "S" || op == "s")
                    break;
                else
                {
                    Console.Clear();
                    Console.WriteLine("************************* FACTURA *************************");
                    Console.WriteLine("***********************" + empresa.Nombre + "***********************");
                }
            }

            Console.ReadKey();
        }
    }
}

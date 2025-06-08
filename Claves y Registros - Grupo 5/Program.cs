using System;
using System.Collections.Generic;

class Persona
{
    public int IdEmpleado { get; set; }
    public string Nombre { get; set; }
}

class Program
{
    static List<Persona> personas = new List<Persona>
    {
        new Persona { IdEmpleado = 101, Nombre = "Alice" },
        new Persona { IdEmpleado = 102, Nombre = "Bob" },
        new Persona { IdEmpleado = 103, Nombre = "Charlie" }
    };

    static void Main()
    {
        int opcion;
        do
        {
            Console.Clear();
            Console.WriteLine("Menú Principal:");
            Console.WriteLine("1. Buscar empleado");
            Console.WriteLine("2. Añadir un nuevo usuario");
            Console.WriteLine("3. Desplegar tabla de empleados");
            Console.WriteLine("4. Salir");
            Console.Write("Seleccione una opción: ");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out opcion))
            {
                Console.WriteLine("Por favor, ingrese un número válido.");
                Console.ReadKey();
                continue;
            }

            switch (opcion)
            {
                case 1:
                    BuscarEmpleado();
                    break;
                case 2:
                    AñadirUsuario();
                    break;
                case 3:
                    DesplegarTabla();
                    break;
                case 4:
                    Console.WriteLine("Saliendo del programa...");
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }

            if (opcion != 4)
            {
                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
            }

        } while (opcion != 4);
    }

    static void BuscarEmpleado()
    {
        Console.Write("Ingrese el IdEmpleado a buscar: ");
        string input = Console.ReadLine();
        if (!int.TryParse(input, out int idBuscado))
        {
            Console.WriteLine("ID inválido.");
            return;
        }

        Persona encontrada = personas.Find(p => p.IdEmpleado == idBuscado);

        if (encontrada != null)
        {
            Console.WriteLine($"Empleado encontrado: {encontrada.Nombre}");
        }
        else
        {
            Console.WriteLine("Empleado no encontrado.");
            Console.Write("¿Deseas añadir este usuario como un nuevo registro? (si/no): ");
            string respuesta = Console.ReadLine().Trim().ToLower();

            if (respuesta == "si")
            {
                AñadirUsuario();
            }
        }
    }

    static void AñadirUsuario()
    {
        Console.Write("Ingrese el nombre del nuevo empleado: ");
        string nombre = Console.ReadLine();

        // Generar un nuevo ID único basado en el mayor ID existente
        int nuevoId = (personas.Count > 0) ? personas.Max(p => p.IdEmpleado) + 1 : 101;

        personas.Add(new Persona { IdEmpleado = nuevoId, Nombre = nombre });

        Console.WriteLine($"Usuario añadido con éxito. ID asignado: {nuevoId}");
    }

    static void DesplegarTabla()
    {
        Console.WriteLine("Lista de empleados:");
        foreach (var persona in personas)
        {
            Console.WriteLine($"ID: {persona.IdEmpleado}, Nombre: {persona.Nombre}");
        }
    }
}

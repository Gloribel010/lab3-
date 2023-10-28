// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using lab3;

using (var contextdb = new ContextDB())
{
    bool Continuar = true;
    while (Continuar)

    {
        Console.WriteLine("MOSTRAR DATOS DE TABLA:");
        Console.WriteLine("");

        foreach (var s in contextdb.evaluaciones)
        {
            Console.WriteLine($"Nombre: {s.nombre}, Porcentaje: {s.porcentaje}, fecha: {s.fecha}, Lugar: {s.lugar}");
            Console.WriteLine(" ");
        }
        Console.WriteLine("1 Agregar registros");
        Console.WriteLine("2 Actualizar registros");
        Console.WriteLine("");

        int opcion1 = Convert.ToInt32(Console.ReadLine());
        switch (opcion1)
        {
            case 1:

                contextdb.Database.EnsureCreated();

                Evaluaciones evaluaciones  = new Evaluaciones();

                Console.WriteLine("Ingresar Nombre:");
                evaluaciones.nombre = Console.ReadLine();

                Console.WriteLine("Ingresar Porcentaje:");
                evaluaciones.porcentaje = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Ingresar fecha:");
                evaluaciones.fecha = Console.ReadLine();

                Console.WriteLine("Ingresar Lugar:");
                evaluaciones.lugar = Console.ReadLine();

                contextdb.Add(evaluaciones);
                contextdb.SaveChanges();

                Console.WriteLine("Se agrego un nuevo registro");

                Console.WriteLine("¿Continuar agregando?(S/N): ");
                string Si = Console.ReadLine();
                Continuar = Si.ToLower() == "s";
                break;

            case 2:
                Console.WriteLine("Ingrese el Id del registro que desea modificar");
                var id = Console.ReadLine();
                var persona = contextdb.evaluaciones.FirstOrDefault(p => p.id == Int32.Parse(id));

                if (persona != null)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Para Actualizar el atributo Nombre escriba 1");
                    Console.WriteLine("");
                    Console.WriteLine("1 Nombre");
                    

                    int op = Convert.ToInt32(Console.ReadLine());
                    switch (op)
                    {

                        case 1:
                            Console.WriteLine("");
                            Console.WriteLine("Ingresar nuevo Nombre: ");
                            persona.nombre = Console.ReadLine();
                            Console.WriteLine("");
                            Console.WriteLine("Nombre actualizado");
                            break;                    

                    }
                    contextdb.SaveChanges();
                }
                else
                {
                    Console.WriteLine("");
                    Console.WriteLine("El Id no se ha encontrado");
                }
                break;

                Console.WriteLine();
                Console.WriteLine("¿Desea continuar? Presione S(Si) o N(No) S/N");
                var cont = Console.ReadLine();
                if (cont.Equals("N"))
                {
                    Continuar = false;
                }
        }
        Console.WriteLine("");
    }
}

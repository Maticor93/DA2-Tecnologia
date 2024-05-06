// Cargamos el assembly de ejemplo en memoria (Path para windows)
using Reflection;
using System.Reflection;

var assembly = Assembly.GetExecutingAssembly();

foreach (var type in assembly.GetTypes())
{

    // Podemos ver que Tipos hay dentro del assembly
    Console.WriteLine(string.Format("Clase: {0}", type.Name));

    Console.WriteLine("Propiedades publicas");
    foreach (PropertyInfo prop in type.GetProperties())
    {
        Console.WriteLine(string.Format("\t{0} : {1}", prop.Name, prop.PropertyType.Name));
    }

    Console.WriteLine("Constructores publicos");
    foreach (ConstructorInfo constructor in type.GetConstructors())
    {
        Console.Write("\tConstructor: ");
        foreach (ParameterInfo param in constructor.GetParameters())
        {
            Console.Write(string.Format("{0} : {1} ", param.Name, param.ParameterType.Name));
        }
        Console.WriteLine();
    }

    Console.WriteLine();
    Console.WriteLine("Metodos publicos");
    foreach (MethodInfo functions in type.GetMethods())
    {
        Console.Write(string.Format("\t{0} ", functions.Name));
        foreach (ParameterInfo parameter in functions.GetParameters())
        {
            Console.Write(string.Format("{0} : {1} ", parameter.Name, parameter.ParameterType.Name));
        }
        Console.WriteLine();
    }
}
Console.WriteLine();
Console.ReadLine();

// Cargamos el assembly de ejemplo en memoria (Path para windows)
using Reflection;
using System.Reflection;

var movie = new Movie
{
    Id = Guid.NewGuid().ToString(),
    Name = "Some name",
    Description = "Some description"
};

var movieValidator = GetImplementation<IMovieValidator>();

Console.WriteLine(movieValidator.IsValid(movie));

IInterface GetImplementation<IInterface>(params object[] parameters)
    where IInterface : class
{
    var assemblyDirectory = Directory.GetCurrentDirectory();
    try
    {
        Assembly myAssembly = Assembly.LoadFile($"{assemblyDirectory}/Reflection.ThirdParty.Validator.dll");

        var implementations = GetImplementationsTypes<IInterface>(myAssembly);
        if (implementations.Count == 0)
        {
            throw new NullReferenceException($"{assemblyDirectory} don't contains Types that extend from {typeof(IInterface).Name}");
        }

        var typeOfImplementation = implementations.First();

        var instanceOfImplementation = Activator.CreateInstance(typeOfImplementation, parameters) as IInterface;

        return instanceOfImplementation;
    }
    catch (Exception e)
    {
        throw new Exception($"Can't load assembly {assemblyDirectory}", e);
    }
}

List<Type> GetImplementationsTypes<IInterface>(Assembly assembly)
{
    var types = assembly
        .GetTypes()
        .Where(t => t.IsClass && typeof(IInterface).IsAssignableFrom(t))
        .ToList();

    return types;
}

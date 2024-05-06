using System.Reflection;

namespace Reflection
{
    public sealed class LoadAssembly<IInterface>(string path)
        where IInterface : class
    {
        private readonly DirectoryInfo directory = new(path);
        private List<Type> implementations = [];


        public List<string> GetImplementations()
        {
            var files = this.directory
                .GetFiles("*.dll")
                .ToList();

            implementations = [];
            files.ForEach(file =>
            {
                Assembly assemblyLoaded = Assembly.LoadFile(file.FullName);
                var loadedTypes = assemblyLoaded
                .GetTypes()
                .Where(t => t.IsClass && typeof(IInterface).IsAssignableFrom(t))
                .ToList();

                if (loadedTypes.Count == 0)
                {
                    Console.WriteLine($"Nadie implementa la interfaz: {typeof(IInterface).Name} en el assembly: {file.FullName}");

                    return;
                }

                this.implementations = implementations
                .Union(loadedTypes)
                .ToList();
            });

            return this.implementations.ConvertAll(t => t.Name);
        }

        public IInterface GetImplementation(int index, params object[] args)
        {
            var type = implementations.ElementAt(index);

            return Activator.CreateInstance(type, args) as IInterface;
        }
    }
}

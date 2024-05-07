namespace DI.WebApi.Services
{
    public sealed class Service(IDependency _dependency) : 
        ITransientService,
        IScopeService,
        ISingletonService
    {
        private readonly Guid _token = Guid.NewGuid();

        public Guid GetToken()
        {
            return _token;
        }
    }
}

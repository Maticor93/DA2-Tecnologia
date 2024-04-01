namespace DI.WebApi.Services
{
    public sealed class Service : 
        ITransientService,
        IScopeService,
        ISingletonService
    {
        private readonly Guid _token;

        private readonly IDependency _dependency;

        public Service()
        {
            _token = Guid.NewGuid();
        }

        public Guid GetToken()
        {
            return _token;
        }
    }
}

using Autofac;

namespace DataAcces
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private ILifetimeScope _scope;

        public UnitOfWorkFactory(ILifetimeScope scope)
        {
            _scope = scope;
        }

        public IUnitOfWork Create() => _scope.Resolve<IUnitOfWork>();
    }
}

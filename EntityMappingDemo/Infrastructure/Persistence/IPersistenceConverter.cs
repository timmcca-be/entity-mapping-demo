namespace EntityMappingDemo.Infrastructure.Persistence
{
    public interface IPersistenceConverter<TDomain, TPersistence> where TPersistence : IPersistable<TDomain>
    {
        public TPersistence ToPersistable(TDomain domainObject);
    }
}

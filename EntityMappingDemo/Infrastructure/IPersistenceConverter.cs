namespace EntityMappingDemo.Infrastructure
{
    internal interface IPersistenceConverter<TDomain, TPersistence> where TPersistence : IPersistable<TDomain>
    {
        public TPersistence ToPersistable(TDomain domainObject);
    }
}

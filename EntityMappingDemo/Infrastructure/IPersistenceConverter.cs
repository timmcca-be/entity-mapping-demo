namespace EntityMappingDemo.Infrastructure
{
    internal interface IPersistenceConverter<TDomain, TPersistence>
    {
        public TPersistence ToPersistenceObject(TDomain domainObject);
        public TDomain ToDomainObject(TPersistence persistenceObject);
    }
}

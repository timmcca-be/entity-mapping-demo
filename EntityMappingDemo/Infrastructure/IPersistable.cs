namespace EntityMappingDemo.Infrastructure
{
    public interface IPersistable<T>
    {
        public T DomainObject { get; }
    }
}

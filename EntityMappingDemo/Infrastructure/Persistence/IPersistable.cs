namespace EntityMappingDemo.Infrastructure.Persistence
{
    public interface IPersistable<T>
    {
        public T DomainObject { get; }
    }
}

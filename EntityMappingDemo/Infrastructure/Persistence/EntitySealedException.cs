using System;

namespace EntityMappingDemo.Infrastructure.Persistence
{
    public class EntitySealedException : InvalidOperationException
    {
        internal EntitySealedException()
            : base("This entity has been sealed, which means it is associated with a domain object. It can only be modified via the domain object.")
        { }
    }
}

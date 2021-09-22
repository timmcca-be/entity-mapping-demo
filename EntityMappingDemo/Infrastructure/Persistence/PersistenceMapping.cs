using System.Collections.Generic;
using System.Linq;

namespace EntityMappingDemo.Infrastructure.Persistence
{
    public class PersistenceMapping<TDomain, TPersistence> where TPersistence : IPersistable<TDomain>
    {
        private readonly Dictionary<TDomain, TPersistence> _mapping = new();
        private readonly IPersistenceConverter<TDomain, TPersistence> _converter;

        public PersistenceMapping(IPersistenceConverter<TDomain, TPersistence> converter)
        {
            _converter = converter;
        }

        public List<TPersistence> MapToPersistence(IEnumerable<TDomain> domainObjects) =>
            domainObjects.Select(domainObject =>
            {
                if (_mapping.ContainsKey(domainObject))
                {
                    return _mapping[domainObject];
                }
                else
                {
                    var persistable = _converter.ToPersistable(domainObject);
                    _mapping[domainObject] = persistable;
                    return persistable;
                }
            }).ToList();

        public List<TDomain> MapToDomain(IEnumerable<TPersistence> persistables) =>
            persistables.Select(persistable =>
            {
                var domainObject = persistable.DomainObject;
                _mapping[domainObject] = persistable;
                return domainObject;
            }).ToList();
    }
}

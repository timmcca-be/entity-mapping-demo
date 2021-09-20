using System.Collections.Generic;
using System.Linq;

namespace EntityMappingDemo.Infrastructure
{
    internal class PersistenceMapping<TDomain, TPersistence>
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
                    var persistenceObject = _converter.ToPersistenceObject(domainObject);
                    _mapping[domainObject] = persistenceObject;
                    return persistenceObject;
                }
            }).ToList();

        public List<TDomain> MapToDomain(IEnumerable<TPersistence> persistenceObjects) =>
            persistenceObjects.Select(persistenceObject =>
            {
                var domainObject = _converter.ToDomainObject(persistenceObject);
                _mapping[domainObject] = persistenceObject;
                return domainObject;
            }).ToList();
    }
}

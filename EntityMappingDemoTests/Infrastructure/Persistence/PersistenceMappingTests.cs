using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace EntityMappingDemo.Infrastructure.Persistence.Tests
{
    internal class MockDomainObject { }

    internal class MockPersistable : IPersistable<MockDomainObject>
    {
        private MockDomainObject _domainObject;
        public MockPersistable() { }
        public MockPersistable(MockDomainObject domainObject) => _domainObject = domainObject;
        public MockDomainObject DomainObject => _domainObject ??= new();
    }

    internal class MockPersistenceConverter : IPersistenceConverter<MockDomainObject, MockPersistable>
    {
        public MockPersistable ToPersistable(MockDomainObject domainObject) => new(domainObject);
    }

    [TestClass()]
    public class PersistenceMappingTests
    {
        private PersistenceMapping<MockDomainObject, MockPersistable> CreateTestMapping() => new(
            new MockPersistenceConverter());

        [TestMethod()]
        public void MapToDomain_EmptyList_GeneratesEmptyList()
        {
            // Arrange
            var persistenceMapping = CreateTestMapping();
            var persistables = new List<MockPersistable>();

            // Act
            var domainObjects = persistenceMapping.MapToDomain(persistables);

            // Assert
            Assert.AreEqual(0, domainObjects.Count);
        }

        [TestMethod()]
        public void MapToDomain_TwoPersistables_GeneratesTwoDomainObjects()
        {
            // Arrange
            var persistenceMapping = CreateTestMapping();
            var persistables = new List<MockPersistable>
            {
                new(),
                new(),
            };

            // Act
            var domainObjects = persistenceMapping.MapToDomain(persistables);

            // Assert
            Assert.AreEqual(2, domainObjects.Count);
            Assert.AreSame(persistables[0].DomainObject, domainObjects[0]);
            Assert.AreSame(persistables[1].DomainObject, domainObjects[1]);
        }

        [TestMethod()]
        public void MapToPersistence_ModifiedDomainObjects_ModifiesPersistables()
        {
            // Arrange
            var persistenceMapping = CreateTestMapping();
            var persistables = new List<MockPersistable>
            {
                new(),
                new(),
                new(),
            };
            var domainObjects = persistenceMapping.MapToDomain(persistables);
            var modifiedDomainObjects = new List<MockDomainObject>()
            {
                domainObjects[2],
                new MockDomainObject(),
                new MockDomainObject(),
                domainObjects[0],
            };

            // Act
            var modifiedPersistables = persistenceMapping.MapToPersistence(modifiedDomainObjects);

            // Assert
            Assert.AreEqual(4, modifiedPersistables.Count);
            Assert.AreSame(persistables[0], modifiedPersistables[3]);
            Assert.AreSame(modifiedDomainObjects[1], modifiedPersistables[1].DomainObject);
            Assert.AreSame(modifiedDomainObjects[2], modifiedPersistables[2].DomainObject);
            Assert.AreSame(persistables[2], modifiedPersistables[0]);
        }
    }
}
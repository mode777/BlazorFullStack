using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BlazorFullStack.Shared.Framework
{
    public class EntityMetadata
    {
        public EntityMetadata(Type type)
        {
            Type = type;
            DisplayName = type.Name;
            Id = Type.AssemblyQualifiedName.GetHashCode();
            Properties = type.GetProperties()
                .Select(x => new EntityProperty(x))
                .ToArray();
        }

        public int Id { get; }
        public Type Type { get; }
        public string DisplayName { get; }
        public IEnumerable<EntityProperty> Properties { get; }

        public Type GetQuery(int queryId)
        {

        }
    }

    public class EntityProperty
    {
        public EntityProperty(PropertyInfo property)
        {
            Property = property;
            DisplayName = property.Name;
        }

        public PropertyInfo Property { get; }
        public string DisplayName { get; }

        public object GetValue(object instance)
        {
            return Property.GetValue(instance);
        }

    }


    public class MetadataService
    {
        private readonly ConcurrentDictionary<Type, EntityMetadata> _cache = new ConcurrentDictionary<Type, EntityMetadata>();
        private readonly ConcurrentDictionary<int, Type> _typeLookup = new ConcurrentDictionary<int, Type>();

        public EntityMetadata GetMetadata<T>()
        {
            return GetMetadata(typeof(T));
        }

        public EntityMetadata GetMetadata(Type type)
        {
            return _cache.GetOrAdd(type, t => CreateMetadata(t));
        }

        public EntityMetadata GetMetadata(int metadataId)
        {
            if (_typeLookup.TryGetValue(metadataId, out var type))
            {
                return GetMetadata(type);
            }
            throw new KeyNotFoundException($"No metdata for {metadataId}");
        }

        private EntityMetadata CreateMetadata(Type type)
        {
            var metadata = new EntityMetadata(type);
            _typeLookup.TryAdd(metadata.Id, type);

            return metadata;
        }
    }
}

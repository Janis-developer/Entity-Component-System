using System;
using System.Collections.Generic;

namespace ECS.Entities_and_Manager
{
    class EntitiesManager : IEntitesProvider
    {
        Dictionary<string, Entity> entities = new Dictionary<string, Entity>();

        public event IEntitesProvider.EntityOperationEventHandler OnEntityAdded;
        public event IEntitesProvider.EntityOperationEventHandler OnEntityRemoved;

        public Entity CreateEntity(string name, HashSet<Type> set)
            // where each Type obj : is typeof(IComponent)
        {
            Entity e = new Entity(name, set);

            entities.Add(name, e);

            OnEntityAdded?.Invoke(e);

            return e;
        }

        public void AddNewEntity(Entity entity)
        {
            entities.Add(entity.Name, entity);

            OnEntityAdded?.Invoke(entity);
        }

        public IEnumerable<Entity> GetList()
        {
            return entities.Values;
        }

        internal void RemoveEntity(string name)
        {
            Entity e = entities[name];
            entities.Remove(name);
            OnEntityRemoved?.Invoke(e);
        }
    }
}

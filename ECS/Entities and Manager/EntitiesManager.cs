using System;
using System.Collections.Generic;
using System.Text;

namespace ECS.Entities_and_Manager
{
    using Components;
    using Entities_and_Manager;
    using System.Diagnostics;

    class EntitiesManager : IEntitesProvider
    {
        LinkedList<Entity> entities = new LinkedList<Entity>(); //maybe not even need it here

        //public delegate void EntityCreatedEventHandler(Entity entity);
        //public event EntityCreatedEventHandler OnEntityCreated;

        // to make entities very dynamic kind
        //public delegate void EntityComponentsSetModifiedEventHandler(Entity entity);
        //public event EntityComponentsSetModifiedEventHandler OnEntityComponentsSetModified;

        public event IEntitesProvider.EntityCreatedEventHandler OnEntityAdded;

        public Entity CreateEntity(string name, HashSet<Type> set)
            // where each Type obj : is typeof(IComponent)
        {
            Entity e = new Entity(name, set);

            OnEntityAdded?.Invoke(e);

            entities.AddLast(e);
            return e;
        }

        public void AddNewEntity(Entity entity)
        {
            OnEntityAdded?.Invoke(entity);

            entities.AddLast(entity);
        }

    }
}

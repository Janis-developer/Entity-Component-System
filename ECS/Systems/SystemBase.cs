using System;
using System.Collections.Generic;
using System.Text;

namespace ECS.Systems
{
    using Entities_and_Manager;
    using Components;

    abstract public class SystemBase
    {
        // set of specific compponets which an entity shall have in order to be processable by this specific System
        HashSet<Type> traits;

        // cache of (ref to) objects which are being processed by this system
        LinkedList<Entity> entities = new LinkedList<Entity>();

        private SystemBase(HashSet<Type> set)
        {
            traits = new HashSet<Type>(set);
        }

        public SystemBase(HashSet<Type> set, IEntitesProvider ep)
            : this(set)
        {
            ep.OnEntityAdded += this.OnEntityAdded;
            ep.OnEntityRemoved += this.OnEntityRemoved;
        }

        public SystemBase(HashSet<Type> set, IEntitesProvider.EntityOperationEventHandler eh)
            : this(set)
        {
            eh += this.OnEntityAdded;
        }

        public abstract void Init();

        public void Set<TComponent>(TComponent comp, Entity entity) where TComponent : IComponent
        {
            entity.SetComponent<TComponent>(comp);
        }

        private void OnEntityAdded(Entity entity)
        {
            if (traits.IsSubsetOf(entity.GetTraits()))
                entities.AddLast(entity);
        }

        private void OnEntityRemoved(Entity entity)
        {
            var node = entities.Find(entity);
            if (node != null)
                entities.Remove(node);

            //if (entities.Contains(entity))
            //    entities.Remove(entity);        }
        }

        public virtual void UpdateSystem()
        {
            foreach (var obj in entities)
                Update(obj);
        }

        protected abstract void Update(Entity obj);
    }
}

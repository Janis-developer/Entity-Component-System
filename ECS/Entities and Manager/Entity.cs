using System;
using System.Collections.Generic;
using System.Text;

namespace ECS.Entities_and_Manager
{
    using Components;

    public class Entity //: IEntity
    {
        ComponentManager componentsManager;

        // Could use Id (if any, maybe in real system reference would be enough)
        //, but for the debuging/demo console output use string
        public string Name { get; }

        public Entity(string name)
        {
            this.Name = name;
            componentsManager = new ComponentManager();
        }

        /// <summary>
        /// c-tor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="set">set of traits types for this entity</param>
        public Entity(string name, HashSet<Type> set)
        {
            this.Name = name;
            componentsManager = new ComponentManager(set);
        }

        /// <summary>
        /// Get all the components
        /// </summary>
        /// <returns></returns>
        internal IEnumerable<Type> GetTraits()
        {
            return componentsManager.GetTraits();
        }

        internal TComponent GetComponent<TComponent>() where TComponent : IComponent
        {
            return componentsManager.GetComponent<TComponent>();
        }

        internal void SetComponent<TComponent>(TComponent comp) where TComponent : IComponent
        {
            componentsManager.SetComponent(comp);
        }

        // to make app very dynamic
        public void AddNewComponent<TComponent>(TComponent comp) 
            where TComponent : IComponent
        {
            componentsManager.AddNewComponent<TComponent>(comp);
        }
        // we can modify traits on the fly (remember to notiy)
        public void RemoveComponent<TComponent>() 
            where TComponent : IComponent
        {
            //componentsManager.RemoveComponent<TComponent>();
        }
    }
}

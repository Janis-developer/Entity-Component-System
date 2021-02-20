using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ECS.Components
{
    class ComponentManager
    {
        public Dictionary<Type, IComponent> components = new Dictionary<Type, IComponent>();
        public HashSet<Type> traits;

        public ComponentManager()
        {
            traits = new HashSet<Type>();
        }

        public ComponentManager(HashSet<Type> set)
        {
            traits = new HashSet<Type>(set);
            CreateComponents(set);
        }

        private void CreateComponents(HashSet<Type> traits)
        {
            foreach (var t in traits)
            {
                Debug.Assert(t.IsSubclassOf(typeof(IComponent)));
                var ctor = t.GetConstructor(new Type[] { });
                var tObj = (IComponent)ctor.Invoke(null);
                components.Add(t, tObj);
            }
        }

        internal IEnumerable<Type> GetTraits()
        {
            return traits;
        }

        internal TComponent GetComponent<TComponent> () where TComponent : IComponent
        {
            // now, for simple system it is safe to presume that only valid types will be queried,
            // because only 'interested' systems with matching traits requiremets were subscribed
            // but we can also do full check and either return null or throw.
            Debug.Assert(traits.Contains(typeof(TComponent)));

            return (TComponent)components[typeof(TComponent)];
        }

        internal void SetComponent<TComponent>(TComponent comp) where TComponent : IComponent
        {
            Debug.Assert(traits.Contains(typeof(TComponent)));

            components[typeof(TComponent)] = comp;
        }

        internal void AddNewComponent<TComponent>(TComponent comp) where TComponent : IComponent
        {
            //components[typeof(TComponent)] = comp;
            components.Add(typeof(TComponent), comp);
            traits.Add(typeof(TComponent));
        }
    }
}

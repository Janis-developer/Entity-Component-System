namespace ECS.Systems
{
    using System.Collections.Generic;
    using ECS.Entities_and_Manager;
    using Components;
    using System;

    internal class DrawingSystem : SystemBase
    {
        public DrawingSystem(IEntitesProvider ep) 
            : base(new HashSet<Type> { typeof(Dispalyable), typeof(Position) }, ep)
        { 
            // here do some graphic system initialisation
        }

        public override void Init()
        {
            throw new System.NotImplementedException();
        }

        // Draw entity 
        protected override void Update(Entity obj)
        {
            // only Drawable entities are added to this system
            Dispalyable comp = obj.GetComponent<Dispalyable>();
            Position position = obj.GetComponent<Position>();

            if (comp.visibleNow)
            {
                Console.WriteLine($"DrawingSystem is displaying object '{obj.Name}': {comp.mesh.ResourceName} at {position.pos.x}:{position.pos.y}.");
            }
            else
            {
                Console.WriteLine($"DrawingSystem - object '{obj.Name}' is invisible now.");
            }
        }
    }
}
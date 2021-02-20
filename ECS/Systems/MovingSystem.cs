namespace ECS.Systems
{
    using System.Collections.Generic;
    using ECS.Entities_and_Manager;
    using Components;
    using System;

    internal class MovingSystem : SystemBase
    {
        public MovingSystem(IEntitesProvider ep)
            : base(new HashSet<Type> { typeof(Velocity), typeof(Position) }, ep)
        {
            // here do some moving system initialisation
        }

        public override void Init()
        {
            throw new System.NotImplementedException();
        }

        // Move entity
        protected override void Update(Entity obj)
        {
            // only Drawable entities are added to this system
            Position position = obj.GetComponent<Position>();
            Velocity velocity = obj.GetComponent<Velocity>();

            // do the move logic ...
            Console.WriteLine($"MovingSystem is moving object '{obj.Name}' by {velocity.vel.dx}:{velocity.vel.dy}");

            position.pos.x += velocity.vel.dx;
            position.pos.y += velocity.vel.dy;
        }
    }
}
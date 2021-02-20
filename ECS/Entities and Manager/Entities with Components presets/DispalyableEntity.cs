using System;
using System.Collections.Generic;

namespace ECS.Entities_and_Manager.Entities_with_Components_presets
{
    using Components;
    internal class DispalyableEntity : Entity
    {
        internal DispalyableEntity(string name, Point position, Mesh objMesh, bool visible)
            //: base(name, new HashSet<Type> { typeof(Dispalyable), typeof(Position) })
            : base(name)
        {
            this.AddNewComponent<Position>(new Position { pos = position });
            this.AddNewComponent<Dispalyable>(new Dispalyable { mesh = objMesh, visibleNow = visible });
        }
    }
}

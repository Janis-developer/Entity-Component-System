using System;
using System.Collections.Generic;
using System.Text;

namespace ECS.Entities_and_Manager.Entities_with_Components_presets
{
    using Components;

    internal class DispalyableMovingEntity : DispalyableEntity
    {
        internal DispalyableMovingEntity(string name, Point position, Mesh objMesh, bool visible, Vector velocity)
            : base(name, position, objMesh, visible)
        {
            this.AddNewComponent<Velocity>(new Velocity { vel = velocity });
        }
    }
}

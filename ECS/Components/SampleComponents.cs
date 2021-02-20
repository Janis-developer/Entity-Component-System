namespace ECS.Components
{
    // Some example of concrete components

    class Position : IComponent
    {
        public Point pos;
    }

    class Velocity : IComponent
    {
        public Vector vel;
    }

    class Dispalyable: IComponent
    {
        public Mesh mesh;
        public bool visibleNow;
    }

    class Destroyable : IComponent
    {
        public double health;

        // we can either keep clean-data-only-component
        // or use some helper logic here, to make a System using this component simpler
        // for instance
        // apply check logic in getter-setter
        // public double Health { get; set; }
        // public Heal(amount) Damage(amount) ... la la la whatever we need typicaly
    }

    // and so on...
}

// dummy classes for demo, its obviously what they should contain
struct Point { public long x, y; }
struct Vector { public long dx, dy; }
class Mesh{ public Mesh(string resourceName)  { ResourceName = resourceName; } public string ResourceName { get; set; } }

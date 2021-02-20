using System;
using System.Collections.Generic;
using System.Text;

namespace ECS
{
    using Components;
    using ECS.Entities_and_Manager.Entities_with_Components_presets;
    using Entities_and_Manager;
    using System.Diagnostics;
    using Systems;

    class World
    {
        static EntitiesManager entitiesManager;
        static DrawingSystem drawingSystem;
        static MovingSystem movingSystem;
        //and so on
        //static PhysicsSystem physicsSystem;
        //static ScoreSystem scoreSystem;

        internal static void Init()
        {
            entitiesManager = new EntitiesManager();

            drawingSystem = new DrawingSystem(entitiesManager);
            movingSystem = new MovingSystem(entitiesManager);
            //and so on


            CreateDemoEntities();
        }

        private static void CreateDemoEntities()
        {
            //alternatively we could use something in this style
            //new Entity("Car", new List<IComponent> {
            //                            new Position { pos = new Point() },
            //                            new Dispalyable { mesh = new Mesh(), visibleNow = true },
            //                            new Destroyable { health = 100 } });

            var set1 = new HashSet<Type> { typeof(Position), typeof(Velocity), typeof(Dispalyable), };
            Entity e;
            e = entitiesManager.CreateEntity("Car", set1);
            e.SetComponent<Position>(new Position { pos = new Point { x = 350, y = 350} });
            e.SetComponent<Velocity>(new Velocity { vel = new Vector { dx = 10, dy = 10 } });
            e.SetComponent<Dispalyable>(new Dispalyable { mesh = new Mesh("~this is how Tesla looks~"), visibleNow = true});

            entitiesManager.AddNewEntity(
                new DispalyableMovingEntity("Bicycle", new Point() { x = 250, y = 250 }, new Mesh("~cool looking bicycle~"), true, new Vector { dx = 5, dy = 5 }));
            entitiesManager.AddNewEntity(
                new DispalyableMovingEntity("Janis", new Point() { x = 150, y = 150 }, new Mesh("~looking good~"), true, new Vector { dx = 4, dy = 4 }));

            // can use one set with mnany entities, but have to set value individualy :
            //var set2 = new HashSet<Type> { typeof(Position), typeof(Dispalyable), };
            //Entity e2;
            //e2 = entitiesManager.CreateEntity("House", set2);
            //e2 = entitiesManager.CreateEntity("Library", set2);
            //e2 = entitiesManager.CreateEntity("Gym", set2);
            entitiesManager.AddNewEntity( 
                new DispalyableEntity("House", new Point(){ x = 100, y = 100 }, new Mesh("~view of Modern house~"), true) );
            entitiesManager.AddNewEntity(
                new DispalyableEntity("Library", new Point() { x = 300, y = 300 }, new Mesh("~view of Art house~"), true));
            entitiesManager.AddNewEntity(
                new DispalyableEntity("Gym", new Point() { x = 500, y = 500 }, new Mesh("~view of Modern house~"), true));

            var set3 = new HashSet<Type> { typeof(Position), typeof(Velocity) }; //strictly speaking we should have created "Area", but you got the idea
            Entity e3;
            e3 = entitiesManager.CreateEntity("Wind", set3);
            e3.SetComponent<Position>(new Position { pos = new Point { x = 450, y = 450 } });
            e3.SetComponent<Velocity>(new Velocity { vel = new Vector { dx = 10, dy = 10} });
        }

        internal static void Run()
        {
            Debug.WriteLine("Running Demo entities:");
            Console.WriteLine("Running Demo entities:");
            for(int counter = 10; counter >0; --counter)
            {
                movingSystem.UpdateSystem();
                drawingSystem.UpdateSystem();
            }
        }


        internal static void Collapse()
        {
            Debug.WriteLine("Finish.");
        }

    }
}

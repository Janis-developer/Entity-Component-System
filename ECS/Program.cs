namespace ECS
{
    class Program
    {
        static void Main(string[] args)
        {
            World.Init();
            World.Run();
            World.Collapse();
        }
    }
}

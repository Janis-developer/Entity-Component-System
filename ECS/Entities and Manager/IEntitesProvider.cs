namespace ECS.Entities_and_Manager
{
    public interface IEntitesProvider
    {
        public delegate void EntityCreatedEventHandler(Entity entity);
        public event EntityCreatedEventHandler OnEntityAdded;
    }
}
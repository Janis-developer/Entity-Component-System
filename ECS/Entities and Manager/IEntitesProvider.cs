namespace ECS.Entities_and_Manager
{
    public interface IEntitesProvider
    {
        public delegate void EntityOperationEventHandler(Entity entity);
        public event EntityOperationEventHandler OnEntityAdded;
        public event EntityOperationEventHandler OnEntityRemoved;
    }
}
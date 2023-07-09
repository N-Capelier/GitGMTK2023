namespace Runtime.Entities
{
    public interface IEntityComponent
    {
        public void Initialize(Entity entity);
        public void Kill();
    }
}
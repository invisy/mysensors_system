namespace MySensors.ApplicationCore.Entities
{
    public abstract class BaseEntity<T>
    {
        public virtual T Id { get; protected set; }
    }
}
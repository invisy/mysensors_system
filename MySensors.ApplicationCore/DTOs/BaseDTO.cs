namespace MySensors.ApplicationCore.DTOs
{
    public abstract class BaseDTO<T>
    {
        public virtual T Id { get; set; }
    }
}
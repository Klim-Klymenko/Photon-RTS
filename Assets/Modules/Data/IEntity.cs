namespace Common.Data
{
    public interface IEntity
    {
        bool TryGetScript<T>(out T component);
        T GetScript<T>();
        void AddScript<T>(T component);
        bool HasScript<T>();
    }
}
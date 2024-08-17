namespace Common.Creation
{
    public interface IFactory<out T>
    {
        T Create();
    }
    
    public interface IFactory<out TR, in TArgs>
    {
        TR Create(TArgs args);
    }
}
namespace System.GameCycle
{
    public interface IStartable : IGameListener
    {
        void OnStart();
    }
}
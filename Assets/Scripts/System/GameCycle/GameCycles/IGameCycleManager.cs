namespace System.GameCycle
{
    public interface IGameCycleManager
    {
        void AddListener(IGameListener listener);
        void RemoveListener(IGameListener listener);
    }
}
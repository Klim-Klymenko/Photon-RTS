namespace System.GameCycle
{
    public interface ILateUpdatable : IGameListener
    {
        void OnLateUpdate();
    }
}
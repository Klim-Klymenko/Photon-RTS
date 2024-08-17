namespace System.GameCycle
{
    public interface IUpdatable : IGameListener
    {
        void OnUpdate();
    }
}
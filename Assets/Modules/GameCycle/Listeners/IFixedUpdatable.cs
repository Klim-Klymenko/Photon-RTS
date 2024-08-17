namespace System.GameCycle
{
    public interface IFixedUpdatable : IGameListener
    {
        void OnFixedUpdate();   
    }
}
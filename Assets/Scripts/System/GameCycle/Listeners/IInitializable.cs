namespace System.GameCycle
{
    public interface IInitializable : IGameListener
    {
        void OnInitialize();
    }
}
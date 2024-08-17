namespace System.GameCycle
{
    public interface IFinishable : IGameListener
    {
        void OnFinish();
    }
}
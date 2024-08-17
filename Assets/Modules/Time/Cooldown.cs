namespace Common.Time
{
    public sealed class Cooldown
    {
        private const byte EndTime = 0;
        private float _currentTime;
        
        private readonly float _duration;

        public Cooldown(float duration)
        {
            _duration = duration;
            _currentTime = duration;
        }
        
        public void Tick(float deltaTime)
        {
            _currentTime -= deltaTime;
        }
        
        public void Reset()
        {
            _currentTime = _duration;
        }
        
        public bool IsPlaying()
        {
            return _currentTime > EndTime;
        }

        public bool IsFinished()
        {
            return _currentTime <= EndTime;
        }
    }
}
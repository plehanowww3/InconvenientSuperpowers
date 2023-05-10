namespace DefaultNamespace.Data
{
    public struct FreezeData: IEffectData
    {
        public float Delay;
        public float Duration;
        public float FreezeIndex;

        public FreezeData(float _delay, float _duration, float _freezeIndex)
        {
            Delay = _delay;
            Duration = _duration;
            FreezeIndex = _freezeIndex;
        }
    }
}